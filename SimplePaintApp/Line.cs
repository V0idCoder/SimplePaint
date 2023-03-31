// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.Graphics.Canvas.UI.Xaml;

namespace SimplePaintApp
{
    public class Line : Shape
    {

        public override void Draw(CanvasDrawEventArgs args)
        {
            args.DrawingSession.DrawLine(x1, y1, x2, y2, color, strokeWidth, strokeStyle);


        }


    }



}