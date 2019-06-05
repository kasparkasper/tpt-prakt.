﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const double CellSize = 30D;
        const int CellCount = 16;

        public MainWindow()
        {
            InitializeComponent();
            DrawBoardBackground();
            InitSnake();
        }


        private void InitSnake()
        {
            Snake.Height = CellSize;
            Snake.Width = CellSize;
            double coord = CellCount * CellSize / 2;
            Canvas.SetTop(Snake, coord);
            Canvas.SetLeft(Snake, coord);
        }
        private void MoveSnake(Direction direction)
        {
            if(direction == Direction.Up ||
                direction == Direction.Down)
            {
                double currentTop = Canvas.GetTop(Snake);
                double newTop = direction == Direction.Up
                ?currentTop - CellSize
                :currentTop + CellSize;
                Canvas.SetTop(Snake, newTop);

            }

            if(direction == Direction.Left ||
                direction == Direction.Right)
            {

                double currentLeft = Canvas.GetLeft(Snake);
                double newLeft = direction == Direction.Left
                ? currentLeft - CellSize
                : currentLeft + CellSize;
                Canvas.SetLeft(Snake, newLeft);
            }
        }



        private void DrawBoardBackground()
        {
            SolidColorBrush color1 = Brushes.SpringGreen;
            SolidColorBrush color2 = Brushes.LimeGreen;

            for (int row = 0; row < CellCount; row++)
            {
                SolidColorBrush color =
                    row % 2 == 0 ? color1 : color2;

                for (int col = 0; col < CellCount; col++)
                {
                    Rectangle r = new Rectangle();
                    r.Width = CellSize;
                    r.Height = CellSize;
                    r.Fill = color;
                    Canvas.SetTop(r, row * CellSize);
                    Canvas.SetLeft(r, col * CellSize);
                    board.Children.Add(r);

                    color = color == color1 ? color2 : color1;
                }
            }
        }

        private void Window_KeyDown(
            object sender, KeyEventArgs e)
        {
            Direction direction;
            switch(e.Key)
            {
                case Key.Up:
                    direction = Direction.Up;
                    break;

                case Key.Down:
                    direction = Direction.Down;
                    break;

                case Key.Left:
                    direction = Direction.Left;
                    break;

                case Key.Right:
                    direction = Direction.Right;
                    break;

                default:
                    return;
            }

            MoveSnake(direction);     
            
        }

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}
