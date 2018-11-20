using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
    public partial class Form1 : Form
    {
        public Form1()
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

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 50;
            timer1.Start();
            
        }
        private int x = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            x += 10;
            if (x > Width)
            {
                x = 0;
            }
            g2.Clear(Color.White);
            g2.FillRectangle(new SolidBrush(Color.Black), x, 0, 20, this.Height);
            this.Refresh();
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
          //  e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            dc.DrawImage(bm, 0, 0);
            base.OnPaint(e);
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(Color.White);
            bm = new Bitmap(this.Width, this.Height);
            g2 = Graphics.FromImage(bm);
        }


    }
}
