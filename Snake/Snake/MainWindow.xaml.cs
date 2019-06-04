using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(
            object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                double currentleft = Canvas.GetLeft(rect);
                double newLeft = currentleft + 20;
                Canvas.SetLeft(rect, newLeft);
            }

            if (e.RightButton == MouseButtonState.Pressed)
            {
                Canvas.SetLeft(rect, 20);
            }
        }

        private void Window_KeyDown(
            object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Right)
            {
                double currentleft = Canvas.GetLeft(rect);
                double newLeft = currentleft + 20;
                Canvas.SetLeft(rect, newLeft);
            }

            if (e.Key == Key.Left)
            {
                
                Canvas.SetLeft(rect, Canvas.GetLeft(rect) - 20);
            }

            if (e.Key == Key.Down)
            {
                double currenttop = Canvas.GetTop(rect);
                double newTop = currenttop + 20;
                Canvas.SetTop(rect, newTop);
                
            }

            if (e.Key == Key.Up)
            {
                double currenttop = Canvas.GetTop(rect);
                double newTop = currenttop - 20;
                Canvas.SetTop(rect, newTop);
                
            }
        }
    }
}
