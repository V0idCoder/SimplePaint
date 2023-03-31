// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SimplePaintApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            appButton.Add(Line);
            appButton.Add(Rectangle);
            appButton.Add(Ellipse);
        }
        List<AppBarToggleButton> appButton = new List<AppBarToggleButton>();

        SelectionTool selectionTool = new SelectionTool();

        void SelectTool(object sender, RoutedEventArgs e)
        {
            AppBarToggleButton appBarToggleButton = (AppBarToggleButton)sender;
            foreach (AppBarToggleButton button in appButton)
            {
                if (button != appBarToggleButton)
                {
                    button.IsChecked = false;
                }
            }
        }

        List<Shape> formes = new List<Shape>();

        Shape currentForme = new Line();



        private void DrawingCanvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.CanvasControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasDrawEventArgs args)
        {
            currentForme.color = LineColor;
            currentForme.strokeWidth = LineWidth;

            currentForme.strokeStyle = new CanvasStrokeStyle();
            currentForme.strokeStyle.DashStyle = (CanvasDashStyle)LineStyle;

            if (currentForme is ClosedShape)
            {
                var closedShape = currentForme as ClosedShape;
                closedShape.fillColor = FillColor;

            }

            foreach (Shape f in formes)
            {
                f.Draw(args);
            }

            currentForme.Draw(args);
            selectionTool.Draw(args);
            
        }

        private void DrawingCanvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (Line.IsChecked == true)
            {
                currentForme = new Line();
            }
            if (Rectangle.IsChecked == true)
            {
                currentForme = new Rectangle();
            }
            if (Ellipse.IsChecked == true)
            {
                currentForme = new Ellipse();
            }
            currentForme.x1 = e.GetCurrentPoint(DrawingCanvas).Position._x;
            currentForme.y1 = e.GetCurrentPoint(DrawingCanvas).Position._y;

            currentForme.strokeWidth = 2;
            selectionTool.SelectedShape = currentForme; 
        }


        private void DrawingCanvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (e.Pointer.IsInContact)
            {
                currentForme.x2 = e.GetCurrentPoint(DrawingCanvas).Position._x;
                currentForme.y2 = e.GetCurrentPoint(DrawingCanvas).Position._y;
                DrawingCanvas.Invalidate();

            }
        }

        private void DrawingCanvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {

            currentForme.x2 = e.GetCurrentPoint(DrawingCanvas).Position._x;
            currentForme.y2 = e.GetCurrentPoint(DrawingCanvas).Position._y;
            formes.Add(currentForme);

            DrawingCanvas.Invalidate();

        }

        //Sélection outils/Implémentation de méthode

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
        public float LineWidth
        {
            get => (float)LineWidthSelection.Value;
            set => LineWidthSelection.Value = Math.Clamp(value,
                       LineWidthSelection.Minimum, LineWidthSelection.Maximum);
        }

        public int LineStyle
        {
            get => LineStyleSelection.SelectedIndex;
            set => LineStyleSelection.SelectedIndex = Math.Clamp(value, 0,
                       LineStyleSelection.Items.Count - 1);
        }


    }
}
