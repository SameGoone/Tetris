namespace Tetris
{
    public class PlayingField
    {
        public bool[,] Cells { get; private set; }

        public PlayingField(int width, int height)
        {
            Cells = new bool[width, height];
        }
    }
}
