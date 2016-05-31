﻿using Microsoft.Xna.Framework.Graphics;
using MonoForms.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoForms
{
    public interface IControl
    {
        void DisplayControl(SpriteBatch spriteBatch);
    }
}