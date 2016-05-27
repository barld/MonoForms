using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoForms
{
    internal class FormEngine: Game
    {
        private readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        string title = string.Empty;
        Size size;

        public event EventHandler SizeChanged;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                Window.Title = value;
            }
        }

        internal Size Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                graphics.PreferredBackBufferWidth = size.Width;
                graphics.PreferredBackBufferHeight = size.Height;
                graphics.ApplyChanges();
                SizeChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        internal FormEngine() : this("MonoForm") { }

        internal FormEngine(string title) : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += Window_ClientSizeChanged;
            Title = title;
        }

        private void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            if(graphics.GraphicsDevice.Viewport.Width != Size.Width || graphics.GraphicsDevice.Viewport.Height != Size.Height)
                Size = new Size(graphics.GraphicsDevice.Viewport.Width, graphics.PreferredBackBufferHeight);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.LightGray);

            spriteBatch.Begin();
            var font = Content.Load<SpriteFont>("Arial");
            spriteBatch.DrawString(font, "Score", new Vector2(100, 100), Microsoft.Xna.Framework.Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}