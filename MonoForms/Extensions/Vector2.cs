using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoForms.Extensions
{
    public static class Vector2Extentsions
    {
        public static Vector2 ToVector2(this System.Drawing.Point point) => new Vector2(point.X, point.Y);
    }
}
