using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MonoForms
{
    public class SimpleForm : IForm
    {
        #region private fields
        string title = "SimpleForm";
        #endregion

        public event EventHandler TitleChanged;
        public event EventHandler SizeChanged;

        public string Title
        {
            get { return title; }
            set
            {                
                title = value;
                TitleChanged?.Invoke(this, EventArgs.Empty);                             
            }
        }

        internal FormEngine FormEngine { get;}

        public Size Size
        {
            get
            {
                return FormEngine.Size;
            }
            set
            {
                FormEngine.Size = value;
            }
        }

        public SimpleForm()
        {
            FormEngine = new FormEngine();
            FormEngine.SizeChanged += FormEngine_SizeChanged;
        }

        private void FormEngine_SizeChanged(object sender, EventArgs e)
        {
            SizeChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Show()
        {
            FormEngine.Run();
        }

        public void Dispose()
        {
            FormEngine.Dispose();
        }
    }
}