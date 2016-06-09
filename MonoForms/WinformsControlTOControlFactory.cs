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
            return CreateVisit(wControl,
                onImplemented: c=>c,
                onNotImplemented: ()=> { throw new NotImplementedException("this control is not (yet) supported"); });
        }

        public static IOption<IControl> CreateOption(System.Windows.Forms.Control wControl)
        {
            return CreateVisit<IOption<IControl>>(wControl, 
                onImplemented: c => new Some<IControl>(c), 
                onNotImplemented: () => new None<IControl>());
        }

        public static T CreateVisit<T>(System.Windows.Forms.Control wControl, Func<IControl,T> onImplemented, Func<T> onNotImplemented)
        {
            if (wControl is System.Windows.Forms.Label)
                return onImplemented(new LabelAdapter(wControl as System.Windows.Forms.Label));
            else if (wControl is System.Windows.Forms.Button)
                return onImplemented(new ButtonAdapter(wControl as System.Windows.Forms.Button));
            else
                return onNotImplemented();
        }
    }
}