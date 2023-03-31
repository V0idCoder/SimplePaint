using Microsoft.UI.Xaml.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace SimplePaintApp
{
    public class Lines
    {
        //Update to ClosedShape
        public float x1 { get; set; }
        public float y1 { get; set; }

        public float x2 { get; set; }
        public float y2 { get; set; }

        public Color lineColor { get; set; }
    }
}
