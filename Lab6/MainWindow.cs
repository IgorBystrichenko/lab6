using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Play_Click(object sender, EventArgs e)
        {
            GameWindow gw = new GameWindow();
            gw.Closed += Exit_Click;
            gw.FormBorderStyle = FormBorderStyle.FixedSingle;
            gw.Owner = this;
            gw.Show();
            this.Hide();
        }

        private void Rules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Игроки ходят по очереди." +
                            "\nПервый игрок выкладывет любую карту," +
                            "\nдругие должны выкладывать карту этой же масти." +
                            "\nВыигрывает раунд тот игрок, который выложил наибольшую карту данной масти" +
                            "\nЕсли карты данной масти нет, то игрок выкладывает любую" +
                            "\nПри этом он автоматически проигрывает раунд.");
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
