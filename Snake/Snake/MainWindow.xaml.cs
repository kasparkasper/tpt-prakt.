using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System;

namespace SnakeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        const int CellCount = 16;
        double CellSize = 30D;
        DispatcherTimer timer;

        Snake snake;
        private Shape SnakeShape;

        public MainWindow()
        {
            InitializeComponent();
            DrawBoardBackground();
            
            snake = new Snake(SnakeShape, CellSize, CellCount);
            snake.Init();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            snake.Move();
        }

        private void DirectSnake(Direction direction)
        {
            lblSnakeDirection = direction;
            lblSnakeDirection.Content = $"Direction: {direction}";
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

            snake.ChangeDirection(direction);
            
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
