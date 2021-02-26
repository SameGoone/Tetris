using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Square : Figure
    {
        public Square()
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
