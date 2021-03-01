namespace Tetris
{
    public abstract class Figure
    {
        public FigurePart[] Parts { get; protected set; }

        public void Lower()
        {
            bool allPartsCanLower = CheckAllPartsCanLower();
            if (allPartsCanLower)
            {
                foreach (FigurePart part in Parts)
                    part.Lower();
            }
            else
                Bake();
        }

        private bool CheckAllPartsCanLower()
        {
            bool canLower = true;
            foreach (FigurePart part in Parts)
            {
                if (!part.CanLower)
                {
                    canLower = false;
                    break;
                }
            }
            return canLower;
        }

        public void Righter()
        {
            bool allPartsCanLRighter = CheckAllPartsCanRighter();
            if (allPartsCanLRighter)
            {
                foreach (FigurePart part in Parts)
                    part.Righter();
            }
        }

        private bool CheckAllPartsCanRighter()
        {
            bool canRigher = true;
            foreach (FigurePart part in Parts)
            {
                if (!part.CanRighter)
                {
                    canRigher = false;
                    break;
                }
            }
            return canRigher;
        }

        public void Lefter()
        {
            bool allPartsCanLLefter = CheckAllPartsCanLefter();
            if (allPartsCanLLefter)
            {
                foreach (FigurePart part in Parts)
                    part.Lefter();
            }
        }

        private bool CheckAllPartsCanLefter()
        {
            bool canLefter = true;
            foreach (FigurePart part in Parts)
            {
                if (!part.CanLefter)
                {
                    canLefter = false;
                    break;
                }
            }
            return canLefter;
        }

        public abstract void Rotate();

        private void Bake()
        {
            foreach (FigurePart part in Parts)
            {
                bool[,] cells = Controller.PlayingField.Cells;
                cells[part.X, part.Y] = true;
            }
            Controller.GenerateFigure();
        }
    }
}
