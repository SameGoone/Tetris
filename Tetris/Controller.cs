using System;

namespace Tetris
{
    public enum Figures
    {
        O_Figure,
        Z_Figure,
        S_Figure,
        L_Figure,
        J_Figure,
        I_Figure,
        T_Figure
    }

    public class Controller
    {
        public static Controller instance;

        private const int WIDTH = 10;
        private const int HEIGHT = 15;
        public bool[,] Cells { get; private set; }
        public int Score { get; private set; } = 0;
        public Figure CurrentFigure;

        public int Level { get; private set; }

        public int NormalTimeBetweenSteps
        {
            get
            {
                return normalTimesBetweenSteps[Level];
            }
        }

        public int FastTimeBetweenSteps { get; private set; } = 20;

        private int[] normalTimesBetweenSteps = new int[] { 1000, 850, 700, 650, 500 };

        public Controller()
        {
            if (instance == null)
                instance = this;

            Cells = new bool[WIDTH, HEIGHT];
            Level = 0;
        }

        public void GenerateFigure()
        {
            Figures newFigure = GetRandomEnum<Figures>();

            switch (newFigure)
            {
                case Figures.O_Figure:
                    CurrentFigure = new O_Figure();
                    break;

                case Figures.Z_Figure:
                    CurrentFigure = new Z_Figure();
                    break;

                case Figures.S_Figure:
                    CurrentFigure = new S_Figure();
                    break;

                case Figures.L_Figure:
                    CurrentFigure = new L_Figure();
                    break;

                case Figures.J_Figure:
                    CurrentFigure = new J_Figure();
                    break;

                case Figures.I_Figure:
                    CurrentFigure = new I_Figure();
                    break;

                case Figures.T_Figure:
                    CurrentFigure = new T_Figure();
                    break;
            }
        }

        public bool CheckDefeat()
        {
            bool isDefeat = false;
            for (int i = 0; i < WIDTH; i++)
            {
                if (Cells[i, 0])
                {
                    isDefeat = true;
                    break;
                }
            }
            return isDefeat;
        }

        public void CheckFilled()
        {
            bool[] isFilled = new bool[HEIGHT];
            for (int j = 0; j < HEIGHT; j++)
            {
                int countOfFilled = 0;
                for (int i = 0; i < WIDTH; i++)
                {
                    if (Cells[i, j])
                        countOfFilled++;
                }

                if (countOfFilled == WIDTH)
                    isFilled[j] = true;
            }

            AnalyzeLines(isFilled);
        }

        private void AnalyzeLines(bool[] isFilled)
        {
            int upperLine = HEIGHT;
            int lowerLine = 0;
            int countOfLines = 0;
            for (int i = 0; i < isFilled.Length; i++)
            {
                if (isFilled[i])
                {
                    countOfLines++;
                    if (i < upperLine)
                        upperLine = i;
                    if (i > lowerLine)
                        lowerLine = i;
                }
            }

            if (countOfLines == 0)
                return;

            Score += countOfLines * 100;

            for (int j = upperLine; j <= lowerLine; j++)
                for (int i = 0; i < WIDTH; i++)
                    Cells[i, j] = false;

            for (int k = 0; k < countOfLines; k++)
            {
                for (int j = lowerLine; j > 0; j--)
                {
                    for (int i = 0; i < WIDTH; i++)
                        Cells[i, j] = Cells[i, j - 1];
                }
            }
        }

        public void ShiftCurrentFigure(Direction direction)
        {
            switch (direction)
            {
                case Direction.Righter: 
                    CurrentFigure.Righter();
                    break;

                case Direction.Lefter: 
                    CurrentFigure.Lefter();
                    break;

                case Direction.Lower:
                    CurrentFigure.Lower();
                    break;
            }
        }

        public void RotateCurrentFigure()
        {
            CurrentFigure.Rotate();
        }

        static T GetRandomEnum<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(new Random().Next(v.Length));
        }
    }
}