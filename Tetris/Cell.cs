using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Cell
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public bool IsFilled { get; private set; }

        private const int size = 50;

        public Cell(int numberX, int numberY, bool isFilled)
        {
            X = numberX * size;
            Y = numberY * size;
            IsFilled = isFilled;
        }
    }
}
