namespace Test.Server {
    /// <summary>
    /// LinkNode for LinkedList. Value is immutable.
    /// </summary>
    /// <typeparam name="T">Generic Class</typeparam>
    public class Node<T> {
        /// <summary>
        /// Fields:
        /// val -> T: Value of Node (immutable -> get property only)
        /// rest -> Node: Pointer to next LinkedList value (mutable -> get and set property defined)
        /// </summary>
        private T val;
        private Node<T> next;


        // Properties
        public T Val { get { return val; } }
        public Node<T> Next { get { return next; } set { next = value; } }

        // Constructors

        /// <summary>
        /// Parametrized Constructor
        /// </summary>
        /// <param name="val">Value of Node</param>
        public Node(T val) {
            this.val = val;
            next = null;
        }
    }
}
