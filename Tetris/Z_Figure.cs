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
                Vector2 delta0 = new Vector2(1, -1);
                Vector2 delta2 = new Vector2(-1, -1);
                Vector2 delta3 = new Vector2(-2, 0);

                if (Parts[0].CanChangePos(delta0) &&
                Parts[2].CanChangePos(delta2) &&
                Parts[3].CanChangePos(delta3))
                {
                    state = 1;
                    Parts[0].ChangePos(delta0);
                    Parts[2].ChangePos(delta2);
                    Parts[3].ChangePos(delta3);
                }
            }
            else
            {
                Vector2 delta0 = new Vector2(-1, 1);
                Vector2 delta2 = new Vector2(1, 1);
                Vector2 delta3 = new Vector2(2, 0);

                if (Parts[0].CanChangePos(delta0) &&
                Parts[2].CanChangePos(delta2) &&
                Parts[3].CanChangePos(delta3))
                {
                    state = 0;
                    Parts[0].ChangePos(delta0);
                    Parts[2].ChangePos(delta2);
                    Parts[3].ChangePos(delta3);
                }
            }
        }
    }
}
