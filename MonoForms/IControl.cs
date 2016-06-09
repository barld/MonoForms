using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoForms
{
    public interface IControl
    {
        void DisplayControl(SpriteBatch spriteBatch);
        void UpdateControl(float dt);
        Vector2 Position { get; set; }
        bool Visible { get; set; }
    }
}