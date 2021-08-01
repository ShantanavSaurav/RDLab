using System.ServiceModel;
using RMI.Contracts;

namespace Test.Server {
    /// <summary>
    /// Custom Queue Implementation using Linked List.
    /// ServiceBehavior attribute applies contract defined in interface.
    /// </summary>
    /// <typeparam name="T">Generic Class</typeparam>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class CustomQueue<T> : ICustomQueue<T> {

        /// <summary>
        /// Fields: 
        /// head -> Node: Head of Queue Node
        /// tail -> Node: Tail of Queue Node
        /// size -> int: Size of Queue
        /// All fields have accessor methods --> Access is private, No properties defined
        /// </summary>
        private Node<T> head;
        private Node<T> tail;
        private int size;

        // Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CustomQueue() {
            head = null;
            tail = null;
            size = 0;
        }

        // Methods

        /// <summary>
        /// Enqueues an element
        /// </summary>
        /// <param name="data">Data to be added to queue</param>
        public void Enqueue(T data) {
            Node<T> newNode = new Node<T>(data);
            if (isEmpty( )) {
                head = newNode;
            } else {
                tail.Next = newNode;
            }
            tail = newNode;
            size++;
        }

        /// <summary>
        /// Dequeues an element
        /// </summary>
        /// <returns>Dequeued element</returns>
        public T Dequeue() {
            if (isEmpty( )) {
                throw new InvalidQueueOperation("Dequeue on empty queue");
            }
            T removed = head.Val;
            head = head.Next;
            if (isEmpty( )) {
                tail = null;
            }
            size--;
            return removed;
        }

        /// <summary>
        /// Returns front value of queue
        /// </summary>
        /// <returns>Front value of queue</returns>
        public T Front() {
            if (isEmpty( )) {
                throw new InvalidQueueOperation("Front value of empty queue");
            }
            return head.Val;
        }

        /// <summary>
        /// Returns back value of queue
        /// </summary>
        /// <returns>Back value of queue</returns>
        public T Back() {
            if (isEmpty( )) {
                throw new InvalidQueueOperation("Back value of empty queue");
            }
            return tail.Val;
        }

        /// <summary>
        /// Get size of queue
        /// </summary>
        /// <returns>Size of array</returns>
        public int getSize() {
            return size;
        }

        /// <summary>
        /// Returns an array containing queue elements
        /// </summary>
        /// <returns>Array of queue elements</returns>
        public T[] toArray() {
            T[] lstQueue = new T[size];
            Node<T> current = head;
            for (int i = 0; i < size; i++) {
                lstQueue[i] = current.Val;
                current = current.Next;
            }
            return lstQueue;
        }

        /// <summary>
        /// Checks if the Queue is empty
        /// </summary>
        /// <returns>bool -> Is the queue empty?</returns>
        public bool isEmpty() {
            return (head == null);
        }

    }
}
