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
        public Vector2 Pos { get; private set; }

        private Controller controller;

        public bool CheckPossibilityOfShifting(Direction direction)
        {
            bool[,] cells = controller.Cells;
            int width = cells.GetLength(0);
            int height = cells.GetLength(1);

            switch (direction)
            {
                case Direction.Lower:
                    return Pos.y < height - 1 && !cells[Pos.x, Pos.y + 1];

                case Direction.Righter:
                    return Pos.x < width - 1 && !cells[Pos.x + 1, Pos.y];

                case Direction.Lefter:
                    return Pos.x > 0 && !cells[Pos.x - 1, Pos.y];

                default: return false;
            }
        }

        public FigurePart(Vector2 pos)
        {
            Pos = pos;

            controller = Controller.instance;
        }

        public bool CanChangePos(Vector2 mainPos, Vector2 deltaPos)
        {
            bool[,] cells = controller.Cells;
            int playingWidth = cells.GetLength(0);
            int playingHeight = cells.GetLength(1);

            int newX = mainPos.x + deltaPos.x;
            int newY = mainPos.y + deltaPos.y;

            bool canChangePos = newX < playingWidth && newX >= 0
                             && newY < playingHeight && newY >= 0
                             && !cells[newX, newY];

            return canChangePos;
        }

        public void SetPosition(Vector2 pos)
        {
            Pos = pos;
        }

        public void Lower()
        {
            Pos = new Vector2(Pos.x, Pos.y + 1);
        }

        public void Righter()
        {
            Pos = new Vector2(Pos.x + 1, Pos.y);
        }

        public void Lefter()
        {
            Pos = new Vector2(Pos.x - 1, Pos.y);
        }
    }
}
