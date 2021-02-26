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

        public const int CellSize = 50;

        public PlayingField(int width, int height)
        {
            Random r = new Random();
            cells = new Cell[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    bool filled = r.Next(0, 2) == 0 ? false : true;
                    cells[i, j] = new Cell(i, j, filled);
                }
            }
        }

        public void SetNewCell(int x, int y, Cell cell)
        {
            cells[x, y] = cell;
        }
    }
}
