using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public abstract class Figure
    {
        public FigurePart[] Parts { get; protected set; }

        public void Lower()
        {
            bool allPartsCanLower = CheckAllPartsCanLower();
            if (allPartsCanLower)
            {
                foreach (FigurePart part in Parts)
                    part.Lower();
            }
            else
                Bake();
        }

        private bool CheckAllPartsCanLower()
        {
            bool canLower = true;
            foreach (FigurePart part in Parts)
            {
                if (!part.CanLower)
                {
                    canLower = false;
                    break;
                }
            }
            return canLower;
        }

        public abstract void Rotate();

        private void Bake()
        {
            foreach (FigurePart part in Parts)
            {
                bool[,] cells = Controller.PlayingField.Cells;
                cells[part.X, part.Y] = true;
            }
            Controller.GenerateFigure();
        }
    }
}
