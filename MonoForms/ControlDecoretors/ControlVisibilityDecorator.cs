using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoForms.ControlDecoretors
{
    public abstract class ControlVisibilityDecorator: IControl
    {
        protected IControl _origenal;

        protected ControlVisibilityDecorator(IControl origenal)
        {
            _origenal = origenal;
        }

        public void DisplayControl(SpriteBatch spriteBatch)
        {
            _origenal.DisplayControl(spriteBatch);
        }

        public virtual void UpdateControl(float dt)
        {
            _origenal.UpdateControl(dt);
        }

        public Vector2 Position
        {
            get { return _origenal.Position; }
            set { _origenal.Position = value; }
        }

        public abstract bool Visible { get; set; }
    }
}