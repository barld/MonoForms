using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using MonoForms.Extensions;

namespace MonoForms
{
    public class LabelAdapter : Label, IDisposable
    {
        private readonly System.Windows.Forms.Label wLabel;
        public LabelAdapter(System.Windows.Forms.Label wLabel)
        {
            this.wLabel = wLabel;

            //listen to events
            this.Text = wLabel.Text;
            this.wLabel.TextChanged += (sender, e) => base.Text = wLabel.Text;
            Position = wLabel.Location.ToVector2();
        }

        public override string Text
        {
            get
            {
                return wLabel.Text;
            }
            set
            {
                if (value == null) throw new ArgumentNullException();
                if (value != wLabel.Text)
                {
                    wLabel.Text = value;
                    //needed for trigering event
                    base.Text = value;
                }
            }
        }

        public void Dispose()
        {
            wLabel?.Dispose();
        }
    }
}