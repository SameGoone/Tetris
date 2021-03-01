namespace Tetris
{
    public enum Direction
    {
        Righter,
        Lefter,
        Lower
    }
    public class FigurePart
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private Controller controller;

        public bool CheckPossibilityOfShifting(Direction direction)
        {
            bool[,] cells = controller.Cells;
            int width = cells.GetLength(0);
            int height = cells.GetLength(1);

            switch (direction)
            {
                case Direction.Lower:
                    return Y < height - 1 && !cells[X, Y + 1];

                case Direction.Righter:
                    return X < width - 1 && !cells[X + 1, Y];

                case Direction.Lefter:
                    return X > 0 && !cells[X - 1, Y];

                default: return false;
            }
        }

        public FigurePart(int x, int y)
        {
            X = x;
            Y = y;

            controller = Controller.instance;
        }

        public void ChangePos(int deltaX, int deltaY)
        {
            int newX
            X += deltaX;
            Y += deltaY;
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
