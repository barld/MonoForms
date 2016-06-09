using System;

namespace MonoForms.ControlDecoretors
{
    public class ControlVisibleOnPredicate<TControl> : ControlVisibilityDecorator where TControl : IControl
    {
        private readonly Predicate<TControl> _predicate;

        public ControlVisibleOnPredicate(TControl origenal, Predicate<TControl> predicate) : base(origenal)
        {
            _predicate = predicate;
        }

        public override bool Visible
        {
            get { return _predicate((TControl)_origenal); }
            set { }//ignore input
        }
    }

    public class ControlVisibleOnPredicate: ControlVisibleOnPredicate<IControl>
    {
        public ControlVisibleOnPredicate(IControl origenal, Predicate<IControl> predicate ) : base(origenal, predicate)
        {
        }
    }
}