using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisWinForms
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            Game gameWindow = new Game(this);
            gameWindow.Show();
            Hide();
        }

        private void Rules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Управление: \r\n A/Стрелка влево - влево \r\n D/Стрелка право - вправо \r\n S/Стрелка вниз - ускорить падение фигуры \r\n W/Стрелка вверх - поворот фигуры");
        }
    }
}
