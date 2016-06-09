using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoForms.Extensions;

namespace MonoForms
{
    public abstract class AbstractButton : IControl
    {
        protected Label label = new Label();

        public event EventHandler MouseEnter;
        public event EventHandler MouseClick;
        public event EventHandler MouseLeave;

        Vector2 position;

        protected AbstractButton(string text)
        {
            label.Text = text;
        }

        public Vector2 Position
        {
            get { return position; }
            set
            {
                position = value;
                rectangle = Rectangle.SetPosition(value);
            }
        }

        public bool Visible { get; set; } = true;

        Rectangle rectangle;

        public Rectangle Rectangle
        {
            get { return rectangle; }
            set
            {
                rectangle = value;
                position = value.ToVector2();
                label.Position = value.ToVector2() + new Vector2(2, 2);
            }
        }

        public void DisplayControl(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(FormEngine.PlainTexture, rectangle, Color.DarkSlateGray);
            label.DisplayControl(spriteBatch);
        }

        private bool isClicked = false;
        private bool isHoverd = false;

        public void UpdateControl(float dt)
        {
            var mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
            if (Rectangle.Contains(mouseState.Position))
            {
                if (isHoverd == false)
                    MouseEnter?.Invoke(this, EventArgs.Empty);
                isHoverd = true;
                if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                {
                    isClicked = true;
                }
                else if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released && isClicked)
                {
                    isClicked = false;
                    MouseClick?.Invoke(this, EventArgs.Empty);
                }
            }
            else
            {
                if (isHoverd)
                {
                    MouseLeave?.Invoke(this, EventArgs.Empty);
                }
                isHoverd = false;
            }
        }
    }
}