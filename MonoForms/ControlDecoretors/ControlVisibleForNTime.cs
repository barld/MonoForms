using System;

namespace MonoForms.ControlDecoretors
{
    public class ControlVisibleForNTime:ControlVisibilityDecorator
    {
        private float _time;

        public ControlVisibleForNTime(IControl origenal, float time) : base(origenal)
        {
            _time = time;
        }

        public override void UpdateControl(float dt)
        {
            _time -= dt;
            base.UpdateControl(dt);
        }

        public override bool Visible
        {
            get { return 0.0 < _time; }
            set { }//ignore input

        }
    }
}