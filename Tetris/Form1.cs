using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        private Random r = new Random();
        private PlayingField field;
        public Form1()
        {
            InitializeComponent();

            field = new PlayingField(Controller.WIDTH, Controller.HEIGHT);
            Controller.PlayingField = field;

            Controller.GenerateFigure();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            VisualUpdate(g);
        }

        private void VisualUpdate(Graphics g)
        {
            DrawField(g);
            DrawActiveFigure(g);
        }

        private void DrawField(Graphics g)
        {
            bool[,] cells = field.Cells;
            for (int i = 0; i < Controller.WIDTH; i++)
            {
                for (int j = 0; j < Controller.HEIGHT; j++)
                {
                    bool cell = cells[i, j];
                    if (cell) // если закрашена
                    {
                        Rectangle rect = WinFormAdapter.GetRect(i, j);
                        g.FillRectangle(Brushes.Black, rect);
                    }
                }
            }
        }

        private void DrawActiveFigure(Graphics g)
        {
            foreach (FigurePart part in Controller.CurrentFigure.Parts)
            {
                Brush brush = Brushes.Black;
                Rectangle rect = WinFormAdapter.GetRect(part.X, part.Y);
                g.FillRectangle(brush, rect);
                g.DrawString($"Очки: {Controller.Score}", new Font(FontFamily.GenericSansSerif.Name, 14), brush, 10, 10);
            }
        }


        private void Refresher_Tick(object sender, EventArgs e)
        {
            Invalidate();
            if (Controller.CheckDefeat())
            {
                Close();
            }

            Controller.CheckLine();
        }

        private void StepDown_Tick(object sender, EventArgs e)
        {
            Controller.CurrentFigure.Lower();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                Controller.CurrentFigure.Righter();
            }
            else if (e.KeyCode == Keys.A)
            {
                Controller.CurrentFigure.Lefter();
            }
            else if (e.KeyCode == Keys.S)
            {
                StepDown.Interval = 20;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                StepDown.Interval = 1000;
            }
        }
    }
}
