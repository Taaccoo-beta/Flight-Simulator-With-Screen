using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator
{
    class vStimulation
    {
        private Graphics g1;
        private Graphics g2;
        private float widthCenter, heightCenter;

        private int width, height;
        private Color bc;
        Bitmap image1, image2;
        private ushort stiNumber;
        public bool isPosition = true;
        public bool isTorque = true;

        public vStimulation(int width,int height,ushort stiNumber)
        {
            image1 = new Bitmap(width, height);
            g1 = Graphics.FromImage(image1);
            //使绘图质量最高，即消除锯齿  
            g1.SmoothingMode = SmoothingMode.AntiAlias;
            g1.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g1.CompositingQuality = CompositingQuality.HighQuality;
            g1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.width = width;
            this.height = height;
            this.stiNumber = stiNumber;
        }

        public void setWH(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public Bitmap DrawV_Test()
        {
            g1.Clear(bc);
          
            RectangleF rect = new RectangleF(0, 0, width, height);
            g1.FillRectangle(new SolidBrush(Color.DarkCyan), rect);
            g1.DrawLine(Pens.Blue, 10, 10, 200, 200);

            g1.FillRectangle(new SolidBrush(Color.Blue), 0, 0, 100, 100);

            return image1;

        }






    }
}
