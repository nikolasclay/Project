using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip.UI
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        public int timeLeft { get; private set; }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {

        }
        private void SplashScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            //the timer is now going to start
            timeLeft = 10;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
            }
            else
            {
                timer1.Stop();
                this.Hide();
            }
        }
    }
}
