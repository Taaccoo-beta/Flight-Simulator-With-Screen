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
using visual_stimulus_generator;


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
        byte[,] img = new byte[10,20];
        private RandomPointGenerator rg;
        private Generator gg;
        private void button1_Click(object sender, EventArgs e)
        {
            rg = new RandomPointGenerator(1024, 330, 1, 10);

            gg = new Generator(1024, 330);
            gg.SetSimpleCanvas();
            gg.setBigAndSmallStimulus();
            rg.setRandomPoint(50);

            timer1.Interval = 50;
            timer1.Start();
            
        }
        private int x = 0;
        private System.Diagnostics.Stopwatch sw;
        private void timer1_Tick(object sender, EventArgs e)
        {
            

            sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            //g2.Clear(Color.White);
            //for (int i = 0; i != Width; i++)
            //{
            //    for (int j = 0; j != Height; j++)
            //    {
            //        if (rg.randomCanvasBackground[i][j] == 0)
            //        {
            //            bm.SetPixel(i, j, Color.Black);

            //        }

            //    }
            //}
            //rg.MoveRightForSimpleCanvas(20);

            //x += 10;
            //if (x > Width)
            //{
            //    x = 0;
            //}
            //g2.Clear(Color.White);
            //g2.FillRectangle(new SolidBrush(Color.Black), x % Width, 0, Width / 2, this.Height);
            g2.Clear(Color.White);
            for (int i = 0; i != 1024; i++)
            {
                if (gg.simpleCanvas[i] == 1)
                {
                    g2.DrawLine(Pens.Black, i, 105, i, 225);
                }
            }
            //gg.MoveRightForSimpleCanvas(10);
            g2.DrawLine(Pens.Yellow, 256, 0, 256, 330);
            g2.DrawLine(Pens.Yellow, 512, 0, 512, 330);
            g2.DrawLine(Pens.Yellow, 768, 0, 768, 330);
            g2.DrawLine(Pens.Yellow, 1024, 0, 1024, 330);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            this.label1.Text = ts.Milliseconds.ToString();

            this.Refresh();
           

        }
        //sw = new System.Diagnostics.Stopwatch();
        //            sw.Start();



        //sw.Stop();
        //                TimeSpan ts = sw.Elapsed;
        //                this.lblShowFrameTime.Text = ts.Milliseconds.ToString();
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
