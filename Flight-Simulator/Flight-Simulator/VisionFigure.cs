using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;



namespace Flight_Simulator
{
    public partial class VisionFigure : Form
    {
        public VisionFigure()
        {
            InitializeComponent();
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {

        }

        private RandomPoint rp;
        private void VisionFigure_Load(object sender, EventArgs e)
        {
            
        }

        public void SetRandomPoint()
        {
            rp = new RandomPoint(this.pbCanvas.Width, this.pbCanvas.Height);
            rp.setBarSize(8);
            rp.setPointSize(12);
        }


        public Bitmap getImageBarAndBackGround(float degree)
        {
            //Bitmap b = (Bitmap)rp.getBitmapForBar(degree).Clone();
            Bitmap b = (Bitmap)rp.getBitmapForBackground(degree).Clone();

            return b;
        }

        public Bitmap getImageSingleBar(float degree)
        {
            //Bitmap b = (Bitmap)rp.getBitmapForBar(degree).Clone();
            Bitmap b = (Bitmap)rp.getBitmapForBar(degree).Clone();

            return b;
        }
        public Bitmap getImageBackGround(float degree)
        {
            //Bitmap b = (Bitmap)rp.getBitmapForBar(degree).Clone();
            Bitmap b = (Bitmap)rp.getBitmapBackgroundMBarStop(degree).Clone();

            return b;
        }

        public Bitmap getBlackBarWhiteBackground(float degree)
        {
            //Bitmap b = (Bitmap)rp.getBitmapForBar(degree).Clone();
            Bitmap b = (Bitmap)rp.getBlackBar(degree).Clone();

            return b;
        }

        private void VisionFigure_Load_1(object sender, EventArgs e)
        {

        }
    }
}
