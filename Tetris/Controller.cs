using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Controller
    {
        public const int WIDTH = 10;
        public const int HEIGHT = 15;
        public static PlayingField PlayingField;
        public static Figure CurrentFigure;

        public static void GenerateFigure()
        {
            CurrentFigure = new Square();
        }

    }
}
