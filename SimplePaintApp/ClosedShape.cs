namespace SimplePaintApp
{
    public abstract class ClosedShape : Shape
    {
        public Windows.UI.Color fillColor { get; set; }

        public bool IsTransparent { get; set; } = true;


    }
}
