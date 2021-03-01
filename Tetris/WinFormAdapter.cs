using System.Drawing;

namespace Tetris
{
    internal class WinFormAdapter
    {
        private const int CELL_SIZE = 50;

        public static Rectangle GetRect(int x, int y)
        {
            Point location = GetLocation(x, y);
            Size size = new Size(CELL_SIZE, CELL_SIZE);
            return new Rectangle(location, size);
        }

        private static Point GetLocation(int x, int y)
        {
            return new Point(x * CELL_SIZE, y * CELL_SIZE);
        }
    }
}
