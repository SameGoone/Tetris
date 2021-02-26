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
        Random r = new Random();
        PlayingField field;
        Graphics g;
        Bitmap canvas;
        public Form1()
        {
            InitializeComponent();

            SetFormSize();

            field = new PlayingField(Controller.WIDTH, Controller.HEIGHT);
            Controller.PlayingField = field;

            Controller.GenerateFigure();

            panel1.BackgroundImage = canvas;
            VisualUpdate();
        }

        private void SetFormSize()
        {
            Size formSize = new Size(Controller.WIDTH * WinFormAdapter.CellSize,
                                     Controller.HEIGHT * WinFormAdapter.CellSize);
            this.Size = formSize;
            panel1.Size = formSize;
            canvas = new Bitmap(formSize.Width, formSize.Height);
        }

        private void DrawField()
        {
            bool[,] cells = field.Cells;
            for (int i = 0; i < Controller.WIDTH; i++)
            {
                for (int j = 0; j < Controller.HEIGHT; j++)
                {
                    bool cell = cells[i, j];
                    Brush brush = cell ? Brushes.Black : Brushes.Yellow;
                    Rectangle rect = WinFormAdapter.GetRect(i, j);
                    g.FillRectangle(brush, rect);
                }
            }
        }
        
        private void DrawActiveFigure()
        {
            string coords = "";
            foreach(FigurePart part in Controller.CurrentFigure.Parts)
            {
                Brush brush = Brushes.Black;
                Rectangle rect = WinFormAdapter.GetRect(part.X, part.Y);
                coords += $"{part.X}, {part.Y}";
                g.FillRectangle(brush, rect);
                g.DrawString(coords, new Font(FontFamily.GenericSansSerif.Name, 14), brush, 10, 10);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Controller.CurrentFigure.Lower();
            VisualUpdate();
        }

        private void VisualUpdate()
        {
            g.Clear(Color.White);
            DrawField();
            DrawActiveFigure();
            g.DrawLine(Pens.Black, new Point(r.Next(10, 20), r.Next(10, 20)), new Point(r.Next(100, 200), r.Next(100, 200)));
            Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
        }
    }
}
