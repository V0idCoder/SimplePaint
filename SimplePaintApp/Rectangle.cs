using Microsoft.Graphics.Canvas.UI.Xaml;

namespace SimplePaintApp
{
    public class Rectangle : ClosedShape
    {
        public override void Draw(CanvasDrawEventArgs args)
        {
            args.DrawingSession.FillRectangle(x1, y1, (x2 - x1), y2 - y1, fillColor);
            args.DrawingSession.DrawRectangle(x1, y1, (x2 - x1), y2 - y1, color, strokeWidth, strokeStyle);

        }
    }
}
