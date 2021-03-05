using System;

namespace Tetris
{
    public abstract class Figure
    {
        public FigurePart[] Parts { get; protected set; }

        public Vector2 MainPos
        {
            get
            {
                return Parts[0].Pos;
            }
        }

        public Controller controller;

        protected Vector2[,] States;

        protected int state;

        public event Action OnBaked;

        public Figure()
        {
            controller = Controller.instance;
            Parts = new FigurePart[4];
            state = 0;
        }

        protected void InitializeParts(int mainX, int mainY)
        {
            Parts[0] = new FigurePart(new Vector2(mainX, mainY));
            for (int i = 1; i < Parts.Length; i++)
            {
                Vector2 pos = new Vector2(MainPos.x + States[0, i].x, MainPos.y + States[0, i].y);
                Parts[i] = new FigurePart(pos);
            }
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

        protected void SetState(int stateIndex)
        {
            if (CheckAllPartsCanChangePos(stateIndex))
            {
                state = stateIndex;
                for (int i = 1; i < Parts.Length; i++)
                {
                    Vector2 pos = new Vector2(MainPos.x + States[stateIndex, i].x, MainPos.y + States[stateIndex, i].y);
                    Parts[i].SetPosition(pos);
                }
            }
        }

        protected bool CheckAllPartsCanChangePos(int stateIndex)
        {
            return Parts[1].CanChangePos(MainPos, States[stateIndex, 1])
                && Parts[2].CanChangePos(MainPos, States[stateIndex, 2])
                && Parts[3].CanChangePos(MainPos, States[stateIndex, 3]);
        }

        private void Bake()
        {
            foreach (FigurePart part in Parts)
            {
                bool[,] cells = controller.Cells;
                cells[part.Pos.x, part.Pos.y] = true;
            }
            OnBaked();
        }
    }
}
