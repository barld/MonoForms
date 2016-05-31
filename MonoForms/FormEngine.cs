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
        private readonly Action<SpriteBatch> onDraw;

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

        internal FormEngine(Action<SpriteBatch> onDraw) : this("MonoForm", onDraw) { }

        internal FormEngine(string title, Action<SpriteBatch> onDraw) : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += Window_ClientSizeChanged;
            Title = title;
            this.onDraw = onDraw;
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
            Fonts.Ariel = Content.Load<SpriteFont>("Arial");
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.LightGray);

            spriteBatch.Begin();
            onDraw?.Invoke(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}