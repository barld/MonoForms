using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using MonoForms.Collections;
using Microsoft.Xna.Framework.Graphics;
using MonoForms.Extensions;

namespace MonoForms
{
    public class WinFormsAdapter : IForm, IContainer
    {
        string title = "SimpleForm";
        System.Windows.Forms.Form classicForm;

        public event EventHandler TitleChanged;
        public event EventHandler SizeChanged;

        public WinFormsAdapter(System.Windows.Forms.Form classicForm) : base()
        {
            FormEngine = new FormEngine(onDraw, onUpdate);
            FormEngine.Color = classicForm.BackColor.Convert();
            FormEngine.SizeChanged += FormEngine_SizeChanged;

            this.classicForm = classicForm;
            classicForm.SizeChanged += ClassicForm_SizeChanged;
            FormEngine.Size = classicForm.Size;
            FormEngine.Title = classicForm.Name;

            foreach(System.Windows.Forms.Control origenalControl in classicForm.Controls)
            {
                Controls = new Node<IControl>(WinformsControlTOControlFactory.Create(origenalControl), Controls);
            } 
        }

        private void onUpdate(float dt)
        {
            foreach(var control in Controls)
            {
                control.UpdateControl(dt);
            }
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

        private FormEngine FormEngine { get; }
        public Microsoft.Xna.Framework.Color Color { get; set; }

        public ILinkedList<IControl> Controls { get; set; } = new EmptyNode<IControl>();

        public void Dispose()
        {
            ((IDisposable)FormEngine).Dispose();
        }

        public void Show()
        {
            FormEngine.Run();
        }

        public void onDraw(SpriteBatch spriteBatch)
        {
            foreach(var control in Controls)
            {
                control.DisplayControl(spriteBatch);
            }
        }
    }
}