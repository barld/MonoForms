using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoForms.Collections
{
    internal interface ILinkedList<T> : IEnumerable<T>
    {
    }

    internal class Node<T>: ILinkedList<T>
    {
        internal T Head { get; }
        internal ILinkedList<T> Tail { get; }

        internal Node(T head, ILinkedList<T> tail)
        {
            Head = head;
            Tail = tail;
        }

        internal Node(T head) : this(head, new EmptyNode<T>()) { }

        public IEnumerator<T> GetEnumerator()
        {
            return this.GetIterator().ToIEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetIterator().ToIEnumerator();
        }
    }

    internal class EmptyNode<T> : ILinkedList<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            return this.GetIterator().ToIEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetIterator().ToIEnumerator();
        }
    }

}
