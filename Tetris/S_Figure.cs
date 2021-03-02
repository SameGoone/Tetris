﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class S_Figure : Figure
    {
        public S_Figure()
        {
            Parts = new FigurePart[4];
            Parts[0] = new FigurePart(6, 0);
            Parts[1] = new FigurePart(5, 0);
            Parts[2] = new FigurePart(5, 1);
            Parts[3] = new FigurePart(4, 1);
        }

        public override void Rotate()
        {
            if (state == 0)
            {
                Vector2 delta0 = new Vector2(-1, 1);
                Vector2 delta2 = new Vector2(-1, -1);
                Vector2 delta3 = new Vector2(0, -2);

                if (CheckAllPartsCanRotate(delta0, delta2, delta3))
                {
                    state = 1;
                    RotateAllParts(delta0, delta2, delta3);
                }
            }
            else
            {
                Vector2 delta0 = new Vector2(1, -1);
                Vector2 delta2 = new Vector2(1, 1);
                Vector2 delta3 = new Vector2(0, 2);

                if (CheckAllPartsCanRotate(delta0, delta2, delta3))
                {
                    state = 0;
                    RotateAllParts(delta0, delta2, delta3);
                }
            }
        }
    }
}
