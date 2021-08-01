using System;
using System.ServiceModel;
using RMI.Contracts;

namespace Test.Server {
    /// <summary>
    /// Main Program class for Server
    /// </summary>
    class Program {
        /// <summary>
        /// Main Method establishes TCP connection given a socket, and hosts the queue service.
        /// </summary>
        /// <param name="args">Command Line Arguments --> Ignored</param>
        static void Main(String[] args) {
            // URIs on which to host the queue connection. Append to this array to host on multiple sockets.
            Uri[] uris = new Uri[1];            
            // TCP Socket on which to host service
            String addr = "net.tcp://localhost:59727";
            // Append to list
            uris[0] = new Uri(addr);

            // Polymorphism: Hosted service is an ICustomQueue instance since that's what the client can see and pass commands to
            // However on server side this refers to and therefore controls a CustomQueue instance
            ICustomQueue<String> queue = new CustomQueue<String>( );
            // Create the ServiceHost object with the hosted service (the queue interface instance) and the URIs on which to host the service
            ServiceHost host = new ServiceHost(queue, uris);
            // Create a NetTcpBinding for cross-machine communication
            NetTcpBinding binding = new NetTcpBinding( );
            // Add service endpoint 
            // Parameters are: 
            //      type of contract (typeof(ServiceInterface))
            //      binding to add endpoint to (NetTcpBinding created earlier)
            //      address for added endpoint (Honestly, not really sure of the relevance of this, it seems to work even if given an empty string)
            host.AddServiceEndpoint(typeof(ICustomQueue<String>), binding, addr);
            // Append a startup method to the host that runs upon opening
            host.Opened += HostOnOpened;
            // Open host
            host.Open( );
            // Await user input to close host and end program
            Console.ReadKey(true);
            host.Close( );
        }

        /// <summary>
        /// Startup method: Notify user of successful opening of host.
        /// </summary>
        /// <param name="sender">Ignored</param>
        /// <param name="eventArgs">Ignored</param>
        private static void HostOnOpened(object sender, EventArgs eventArgs) {
            Console.WriteLine("WCF Queue service started. Connected to net.tcp://localhost:59727/. Press any key to exit");
        }
    }
}
