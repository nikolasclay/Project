using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplashScreen
{
    public partial class ScreenSplash : Form
    {
        public ScreenSplash()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //use timer class
        Timer tmr;
        private void ScreenSplash_Shown(object sender, EventArgs e)
        {
            tmr = new Timer();
            //set time interval 3 sec
            tmr.Interval = 3000;
            //starts the timer
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            //after 3 seconds stop timer
            tmr.Stop();
            //display mainform
            Form f = new Form();
            f.Show();
            //hide this form
            this.Hide();
        }

        private void ScreenSplash_FormClosed(object sender, FormClosedEventArgs e)
        {
            //exit application when the form is closed
            Application.Exit();
        }
    }
}
