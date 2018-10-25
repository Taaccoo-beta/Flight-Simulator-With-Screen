using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Simulator
{
    class DrawTorque
    {
        private Graphics g1;

        private float widthCenter, heightCenter;

        private int width, height;
        private Color bc;
        Bitmap image1;


        public bool isTorque = true;

        //position number record
        int[] positionNumberRecord;
        private uint shortNumber = 1;
        int pnrLength;

        bool ifStartDebugModeForTorque = false;

        private List<bool> trainOrTest;


        public DrawTorque(int width, int height, Color bc)
        {
            this.widthCenter = width / 2;
            this.heightCenter = height / 2;
            this.width = width;
            this.height = height;


            pnrLength = (int)(width - 20);
            positionNumberRecord = new int[pnrLength];


            ///test positionNumber
            //for (int i = 0; i < pnrLength; i++)
            //{
            //    positionNumberRecord[i] = i;
            //}

            image1 = new Bitmap(width, height);
            g1 = Graphics.FromImage(image1);
            //使绘图质量最高，即消除锯齿  
            g1.SmoothingMode = SmoothingMode.AntiAlias;
            g1.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g1.CompositingQuality = CompositingQuality.HighQuality;
            g1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

        }


        //used painting funciton
        public Bitmap drawSignalCurve(List<float> lpf1)
        {

            g1.Clear(bc);

            int y = 90;
            // draw background
            Rectangle rect = new Rectangle(0, 0, width, height);
            g1.FillRectangle(new SolidBrush(Color.DarkCyan), rect);


            //draw axis
            g1.DrawRectangle(Pens.MidnightBlue, new Rectangle(60, 60, width - 100, height - 110));

            float intervale = (height - 110) / 10f;
            float intervalePosition = (height - 110) / 4f;
            float intervalePositionFor45 = (height - 110) / 8f;
            //for (int i = 1; i < 18; i++)
            //{
            //    g1.DrawLine(Pens.DarkBlue, 60, 60 + intervale * i, 80, 60 + intervale * i);
            //    g1.DrawString((256 * (i - 1)).ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), 10, 50 + intervale * i);
            //}
            //width 630 间隔 18， 35一道杠，从0加到256


            for (int i = 1; i < 10; i++)
            {
                // g1.DrawLine(Pens.DarkBlue, 60, 60 + intervale * i, 80, 60 + intervale * i);
                g1.DrawLine(Pens.DarkBlue, 60, intervale * i + 60, 65, intervale * i + 60);
            }

            g1.DrawString((0).ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), 20, 50 + intervale * 5);
            g1.DrawString((20).ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), 20, 50 + intervale * 3);
            g1.DrawString((40).ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), 20, 50 + intervale * 1);
            g1.DrawString((-20).ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), 20, 50 + intervale * 7);
            g1.DrawString((-40).ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), 20, 50 + intervale * 9);


            //darw position from 0 - 360 
            //左边坐标
            for (int i = 1; i < 4; i++)
            {
                // g1.DrawLine(Pens.DarkBlue, 60, 60 + intervale * i, 80, 60 + intervale * i);
                g1.DrawLine(Pens.DarkBlue, width - 45, intervalePosition * i + 60, width - 40, intervalePosition * i + 60);
            }
            Pen dashPen = new Pen(Color.DarkBlue);
            dashPen.DashStyle = DashStyle.DashDot;
            //g1.DrawLine(dashPen, 60, intervale * 5 + 60, width - 40, intervale * 5 + 60);
            g1.DrawLine(dashPen, 60, intervale * 5 + 60, width - 40, intervalePosition * 2 + 60);
            g1.DrawString((0).ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), width - 40, 50 + intervalePosition * 2);
            g1.DrawString((90).ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), width - 40, 50 + intervalePosition * 1);
            g1.DrawString((180).ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), width - 40, 50 + intervalePosition * 0);
            g1.DrawString((-90).ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), width - 40, 50 + intervalePosition * 3);
            g1.DrawString((-180).ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), width - 40, 50 + intervalePosition * 4);
            for (int i = 1; i < 8; i += 2)
            {
                // g1.DrawLine(Pens.DarkBlue, 60, 60 + intervale * i, 80, 60 + intervale * i);
                g1.DrawLine(Pens.DarkBlue, 60, intervalePositionFor45 * i + 60, width - 40, intervalePositionFor45 * i + 60);
            }

            //draw title
            //g1.DrawString("Position", new Font("Arial", 14), new SolidBrush(Color.Yellow), widthCenter-100, 10);            
            g1.DrawString(" Torque", new Font("Arial", 14), new SolidBrush(Color.Red), widthCenter - 20, 10);
            //g1.FillRectangle(new SolidBrush(Color.Yellow), widthCenter - 100, 10, 15, 10);


            //g1.DrawString(isPosition.ToString(), new Font("Arial", 12), new SolidBrush(Color.Green), 0, 10);

            //g1.DrawLine(Pens.Yellow, 10, 10, 200, 200);


            //+-50
            if (isTorque)
            {
                for (int i = 0; i < lpf1.Count - 1; i++)
                {
                    g1.DrawLine(Pens.Red, 65 + i, (height - 110) / 2f - (height - 110) / 100f * lpf1[i] + 60, 65 + i + 1, (height - 110) / 2f - (height - 110) / 100f * lpf1[i + 1] + 60);

                    //g1.DrawLine(Pens.Yellow, 10, 10, 200, 200);

                }

            }

            return image1;
        }





    }
}
