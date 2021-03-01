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

        public bool CanChangePos(Vector2 deltaPos)
        {
            bool[,] cells = controller.Cells;
            int playingWidth = cells.GetLength(0);
            int playingHeight = cells.GetLength(1);

            int newX = X + deltaPos.x;
            int newY = Y + deltaPos.y;

            bool canChangePos = newX < playingWidth && newX >= 0
                             && newY < playingHeight && newY >= 0
                             && !cells[newX, newY];

            return canChangePos;
        }

        public void ChangePos(Vector2 deltaPos)
        {
            X += deltaPos.x;
            Y += deltaPos.y;
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
