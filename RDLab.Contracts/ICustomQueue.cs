using System.ServiceModel;

namespace RDLab.Contracts {
    /// <summary>
    /// Interface for CustomQueue: define invocable methods for queue operations under a service contract.
    /// Both Client and Server must reference this class.
    /// </summary>
    /// <typeparam name="T">Generic Interface</typeparam>
    [ServiceContract]
    public interface ICustomQueue<T> {
        /// <summary>
        /// Enqueues an element.
        /// Operation Contract ties this method to service contract
        /// </summary>
        /// <param name="data">Data to be added to queue</param>
        [OperationContract]
        void Enqueue(T data);

        /// <summary>
        /// Dequeues an element
        /// Operation Contract ties this method to service contract
        /// </summary>
        /// <returns>Dequeued element</returns>
        [OperationContract]
        T Dequeue();

        /// <summary>
        /// Returns front value of queue
        /// Operation Contract ties this method to service contract
        /// </summary>
        /// <returns>Front value of queue</returns>
        [OperationContract]
        T Front();

        /// <summary>
        /// Returns back value of queue
        /// Operation Contract ties this method to service contract
        /// </summary>
        /// <returns>Back value of queue</returns>
        [OperationContract]
        T Back();

        /// <summary>
        /// Get size of array
        /// Operation Contract ties this method to service contract
        /// </summary>
        /// <returns>Size of array</returns>
        [OperationContract]
        int getSize();

        /// <summary>
        /// Return an array containing queue elements
        /// Operation Contract ties this method to service contract
        /// </summary>
        /// <returns>Array of queue elements</returns>
        [OperationContract]
        T[] toArray();

        /// <summary>
        /// Checks if the Queue is empty
        /// Operation Contract ties this method to service contract
        /// </summary>
        /// <returns>bool -> Is the queue empty?</returns>
        [OperationContract]
        bool isEmpty();
    }
}
