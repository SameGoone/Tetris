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
            States = new Vector2[2, 4];
            States[0, 1] = new Vector2(-1, -1);
            States[0, 2] = new Vector2(0, -1);
            States[0, 3] = new Vector2(1, 0);

            States[1, 1] = new Vector2(1, -1);
            States[1, 2] = new Vector2(1, 0);
            States[1, 3] = new Vector2(0, 1);

            InitializeParts(5, 1);
        }

        public override void Rotate()
        {
            if (state == 0)
            {
                SetState(1);
            }
            else
            {
                SetState(0);
            }
        }
    }
}
