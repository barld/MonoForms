using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MonoForms
{
    public class WinFormsAdapter : IForm
    {
        string title = "SimpleForm";
        System.Windows.Forms.Form classicForm;

        public event EventHandler TitleChanged;
        public event EventHandler SizeChanged;

        public WinFormsAdapter(System.Windows.Forms.Form classicForm) : base()
        {
            FormEngine = new FormEngine();
            FormEngine.SizeChanged += FormEngine_SizeChanged;

            this.classicForm = classicForm;
            classicForm.SizeChanged += ClassicForm_SizeChanged;
            FormEngine.Size = classicForm.Size;
            FormEngine.Title = classicForm.Name;
        }

        bool changeSizeFromClassic = false;
        private void ClassicForm_SizeChanged(object sender, EventArgs e)
        {
            changeSizeFromClassic = true;
            FormEngine.Size = classicForm.Size;            
            //do not trigger the event other it is thriggerd twice
        }

        private void FormEngine_SizeChanged(object sender, EventArgs e)
        {
            if (!changeSizeFromClassic)
                classicForm.Size = FormEngine.Size;
            changeSizeFromClassic = false;

            SizeChanged?.Invoke(this, EventArgs.Empty);
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                TitleChanged?.Invoke(this, EventArgs.Empty);
            }
        }

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

        internal FormEngine FormEngine { get; }

        public void Dispose()
        {
            ((IDisposable)FormEngine).Dispose();
        }

        public void Show()
        {
            FormEngine.Run();
        }
    }
}