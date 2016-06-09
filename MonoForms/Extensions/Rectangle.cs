using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoForms.Extensions
{
    public static class RectangleExtensions
    {
        public static Rectangle SetPosition(this Rectangle rectangle, Vector2 position)
        {
            rectangle.X = (int)position.X;
            rectangle.Y = (int)position.Y;
            return rectangle;
        }

        public static Rectangle ToRectangle(this System.Drawing.Rectangle origenalRectangle)
        {
            return new Rectangle(origenalRectangle.X, origenalRectangle.Y, origenalRectangle.Width, origenalRectangle.Height);
        }

        public static Rectangle ToRectangle(this System.Drawing.Rectangle origenalRectangle, System.Drawing.Point point)
        {
            return new Rectangle(point.X, point.Y, origenalRectangle.Width, origenalRectangle.Height);
        }
    }
}
