using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class FigurePart
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public bool CanLower
        {
            get
            {
                return Y < Controller.HEIGHT - 1 && !Controller.PlayingField.Cells[X, Y + 1];
            }
        }

        public bool CanRighter
        {
            get
            {
                return X < Controller.WIDTH - 1 && !Controller.PlayingField.Cells[X + 1, Y];
            }
        }

        public bool CanLefter
        {
            get
            {
                return X > 0 && !Controller.PlayingField.Cells[X - 1, Y];
            }
        }

        public FigurePart(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Lower()
        {
            Y++;
        }

        public void Righter()
        {
            X++;
        }

        public void Lefter()
        {
            X--;
        }
    }
}
