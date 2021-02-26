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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int width = 10;
            int height = 15;
            PlayingField field = new PlayingField(width, height);
            Cell[,] cells = field.cells;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    textBox1.Text += $"Ячейка({i}, {j}):{cells[i, j].X}, {cells[i, j].Y}\r\n";
                }
            }
        }
    }
}
