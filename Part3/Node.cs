

using System;
using System.Collections.Generic;
using System.Text;

namespace Part3
{
    public class Node<T> : IComparable<Node<T>>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node(T value)
        {
            this.Value = value;
        }
        public Node(T value, Node<T> next)
        {
            this.Value = value;
            this.Next = next;
        }

        public int CompareTo(Node<T> that)
        {
            if (this.Value is IComparable<T> thisValue)
            {
                if (thisValue.CompareTo(that.Value) < 0) return -1;
                if (thisValue.CompareTo(that.Value) == 0) return 0;
                return 1;
            }
            throw new ArgumentException("CANNOT COMPARE T");
        }

        public override string ToString()
        {
            return Value.ToString();
        }

    }
}
