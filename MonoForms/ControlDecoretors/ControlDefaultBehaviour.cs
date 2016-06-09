namespace MonoForms.ControlDecoretors
{
    public class ControlDefaultBehaviour :ControlVisibilityDecorator
    {
        public ControlDefaultBehaviour(IControl origenal) : base(origenal)
        {
        }

        public ControlDefaultBehaviour(IControl origenal, bool value) : base(origenal)
        {
            this.Visible = true;
        }

        public override bool Visible { get; set; }
    }
}