using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SimplePaintApp
{
    public class SelectionTool
    {
        const float Handle_Size = 5;
        private int HandleCount = 4;

        public Shape SelectedShape{ get; set; }

        private Vector2 GetHandle(int index) 
        {
            float x = 0;
            float y = 0;

            if (index == 0 || index == 2)
            {
                x = SelectedShape.x1;
            }
            else
            {
                x= SelectedShape.x2;
            }

            if(index == 0 || index == 1)
            {
                y = SelectedShape.y1;
            }
            else
            {
                y= SelectedShape.y2;
            }
            return new Vector2(x, y);
        }
        private void DrawHandle(CanvasDrawEventArgs args, int index) 
        { 
            Vector2 handle = GetHandle(index);
            args.DrawingSession.FillRectangle(handle.X - (Handle_Size / 2), handle.Y - (Handle_Size / 2), Handle_Size, Handle_Size, Colors.White);
            args.DrawingSession.DrawRectangle(handle.X - (Handle_Size / 2), handle.Y - (Handle_Size / 2), Handle_Size, Handle_Size, Colors.Black);
        }
        public void Draw(CanvasDrawEventArgs args)
        {
            if (SelectedShape == null) return;
            args.DrawingSession.DrawRectangle(SelectedShape.x1, SelectedShape.y1, SelectedShape.x2 - SelectedShape.x1, SelectedShape.y2 - SelectedShape.y1, Colors.Black);

            for (int i = 0; i < HandleCount; i++)
            {
                DrawHandle(args, i);
            }
        }
    }

}
