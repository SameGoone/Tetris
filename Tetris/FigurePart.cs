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

        public FigurePart(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Lower()
        {
            Y++;
        }
    }
}
