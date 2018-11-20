using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightSimulator
{
    public partial class VisionFigure : Form
    {
        public VisionFigure()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();

        }
        Graphics g, g2;
        Bitmap bm;

        int degree = -45;
        int Ori = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            degree += Ori*2;
            if (degree > 45)
            {
                Ori = -1;
            }
            if (degree < -45)
            {
                Ori = 1;
            }
            g2.Clear(Color.White);
            int x = (int)(DegreeToValue(degree));
            g2.FillRectangle(new SolidBrush(Color.Black), x, 0, 20, this.Height);
            this.Refresh();
        }

        private void VisionFigure_Load(object sender, EventArgs e)
        {
            this.timer1.Interval = 50;
            g = this.CreateGraphics();
            g.Clear(Color.White);
            bm = new Bitmap(this.Width, this.Height);
            g2 = Graphics.FromImage(bm);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            dc.DrawImage(bm, 0, 0);
            base.OnPaint(e);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        public float DegreeToValue(float degree)
        {
            return Width / 2f + Width / 360f * degree;

        }




    }
}
