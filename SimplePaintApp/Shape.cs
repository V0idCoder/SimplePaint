using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.Graphics.Canvas.UI.Xaml;

namespace SimplePaintApp
{
    public abstract class Shape
    {

        public float x1 { get; set; }

        public float x2 { get; set; }
        public float y1 { get; set; }
        public float y2 { get; set; }
        public Windows.UI.Color color { get; set; }
        public float strokeWidth { get; set; }
        public CanvasStrokeStyle strokeStyle { get; set; }

        public abstract void Draw(CanvasDrawEventArgs args);



    }



}