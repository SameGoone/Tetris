namespace Tetris
{
    public class Controller
    {
        public const int WIDTH = 10;
        public const int HEIGHT = 15;
        public static PlayingField PlayingField;
        public static Figure CurrentFigure;
        public static int Score { get; private set; } = 0;
        public static void GenerateFigure()
        {
            CurrentFigure = new Square();
        }

        public static bool CheckDefeat()
        {
            bool isDefeat = false;
            for (int i = 0; i < WIDTH; i++)
            {
                if (PlayingField.Cells[i, 0])
                {
                    isDefeat = true;
                    break;
                }
            }
            return isDefeat;
        }

        public static void CheckLine()
        {
            bool[] isLine = new bool[HEIGHT];
            for (int j = 0; j < HEIGHT; j++)
            {
                int countOfFilled = 0;
                for (int i = 0; i < WIDTH; i++)
                {
                    if (PlayingField.Cells[i, j])
                        countOfFilled++;
                }

                if (countOfFilled == WIDTH)
                    isLine[j] = true;
            }

            AnalyzeLines(isLine);
        }

        private static void AnalyzeLines(bool[] isLine)
        {
            int upperLine = HEIGHT;
            int lowerLine = 0;
            int countOfLines = 0;
            for (int i = 0; i < isLine.Length; i++)
            {
                if (isLine[i])
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
                    PlayingField.Cells[i, j] = false;

            for (int k = 0; k < countOfLines; k++)
            {
                for (int j = lowerLine; j > 0; j--)
                {
                    for (int i = 0; i < WIDTH; i++)
                        PlayingField.Cells[i, j] = PlayingField.Cells[i, j - 1];
                }
            }
        }
    }
}
