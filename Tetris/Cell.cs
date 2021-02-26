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


        public Cell(int numberX, int numberY, bool isFilled)
        {
            X = numberX * PlayingField.CellSize;
            Y = numberY * PlayingField.CellSize;
            IsFilled = isFilled;
        }
    }
}
