using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class WinFormAdapter
    {
        public const int CellSize = 50;
        public static Point GetLocation(int x, int y)
        {
            return new Point(x * CellSize, y * CellSize);
        }
        public static Rectangle GetRect(int x, int y)
        {
            Point location = GetLocation(x, y);
            Size size = new Size(CellSize, CellSize);
            return new Rectangle(location, size);
        }
    }
}
