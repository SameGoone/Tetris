using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class I_Figure : Figure
    {
        public I_Figure()
        {
            Parts = new FigurePart[4];
            Parts[0] = new FigurePart(4, 0);
            Parts[1] = new FigurePart(4, 1);
            Parts[2] = new FigurePart(4, 2);
            Parts[3] = new FigurePart(4, 3);
        }

        public override void Rotate()
        {
            if (state == 0)
            {
                state = 1;
                Parts[0].ChangePos(-2, 2);
                Parts[1].ChangePos(-1, 1);
                Parts[3].ChangePos(1, -1);
            }
            else
            {
                state = 0;
                Parts[0].ChangePos(2, -2);
                Parts[1].ChangePos(1, -1);
                Parts[3].ChangePos(-1, 1);
            }
        }
    }
}
