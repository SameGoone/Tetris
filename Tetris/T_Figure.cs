using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class T_Figure : Figure
    {
        public T_Figure()
        {
            Parts = new FigurePart[4];
            Parts[0] = new FigurePart(4, 0);
            Parts[1] = new FigurePart(4, 1);
            Parts[2] = new FigurePart(4, 2);
            Parts[3] = new FigurePart(5, 1);
        }

        public override void Rotate()
        {
            if (state == 0)
            {
                state++;
                Parts[0].ChangePos(1, 1);
                Parts[2].ChangePos(-1, -1);
                Parts[3].ChangePos(-1, 1);
            }
            else if (state == 1)
            {
                state++;
                Parts[0].ChangePos(-1, 1);
                Parts[2].ChangePos(1, -1);
                Parts[3].ChangePos(-1, -1);
            }
            else if (state == 2)
            {
                state++;
                Parts[0].ChangePos(-1, -1);
                Parts[2].ChangePos(1, 1);
                Parts[3].ChangePos(1, -1);
            }
            else
            {
                state = 0;
                Parts[0].ChangePos(1, -1);
                Parts[2].ChangePos(-1, 1);
                Parts[3].ChangePos(1, 1);
            }
        }
    }
}
