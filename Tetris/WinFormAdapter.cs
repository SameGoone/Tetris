using System.Drawing;

namespace Tetris
{
    internal class WinFormAdapter
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
