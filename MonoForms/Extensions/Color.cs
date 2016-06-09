using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoForms.Extensions
{
    public static class ColorExtensions
    {
        public static Microsoft.Xna.Framework.Color Convert(this System.Drawing.Color color)
        {
            return new Microsoft.Xna.Framework.Color(color.R, color.G, color.B, color.A);
        }
    }
}
