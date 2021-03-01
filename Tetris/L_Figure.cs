using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class L_Figure : Figure
    {
        public L_Figure()
        {
            Parts = new FigurePart[4];
            Parts[0] = new FigurePart(4, 0);
            Parts[1] = new FigurePart(4, 1);
            Parts[2] = new FigurePart(4, 2);
            Parts[3] = new FigurePart(5, 2);
        }
        
        public override void Rotate()
        {
            if (state == 0)
            {
                state++;
                Parts[0].ChangePos(1, 1);
                Parts[2].ChangePos(-1, -1);
                Parts[3].ChangePos(-2, 0);
            }
            else if (state == 1)
            {
                state++;
                Parts[0].ChangePos(-1, 1);
                Parts[2].ChangePos(1, -1);
                Parts[3].ChangePos(0, -2);
            }
            else if (state == 2)
            {
                state++;
                Parts[0].ChangePos(-1, -1);
                Parts[2].ChangePos(1, 1);
                Parts[3].ChangePos(2, 0);
            }
            else
            {
                state = 0;
                Parts[0].ChangePos(1, -1);
                Parts[2].ChangePos(-1, 1);
                Parts[3].ChangePos(0, 2);
            }
        }
    }
}
