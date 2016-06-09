using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MonoForms.Collections;
using MonoForms.Extensions;
using Color = Microsoft.Xna.Framework.Color;

namespace MonoForms
{
    public class SimpleForm : IForm, IContainer
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

        internal FormEngine FormEngine { get; }

        public Size Size
        {
            get { return FormEngine.Size; }
            set { FormEngine.Size = value; }
        }

        public ILinkedList<IControl> Controls { get; set; }

        public SimpleForm()
        {
            FormEngine = new FormEngine(onDraw,onUpdate);
            FormEngine.SizeChanged += FormEngine_SizeChanged;
            FormEngine.Color = Color.DarkOrange;
        }

        private void onUpdate(float dt) => Controls.ForEach(c => c.UpdateControl(dt));

        private void onDraw(SpriteBatch spriteBatch)
        {
            Controls
                .Where(c => c.Visible)
                .ForEach(c => c.DisplayControl(spriteBatch));
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