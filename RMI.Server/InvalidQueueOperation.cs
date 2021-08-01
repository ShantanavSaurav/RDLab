using System;

namespace RMI.Server {
    /// <summary>
    /// Custom Exception for Invalid Queue Operations
    /// </summary>
    [Serializable]
    class InvalidQueueOperation : Exception {
        public InvalidQueueOperation() { }
        public InvalidQueueOperation(string ex) : base(String.Format("Invalid Queue Operation: {0}", ex)) { }
    }
}
