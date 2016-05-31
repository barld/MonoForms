using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoForms.Collections
{
    public interface ILinkedList<T> : IEnumerable<T>
    {
    }

    public class Node<T>: ILinkedList<T>
    {
        public T Head { get; }
        public ILinkedList<T> Tail { get; }

        public Node(T head, ILinkedList<T> tail)
        {
            Head = head;
            Tail = tail;
        }

        public Node(T head) : this(head, new EmptyNode<T>()) { }

        public IEnumerator<T> GetEnumerator()
        {
            return this.GetIterator().ToIEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetIterator().ToIEnumerator();
        }
    }

    public class EmptyNode<T> : ILinkedList<T>
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
