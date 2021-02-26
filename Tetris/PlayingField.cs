using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class PlayingField
    {
        public Cell[,] cells { get; private set; }

        public PlayingField(int width, int height)
        {
            cells = new Cell[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    cells[i, j] = new Cell(i, j);
                }
            }
        }
    }
}
