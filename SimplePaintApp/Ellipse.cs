using Microsoft.Graphics.Canvas.UI.Xaml;

namespace SimplePaintApp
{
    public class Ellipse : ClosedShape
    {
        public override void Draw(CanvasDrawEventArgs args)
        {
            args.DrawingSession.FillEllipse(x1, y1, (x1 - x2), (y1 - y2), fillColor);
            args.DrawingSession.DrawEllipse(x1, y1, (x1 - x2), (y1 - y2), color, strokeWidth, strokeStyle);



        }
    }
}
