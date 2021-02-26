using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        PlayingField field;
        Graphics g;
        Pen blackPen;
        Brush blackBrush;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            blackPen = new Pen(Color.Black);
            blackBrush = Brushes.Black;
            int width = 10;
            int height = 15;
            field = new PlayingField(width, height);
            Draw();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Draw()
        {
            Cell[,] cells = field.cells;
            foreach(Cell cell in cells)
            {
                g.FillRectangle(blackBrush, cell.X, cell.Y, PlayingField.CellSize, PlayingField.CellSize);
            }
        }
    }
}
