using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MonoForms
{
    public interface IForm: IDisposable
    {
        string Title { get; set; }
        Size Size { get; set; }
        void Show();

        event EventHandler SizeChanged;
    }
}