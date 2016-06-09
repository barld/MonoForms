using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MonoForms.Extensions;

namespace MonoForms
{
    public class ButtonAdapter : AbstractButton
    {
        private System.Windows.Forms.Button button;

        public ButtonAdapter(System.Windows.Forms.Button button) : base(string.Empty)
        {
            this.button = button;
            Rectangle = button.DisplayRectangle.ToRectangle(button.Location);
            this.label.Text = button.Text;

            MouseClick += ButtonAdapter_MouseClick;
        }

        private void ButtonAdapter_MouseClick(object sender, EventArgs e)
        {
            button.PerformClick();
        }
    }
}