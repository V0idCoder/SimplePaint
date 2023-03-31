// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using ABI.System.Numerics;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks.Dataflow;
using System.Xml;
using Windows.Devices.Printers;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SimplePaintApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {


        Lines lines = new Lines();
        List<Lines> listLines = new List<Lines>();

        Rectanlge rectanlges = new Rectanlge();
        List<Rectanlge> listRectangles = new List<Rectanlge>();

      
        public MainWindow()
        {
            this.InitializeComponent();
        }


        private void DrawingCanvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.CanvasControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasDrawEventArgs args)
        {
                foreach (var line in listLines)
                {
                    args.DrawingSession.DrawLine(line.x1, line.y1, line.x2, line.y2, line.lineColor, 2);
                }
           
                foreach (var rectangle in listRectangles)
                {
                    args.DrawingSession.DrawRectangle(rectangle.xr1, rectangle.yr1, rectangle.xr2 - rectangle.xr1, rectangle.yr2 - rectangle.yr1, rectangle.rectangleColor, 2);
                }
            
        }
        private void DrawingCanvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (Line.IsChecked == true)
            {
                lines = new Lines();
                lines.x1 = e.GetCurrentPoint(DrawingCanvas).Position._x;
                lines.y1 = e.GetCurrentPoint(DrawingCanvas).Position._y;
                lines.lineColor = LineColor;
                listLines.Add(lines);
            }
            else
            {

                rectanlges = new Rectanlge();
                rectanlges.xr1 = e.GetCurrentPoint(DrawingCanvas).Position._x;
                rectanlges.yr1 = e.GetCurrentPoint(DrawingCanvas).Position._y;
                listRectangles.Add(rectanlges);
                rectanlges.rectangleColor = LineColor;

            }
        }

        private void DrawingCanvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (e.Pointer.IsInContact)
            {
                if (Line.IsChecked == true)
                {
                    lines.x2 = e.GetCurrentPoint(DrawingCanvas).Position._x;
                    lines.y2 = e.GetCurrentPoint(DrawingCanvas).Position._y;
                }
                else
                {
                    rectanlges.xr2 = e.GetCurrentPoint(DrawingCanvas).Position._x;
                    rectanlges.yr2 = e.GetCurrentPoint(DrawingCanvas).Position._y;

                }
                DrawingCanvas.Invalidate();

            }

        }

        private void DrawingCanvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (Line.IsChecked == true)
            {
                lines.x2 = e.GetCurrentPoint(DrawingCanvas).Position._x;
                lines.y2 = e.GetCurrentPoint(DrawingCanvas).Position._y;
            }
            else
            {
                rectanlges.xr2 = e.GetCurrentPoint(DrawingCanvas).Position._x;
                rectanlges.yr2 = e.GetCurrentPoint(DrawingCanvas).Position._y;
            }
            DrawingCanvas.Invalidate();

        }

        public Windows.UI.Color LineColor
        {
            get => ((SolidColorBrush)LineColorBorder.BorderBrush).Color;
            set => LineColorBorder.BorderBrush = new SolidColorBrush(value);
        }

        public Windows.UI.Color FillColor
        {
            get => ((SolidColorBrush)FillColorIcon.Foreground).Color;
            set => FillColorIcon.Foreground = new SolidColorBrush(value);
        }

        private void SetLineColor_Click(object sender, RoutedEventArgs e)
        {
            LineColor = ColorsPicker.Color;
            ColorsButton.Flyout.Hide();
        }

        private void SetFillColor_Click(object sender, RoutedEventArgs e)
        {
            FillColor = ColorsPicker.Color;
            ColorsButton.Flyout.Hide();
        }

        private void CancelColors_Click(object sender, RoutedEventArgs e)
        {
            ColorsButton.Flyout.Hide();
        }

        //Sélection des outils

        private void LineButton_Click(object sender, RoutedEventArgs e)
        {
            if(Line.IsChecked == true || Line.IsChecked == false)
            {
                Line.IsChecked = true;
                Rectangle.IsChecked = false;
            }
        }
        private void RectangleButton_Click(object sender, RoutedEventArgs e)
        {
            if(Rectangle.IsChecked == true || Rectangle.IsChecked == false)
            {
                Rectangle.IsChecked = true;
                Line.IsChecked = false;
            }
        }


    }
}
