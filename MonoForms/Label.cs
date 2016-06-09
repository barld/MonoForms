using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using MonoForms.Collections;
using Microsoft.Xna.Framework;

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

        public Vector2 Position { get; set; }
      public bool Visible { get; set; }

      public event EventHandler TextChanged;

        public void DisplayControl(SpriteBatch spriteBatch)
        { 
            spriteBatch.DrawString(Fonts.Ariel, Text, Position, Microsoft.Xna.Framework.Color.Black);
        }

        public void UpdateControl(float dt)
        {
        }
    }
}