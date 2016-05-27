using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoForms.Collections
{
    internal static class IteratorExtensions
    {
        internal static LinkedListIterator<T> GetIterator<T>(this ILinkedList<T> ll)
        {
            return new LinkedListIterator<T>(ll);
        }

        internal static IEnumerator<T> ToIEnumerator<T>(this IIterator<T> iterator)
        {
            var value = iterator.GetNext();
            while(value is Some<T>)
            {
                yield return (value as Some<T>).Value;
                value = iterator.GetNext();
            }
        }
    }
    internal interface IIterator<T>
    {
        IOption<T> GetNext();
    }

    internal class LinkedListIterator<T> : IIterator<T>
    {
        ILinkedList<T> ll;
        internal LinkedListIterator(ILinkedList<T> list)
        {
            ll = list;
        }
        public IOption<T> GetNext()
        {
            if(ll is Node<T>)
            {
                ll = ((Node<T>)ll).Tail;
                return new Some<T>(((Node<T>)ll).Head);
            }
            return new None<T>();
        }
    }
}
