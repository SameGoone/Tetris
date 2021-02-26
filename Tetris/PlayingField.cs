using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class PlayingField
    {
        public bool[,] Cells { get; private set; }

        public PlayingField(int width, int height)
        {
            Cells = new bool[width, height];
        }
    }
}
