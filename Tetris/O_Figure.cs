﻿namespace Tetris
{
    internal class O_Figure : Figure
    {
        public O_Figure()
        {
            Parts = new FigurePart[4];
            Parts[0] = new FigurePart(4, 0);
            Parts[1] = new FigurePart(5, 0);
            Parts[2] = new FigurePart(4, 1);
            Parts[3] = new FigurePart(5, 1);
        }
        public override void Rotate()
        {
        }
    }
}