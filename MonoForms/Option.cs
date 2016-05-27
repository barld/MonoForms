using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoForms
{
    public interface IOption<T>
    {
        //visit patern
        U Visit<U>(Func<U> onNone, Func<T, U> onSome);
        void Visit(Action onNone, Action<T> onSome);
    }
    public class Some<T>: IOption<T>
    {
        public Some(T value)
        {
            Value = value;
        }

        public T Value { get; }

        public void Visit(Action onNone, Action<T> onSome) => onSome(Value);
        public U Visit<U>(Func<U> onNone, Func<T, U> onSome) => onSome(Value);
    }
    public class None<T> : IOption<T>
    {
        public void Visit(Action onNone, Action<T> onSome) => onNone();
        public U Visit<U>(Func<U> onNone, Func<T, U> onSome) => onNone();
    }
}
