using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class J_Figure : Figure
    {
        public J_Figure()
        {
            States = new Vector2[4, 4];
            States[0, 1] = new Vector2(0, -1);
            States[0, 2] = new Vector2(0, 1);
            States[0, 3] = new Vector2(-1, 1);

            States[1, 1] = new Vector2(1, 0);
            States[1, 2] = new Vector2(-1, 0);
            States[1, 3] = new Vector2(-1, -1);

            States[2, 1] = new Vector2(0, 1);
            States[2, 2] = new Vector2(-0, -1);
            States[2, 3] = new Vector2(1, -1);

            States[3, 1] = new Vector2(-1, 0);
            States[3, 2] = new Vector2(1, 0);
            States[3, 3] = new Vector2(1, 1);

            InitializeParts(6, 1);
        }

        public override void Rotate()
        {
            if (state == 0)
            {
                SetState(1);
            }
            else if (state == 1)
            {
                SetState(2);
            }
            else if (state == 2)
            {
                SetState(3);
            }
            else
            {
                SetState(0);
            }
        }
    }
}
