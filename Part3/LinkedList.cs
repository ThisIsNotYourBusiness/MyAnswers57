
using System;
using System.Collections.Generic;
using System.Text;

namespace Part3
{


    public class LinkedList<T> where T : IComparable
    {
        private Node<T> first;
        private Node<T> last;
        private Node<T> minNode;
        private Node<T> maxNode;

        // generic function that uses my delegate to find an item that passes the predicate
        static Node<T> Find(IEnumerable<Node<T>> enumerable, Func<Node<T>, bool> predicate)
        {
            foreach (var item in enumerable)
                if (predicate(item))
                    return item;

            return null;
        }


        // does an something on my nodes enumerable
        static void Project(IEnumerable<Node<T>> enumerable, Action<Node<T>> projection)
        {
            foreach (var item in enumerable)
                projection(item);
        }

        public void Append(T value)
        {
            Node<T> newNode = new Node<T>(value);


            // if first node doesn't exist
            if (first == null)
            {
                first = newNode;
                last = newNode;
                minNode = newNode;
                maxNode = newNode;

                return;
            }

            maxNode = FindMax();
            minNode = FindMin();

            // if first node exists, append to last
            last.Next = newNode;
            last = newNode;
        }

        public void Prepend(T value)
        {
            Node<T> newNode = new Node<T>(value);


            // if first node doesn't exist
            if (first == null)
            {
                first = newNode;
                last = newNode;

                return;
            }

            // if first node exits, prepend before first node

            maxNode = FindMax();
            minNode = FindMin();

            newNode.Next = first;
            first = newNode;
        }
        public T Pop()
        {
            // get last and pop it, get the one before last and set to last
            T returnValue;

            if (first == null)
                return default(T);

            IEnumerable<Node<T>> nodeList = ToNodeList();

            Node<T> nodeBeforeLast = Find(nodeList, (n) => (n.Next != null && n.Next.Next == null));

            if (nodeBeforeLast == null)
            {
                returnValue = first.Value;
                first = null;
                return returnValue;
            }

            nodeBeforeLast.Next = null;
            returnValue = last.Value;
            last = nodeBeforeLast;

            maxNode = FindMax();
            minNode = FindMin();

            return returnValue;
        }

        public T Unqueue()
        {
            T returnValue;

            if (first == null)
                return default(T);

            returnValue = first.Value;
            first = first.Next;

            maxNode = FindMax();
            minNode = FindMin();

            return returnValue;
        }

        public IEnumerable<Node<T>> ToNodeList()
        {
            Node<T> pointer = first;
            while (pointer != null)
            {
                yield return pointer;
                pointer = pointer.Next;
            }
        }

        public IEnumerable<T> ToList()
        {
            Node<T> pointer = first;
            while (pointer != null)
            {
                yield return pointer.Value;
                pointer = pointer.Next;
            }
        }

        public bool IsCircular()
        {
            return last != null && last.Next == first;
        }

        public void Sort()
        {
            Node<T> start = new Node<T>(default(T));
            IEnumerable<Node<T>> enumerable = ToNodeList();
            List<Node<T>> list = new List<Node<T>>(enumerable);

            if (list.Count <= 1)
                return;

            list.Sort();

            for (var i = 0; i < list.Count - 1; i++)
            {
                if (i == 0)
                    start = list[i];
                list[i].Next = list[i + 1];
            }
            list[list.Count - 1].Next = null;

            first = start;
            last = list[list.Count - 1];
            minNode = first;
            maxNode = last;
        }

        public Node<T> FindMax()
        {
            Node<T> pointer = this.first;
            Node<T> max = this.first;

            while (pointer != null)
            {
                if (pointer.CompareTo(max) > 0)
                    max = pointer;

                pointer = pointer.Next;
            }

            return max;
        }

        public Node<T> FindMin()
        {
            Node<T> pointer = this.first;
            Node<T> max = this.first;

            while (pointer != null)
            {
                if (pointer.CompareTo(max) < 0)
                    max = pointer;

                pointer = pointer.Next;
            }

            return max;
        }

        public T GetMax()
        {
            return maxNode.Value;
        }

        public T GetMin()
        {
            return minNode.Value;
        }


        public void Print()
        {
            IEnumerable<Node<T>> list = ToNodeList();

            Project(list, (n) => Console.Write("[" + n.Value + "] "));
            Console.WriteLine();
        }


    }

}
