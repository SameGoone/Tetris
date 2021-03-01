using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Z_Figure : Figure
    {
        public Z_Figure()
        {
            Parts = new FigurePart[4];
            Parts[0] = new FigurePart(4, 0);
            Parts[1] = new FigurePart(5, 0);
            Parts[2] = new FigurePart(5, 1);
            Parts[3] = new FigurePart(6, 1);
        }

        public override void Rotate()
        {
            if (state == 0)
            {
                state = 1;
                Parts[0].ChangePos(1, -1);
                Parts[2].ChangePos(-1, -1);
                Parts[3].ChangePos(-2, 0);
            }
            else
            {
                state = 0;
                Parts[0].ChangePos(-1, 1);
                Parts[2].ChangePos(1, 1);
                Parts[3].ChangePos(2, 0);
            }
        }
    }
}
