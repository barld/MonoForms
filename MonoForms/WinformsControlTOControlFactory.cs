using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoForms
{
    public static class WinformsControlTOControlFactory
    {
        public static IControl Create(System.Windows.Forms.Control wControl)
        {
            if (wControl is System.Windows.Forms.Label)
                return new LabelAdapter(wControl as System.Windows.Forms.Label);
            else
                throw new NotSupportedException("no adapter available");
        }
    }
}