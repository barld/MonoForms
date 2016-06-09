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
        private readonly Action<float> onUpdate;

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

        internal FormEngine(Action<SpriteBatch> onDraw, Action<float> onUpdate) : this("MonoForm", onDraw, onUpdate) { }

        internal FormEngine(string title, Action<SpriteBatch> onDraw, Action<float> onUpdate) : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += Window_ClientSizeChanged;
            Title = title;
            this.onDraw = onDraw;
            this.onUpdate = onUpdate;
        }

        private void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            if(graphics.GraphicsDevice.Viewport.Width != Size.Width || graphics.GraphicsDevice.Viewport.Height != Size.Height)
                Size = new Size(graphics.GraphicsDevice.Viewport.Width, graphics.PreferredBackBufferHeight);
        }

        public static Texture2D PlainTexture { get; private set; }
        public Microsoft.Xna.Framework.Color Color { get; set; }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            PlainTexture = new Texture2D(this.GraphicsDevice, 1, 1);
            PlainTexture.SetData(new[] { Microsoft.Xna.Framework.Color.White });

            base.LoadContent();
            Fonts.Ariel = Content.Load<SpriteFont>("Arial");
        }

        protected override void Update(GameTime gameTime)
        {
            onUpdate?.Invoke((float)gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color);

            spriteBatch.Begin();
            onDraw?.Invoke(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}