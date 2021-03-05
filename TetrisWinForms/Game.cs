using System;
using System.Drawing;
using System.Windows.Forms;
using TetrisMechanics;

namespace TetrisWinForms
{
    public partial class Game : Form
    {
        private Controller controller;
        private Image cellImage;
        private Menu menuWindow;
        public Game(Menu menuWindow)
        {
            InitializeComponent();
            this.menuWindow = menuWindow;
            cellImage = Resources.Cell2;
            controller = new Controller();
            StepDown.Interval = controller.NormalStepSpeed;
            controller.GenerateNewFigure();
            controller.OnFigureBaked += Controller_OnFigureBaked;
            controller.OnDefeat += Controller_OnDefeat;
        }

        private void Controller_OnDefeat()
        {
            Close();
            MessageBox.Show($"Заработано очков: {controller.Score}\r\nДостигнут уровень: {controller.Level}", "Результаты");
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            menuWindow.Show();
        }

        private void Controller_OnFigureBaked()
        {
            StepDown.Interval = controller.NormalStepSpeed;

            controller.CheckDefeat();

            controller.CheckFilled();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            VisualUpdate(g);
        }

        private void VisualUpdate(Graphics g)
        {
            //DrawGrid(g);
            DrawField(g);
            DrawCurrentFigure(g);
            DrawStats(g);
        }

        private void DrawGrid(Graphics g)
        {
            Pen pen = Pens.Silver;
            int width = controller.Cells.GetLength(0);
            int height = controller.Cells.GetLength(1);
            int cellSize = WinFormAdapter.CELL_SIZE;
            for (int i = 1; i <= width; i++)
                g.DrawLine(pen, new Point(cellSize * i, 0), new Point(cellSize * i, cellSize * height));
            for (int j = 1; j <= height; j++)
                g.DrawLine(pen, new Point(0, cellSize * j), new Point(cellSize * width, cellSize * j));
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
                        g.DrawImage(cellImage, rect);
                    }
                }
            }
        }

        private void DrawCurrentFigure(Graphics g)
        {
            Figure currentFigure = controller.CurrentFigure;
            foreach (FigurePart part in currentFigure.Parts)
            {
                Rectangle rect = WinFormAdapter.GetRect(part.Pos.x, part.Pos.y);
                g.DrawImage(cellImage, rect);
            }
        }

        private void DrawStats(Graphics g)
        {
            Brush brush = Brushes.Black;
            g.DrawString($"Очки: {controller.Score}", new Font(FontFamily.GenericSansSerif.Name, 14), brush, 10, 10);
            g.DrawString($"Уровень сложности: {controller.Level}", new Font(FontFamily.GenericSansSerif.Name, 14), brush, 10, 50);
        }

        private void Refresher_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void StepDown_Tick(object sender, EventArgs e)
        {
            controller.ShiftCurrentFigure(Direction.Lower);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                controller.ShiftCurrentFigure(Direction.Righter);
            }
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                controller.ShiftCurrentFigure(Direction.Lefter);
            }
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                StepDown.Interval = controller.FasterStepSpeed;
            }
            else if (e.KeyCode == Keys.Space || e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                controller.RotateCurrentFigure();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                StepDown.Interval = controller.NormalStepSpeed;
            }
        }
    }
}
