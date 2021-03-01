using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        private Random r = new Random();
        private Controller controller;
        public Form1()
        {
            InitializeComponent();
            controller = new Controller();
            StepDown.Interval = controller.NormalTimeBetweenSteps;
            controller.GenerateFigure();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            VisualUpdate(g);
        }

        private void VisualUpdate(Graphics g)
        {
            DrawField(g);
            DrawCurrentFigure(g);
        }

        private void DrawField(Graphics g)
        {
            bool[,] cells = controller.Cells;
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
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

        private void DrawCurrentFigure(Graphics g)
        {
            Figure currentFigure = controller.CurrentFigure;
            foreach (FigurePart part in currentFigure.Parts)
            {
                Brush brush = Brushes.Black;
                Rectangle rect = WinFormAdapter.GetRect(part.X, part.Y);
                g.FillRectangle(brush, rect);
                g.DrawString($"Очки: {controller.Score}", new Font(FontFamily.GenericSansSerif.Name, 14), brush, 10, 10);
            }
        }


        private void Refresher_Tick(object sender, EventArgs e)
        {
            Invalidate();
            if (controller.CheckDefeat())
            {
                Close();
            }

            controller.CheckFilled();
        }

        private void StepDown_Tick(object sender, EventArgs e)
        {
            controller.ShiftCurrentFigure(Direction.Lower);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                controller.ShiftCurrentFigure(Direction.Righter);
            }
            else if (e.KeyCode == Keys.A)
            {
                controller.ShiftCurrentFigure(Direction.Lefter);
            }
            else if (e.KeyCode == Keys.S)
            {
                StepDown.Interval = controller.FastTimeBetweenSteps;
            }
            else if (e.KeyCode == Keys.Space)
            {
                controller.RotateCurrentFigure();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                StepDown.Interval = controller.NormalTimeBetweenSteps;
            }
        }
    }
}
