using System.Collections;

namespace GraphAlgorithms
{
    public class Node<T>
    {
        #region Public Properties

        public T Data { get; set; }
        public Node<T> Next { get; set; }

        #endregion

        #region Constructor

        public Node(T data)
        {
            Data = data;
        }
        #endregion
    }

    public class Stack<T> : IEnumerable<T>
    {
        #region Public Properties

        public Node<T> Head { get; private set; }
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        #endregion

        #region Public Methods

        public void Push(T data)
        {
            var node = new Node<T>(data)
            {
                Next = Head
            };

            Head = node;
            Count++;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");

            var temp = Head;

            Head = Head.Next;
            Count--;

            return temp.Data;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");

            return Head.Data;

        }

        public void Print()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");

            while (!IsEmpty)
                Console.Write(Pop() + " ");
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        } 

        #endregion

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();
    }
}