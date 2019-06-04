using System.Windows;
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
            Canvas.SetTop(Snake,coord);
            Canvas.SetLeft(Snake, coord);
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
            if(e.Key == Key.Right)
            {
                double currentLeft = Canvas.GetLeft(Snake);
                double newLeft = currentLeft + 30;
                Canvas.SetLeft(Snake, newLeft);
            }
            else if(e.Key == Key.Left)
            {
                double currentLeft = Canvas.GetLeft(Snake);
                double newLeft = currentLeft - 30;
                Canvas.SetLeft(Snake, newLeft);
            }
            else if(e.Key == Key.Up)
            {
                double currentTop = Canvas.GetTop(Snake);
                double newTop = currentTop - 30;
                Canvas.SetTop(Snake, newTop);
            }
            else if (e.Key == Key.Down)
            {
                double currentTop = Canvas.GetTop(Snake);
                double newTop = currentTop + 30;
                Canvas.SetTop(Snake, newTop);
            }
        }
    }
}
