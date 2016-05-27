using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoForms
{
    public class Label : IControl
    {
        private string text = string.Empty;
        public virtual string Text
        {
            get
            {
                return text;
            }
            set
            {
                if (value == null) throw new ArgumentNullException();
                if(value!=text)
                {
                    text = value;
                    TextChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        public event EventHandler TextChanged;
    }
}