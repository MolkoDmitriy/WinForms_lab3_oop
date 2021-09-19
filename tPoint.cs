using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WinForms_lab3_oop
{
    class tPoint
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Brush brush { get;private set; }

        private bool _direction_X = true;

        private static Random rnd = new Random();
        private int _MoveX = rnd.Next(-7, 3) + 2;
        private int _MoveY = rnd.Next(-7, 3) + 2;

        public tPoint()
        {
            this.X = 0;
            this.Y = 0;
            brush = Brushes.White;
        }
        public tPoint(Brush brush,int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            this.brush = brush;
        }
        
        public void MovementPoint_AlongX(int width,int height)
        {
            if (X < 0) _direction_X = true;
            if (X > width) _direction_X = false;

            if (_direction_X) X += 5;
            else X -= 5;
        }
        
        public void RandomMovementPoint(int width, int height)
        {
            if (X<0||X>width)
            {
                _MoveX = -_MoveX; 
            }
            if (_MoveX == 0) _MoveX += 2;
            X += _MoveX;
            if (Y < 0 || Y > height)
            {
                _MoveY = -_MoveY;
            }
            if (_MoveY == 0) _MoveY += 2;
            Y += _MoveY;
        }
    }
}
