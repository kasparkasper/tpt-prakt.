using Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;


namespace SnakeGame
{
    class Snake
    {
        Direction direction;
        Shape snakeShape;
        double CellSize;
        int CellCount;


        public Snake(Shape snakeShape, double CellSize, int CellCount)
        {
            this.snakeShape = snakeShape;
            this.CellSize = CellSize;
            this.CellCount = CellCount;
        }


        private void Init()
        {
            snakeShape.Height = CellSize;
            snakeShape.Width = CellSize;
            double coord = CellCount * CellSize / 2;
            Canvas.SetTop(snakeShape, coord);
            Canvas.SetLeft(snakeShape, coord);

            ChangeDirection(Direction.Up);
        }

        private void ChangeDirection(Direction newDirection)
        {
            direction = newDirection;
        }

        private void Move()
        {
            if (direction == Direction.Up ||
                direction == Direction.Down)
            {
                double currentTop = Canvas.GetTop(snakeShape);
                double newTop = direction == Direction.Up
                ? currentTop - CellSize
                : currentTop + CellSize;
                Canvas.SetTop(snakeShape, newTop);

            }

            if (direction == Direction.Left ||
                direction == Direction.Right)
            {

                double currentLeft = Canvas.GetLeft(snakeShape);
                double newLeft = direction == Direction.Left
                ? currentLeft - CellSize
                : currentLeft + CellSize;
                Canvas.SetLeft(snakeShape, newLeft);
            }
        }

        internal void ChangeDirection(Direction direction)
        {
            throw new NotImplementedException();
        }

        internal void ChangeDirection(MainWindow.Direction direction)
        {
            throw new NotImplementedException();
        }
    }
    
}

