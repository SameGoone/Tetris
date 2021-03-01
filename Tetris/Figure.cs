namespace Tetris
{
    public abstract class Figure
    {
        public FigurePart[] Parts { get; protected set; }
        public Controller controller;

        protected int state;

        public Figure()
        {
            controller = Controller.instance;
            state = 0;
        }

        public void Lower()
        {
            bool allPartsCanLower = CheckAllPartsCanShifting(Direction.Lower);
            if (allPartsCanLower)
            {
                foreach (FigurePart part in Parts)
                    part.Lower();
            }
            else
                Bake();
        }

        public void Righter()
        {
            bool allPartsCanLRighter = CheckAllPartsCanShifting(Direction.Righter);
            if (allPartsCanLRighter)
            {
                foreach (FigurePart part in Parts)
                    part.Righter();
            }
        }

        public void Lefter()
        {
            bool allPartsCanLLefter = CheckAllPartsCanShifting(Direction.Lefter);
            if (allPartsCanLLefter)
            {
                foreach (FigurePart part in Parts)
                    part.Lefter();
            }
        }

        private bool CheckAllPartsCanShifting(Direction direction)
        {
            bool canShift = true;
            foreach (FigurePart part in Parts)
            {
                if (!part.CheckPossibilityOfShifting(direction))
                {
                    canShift = false;
                    break;
                }
            }
            return canShift;
        }

        public abstract void Rotate();

        private void Bake()
        {
            foreach (FigurePart part in Parts)
            {
                bool[,] cells = controller.Cells;
                cells[part.X, part.Y] = true;
            }
            controller.GenerateFigure();
        }
    }
}
