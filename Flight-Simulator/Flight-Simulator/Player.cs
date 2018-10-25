using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flight_Simulator
{
    public partial class Player : Form
    {
        public Player()
        {
            InitializeComponent();
        }

        private void Player_Load(object sender, EventArgs e)
        {

        }

        public void Stop()
        {
            vlcControl1.SetMedia(new System.IO.FileInfo("d:/video/2.avi"));
            vlcControl1.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vlcControl1.SetMedia(new System.IO.FileInfo("d:/video/2.avi"));
            vlcControl1.Play();
        }
    }
}
