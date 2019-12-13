using System;
using System.ServiceModel;
using RDLab.Contracts;

namespace RDLab.Client {
    class Program {
        /// <summary>
        /// Main Method establishes TCP connection given a socket, and uses an interface to interact with the remote queue service.
        /// </summary>
        /// <param name="args">Ignored</param>
        static void Main(string[] args) {
            // Create a NetTcpBinding for cross-machine communication
            NetTcpBinding binding = new NetTcpBinding( );
            // Create a ChannelFactory of the Queue Interface type
            ChannelFactory<ICustomQueue<String>> channel = new ChannelFactory<ICustomQueue<String>>(binding);
            // Define Socket to connect to
            String socket = "net.tcp://localhost:59727";
            // Use socket to create a service endpoint
            EndpointAddress endPoint = new EndpointAddress(socket);
            // Use ChannelFactory object to create an interface channel on the endpoint
            ICustomQueue<String> queue = channel.CreateChannel(endPoint);
            // Notify successful connection status to user
            Console.WriteLine("Connection established with net.tcp://localhost:59727/, press any key to begin");
            // Await user key input before invoking test suite to test methods
            Console.ReadKey(true);
            TestSuite(queue);
        }

        /// <summary>
        /// Test Suite for CustomQueue Implementation adapted for Remote Method Invocation
        /// </summary>
        /// <param name="queue">Instance of Queue Interface</param>
        private static void TestSuite(ICustomQueue<String> queue) {
            try {
                Console.WriteLine("Test Suite for CustomQueue");

                // Empty Queue test
                Console.WriteLine("Creating Empty Queue: ");
                Console.Write("Queue is empty: ");
                Console.WriteLine(true == queue.isEmpty( ));
                Console.Write("Queue size is 0: ");
                Console.WriteLine(0 == queue.getSize( ));
                Console.WriteLine( );

                // Add First Element (Enqueue)
                Console.WriteLine("Enqueue: \"A\": ");
                queue.Enqueue("A");
                Console.Write("Queue is not empty: ");
                Console.WriteLine(false == queue.isEmpty( ));
                Console.Write("Queue size is 1: ");
                Console.WriteLine(1 == queue.getSize( ));
                Console.Write("Front is A: ");
                Console.WriteLine("A" == queue.Front( ));
                Console.Write("Back is A: ");
                Console.WriteLine("A" == queue.Back( ));
                Console.WriteLine( );

                // Add Second Element (Enqueue)
                Console.WriteLine("Enqueue: \"B\": ");
                queue.Enqueue("B");
                Console.Write("Queue size is 2: ");
                Console.WriteLine(2 == queue.getSize( ));
                Console.Write("Front is A: ");
                Console.WriteLine("A" == queue.Front( ));
                Console.Write("Back is B: ");
                Console.WriteLine("B" == queue.Back( ));
                Console.WriteLine( );

                // Add Third Element (Enqueue)
                Console.WriteLine("Enqueue: \"C\": ");
                queue.Enqueue("C");
                Console.Write("Queue size is 3: ");
                Console.WriteLine(3 == queue.getSize( ));
                Console.Write("Front is A: ");
                Console.WriteLine("A" == queue.Front( ));
                Console.Write("Back is C: ");
                Console.WriteLine("C" == queue.Back( ));
                Console.WriteLine( );

                // Dequeue Front Element A (Dequeue)
                Console.WriteLine("Dequeue: ");
                String a = queue.Dequeue( );
                Console.Write("Dequeued value is \"A\": ");
                Console.WriteLine(a == "A");
                Console.Write("Queue size is 2: ");
                Console.WriteLine(2 == queue.getSize( ));
                Console.Write("Front is B: ");
                Console.WriteLine("B" == queue.Front( ));
                Console.Write("Back is C: ");
                Console.WriteLine("C" == queue.Back( ));
                Console.WriteLine( );

                // Add Fourth Element (Enqueue)
                Console.WriteLine("Enqueue: \"D\"");
                queue.Enqueue("D");
                Console.Write("Queue size is 3: ");
                Console.WriteLine(3 == queue.getSize( ));
                Console.Write("Front is B: ");
                Console.WriteLine("B" == queue.Front( ));
                Console.Write("Back is D: ");
                Console.WriteLine("D" == queue.Back( ));
                Console.WriteLine( );

                // Check toArray method
                String[] arr = queue.toArray( );
                Console.Write("Queue to array returns: ");
                Console.WriteLine("[{0}]", string.Join(", ", arr));
                Console.WriteLine( );

                // Empty Queue
                while (!queue.isEmpty( )) {
                    Console.Write("Front of Stack: ");
                    Console.WriteLine(queue.Front( ));
                    Console.Write("Back of Stack: ");
                    Console.WriteLine(queue.Back( ));
                    Console.Write("Dequeuing element: ");
                    Console.WriteLine(queue.Dequeue( ));
                }
                Console.WriteLine( );

                // Check toArray method on Empty Queue
                arr = queue.toArray( );
                Console.Write("Queue to array returns: ");
                Console.WriteLine("[{0}]", string.Join(", ", arr));
                Console.WriteLine( );

                Console.WriteLine("Press any key to exit");
                Console.ReadKey(true);
            } catch (Exception ex) {
                Console.WriteLine("An Exception occurred: " + ex.ToString( ));
                Console.ReadKey(true);
                return;
            }
        }
    }
}
