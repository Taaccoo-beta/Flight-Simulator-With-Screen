using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rorationSimulation
{
    class drawProcess
    {

        private Graphics g1;
        private Graphics g2;
        private float widthCenter, heightCenter;
        
        private int width, height;
        private Color bc;
        Bitmap image1,image2;

        public bool isPosition=true;
        public bool isTorque=true;

        //position number record
        int[] positionNumberRecord;
        private uint shortNumber = 1;
        int pnrLength;

        bool ifStartDebugModeForTorque = false;

        private List<bool> trainOrTest;
        

        public drawProcess(int width, int height, Color bc)
        {
            this.widthCenter = width / 2;
            this.heightCenter = height / 2;
            this.width = width;
            this.height = height;


            pnrLength = (int)(width - 20);
            positionNumberRecord = new int[pnrLength];

            this.trainOrTest = trainOrTest;

            shortNumber = 1;
            
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



            //使绘图质量最高，即消除锯齿  
            image2 = new Bitmap(width, height);
            g2 = Graphics.FromImage(image2);
            g2.SmoothingMode = SmoothingMode.AntiAlias;
            g2.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g2.CompositingQuality = CompositingQuality.HighQuality;
            g2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;


            
        }


        public void getTrainOrTestSequence(List<bool> trainOrTest)
        {
            this.trainOrTest = trainOrTest;
        }
        //positionTransform
        private void positionTransform(float number)
        {

            

            float interval = 2048f / (float)pnrLength;

            if (number > 2718)
            {
                number = 2718;
            }
            if (number < 702)
            {
                number = 702;
            }
            int index = (int)((number-702) / interval);

            
            positionNumberRecord[index]++;
            if (positionNumberRecord[index]/shortNumber > 300)
            {
                shortNumber++;
            }

            
        }

        public void clearCommunitivePosition()
        {
            for (int i = 0; i != positionNumberRecord.Length; i++)
            {
                positionNumberRecord[i] = 0;
            }
        }
        

        public Bitmap drawPosition(float torque)
        {
            g2.Clear(bc);
            int widthHere = width;
            int heightHere = height - 100;
            RectangleF rect = new RectangleF(0, 0, widthHere, heightHere);
            g2.FillRectangle(new SolidBrush(Color.DarkCyan), rect);

            //draw two borders
            g2.DrawRectangle(Pens.MidnightBlue, new Rectangle(10,5, widthHere/2-20, heightHere - 30));
            g2.DrawRectangle(Pens.MidnightBlue, new Rectangle(widthHere / 2 + 5, 5, widthHere/2-20, heightHere - 30));


            
            //draw axis
            Pen dashPen = new Pen(Color.DarkBlue);
            dashPen.DashStyle = DashStyle.DashDot;
            for (int i = 1; i < 4; i++)
            {
                g2.DrawLine(dashPen, (widthHere / 2 - 20) / 4 * i + 10, heightHere - 25, (widthHere / 2 - 20) / 4 * i + 10, 5);

                g2.DrawLine(dashPen, (widthHere / 2 - 20) / 4 * i + width / 2 + 10, heightHere - 25, (widthHere / 2 - 20) / 4 * i + width / 2 + 10, 5);

            }

            for (int i = 0; i < 4; i++)
            {
                if (i % 2 == 0)
                {
                    g2.DrawString("P", new Font("Arial", 12), new SolidBrush(Color.Black), 40 + (widthHere / 2 - 20) / 4 * i, heightHere - 20);
                    g2.DrawString("P", new Font("Arial", 12), new SolidBrush(Color.Black), widthHere/2+50 + (widthHere / 2 - 20) / 4 * i, heightHere - 20);

                }
                else
                {
                    g2.DrawString("N", new Font("Arial", 12), new SolidBrush(Color.Black), 40 + (widthHere / 2 - 20) / 4 * i, heightHere - 20);
                    g2.DrawString("N", new Font("Arial", 12), new SolidBrush(Color.Black), widthHere / 2 + 50 + (widthHere / 2 - 20) / 4 * i, heightHere - 20);
                }
                
            }

            positionTransform(torque);
            //draw commulative position points
            int positionDrawHeightLimit = (int)(heightHere - 30);

            for (int i = 0; i < pnrLength; i++)
            {
                g2.DrawLine(Pens.Red,10+i,heightHere-26,10+i,heightHere-26-positionNumberRecord[i]);
            }



            return image2;

        }


        public Bitmap drawCommunitivePoint(float position,bool debugMode,int sequenceForExperiment)
        {
            g2.Clear(bc);
            int widthHere = width;
            int heightHere = height;
            Rectangle rect = new Rectangle(0, 0, widthHere, heightHere);
            g2.FillRectangle(new SolidBrush(Color.DarkCyan), rect);

            //draw two borders
            g2.DrawRectangle(Pens.MidnightBlue, new Rectangle(10, 5, widthHere - 20, heightHere - 10));
            float intervalForXAxis = (widthHere-20) / 4;


            //draw axis
            Pen dashPen = new Pen(Color.DarkBlue);
            dashPen.DashStyle = DashStyle.DashDot; 
            g2.DrawLine(dashPen, intervalForXAxis / 2 + 10, 5, intervalForXAxis / 2 + 10, heightHere - 5);
            g2.DrawLine(dashPen, 3*intervalForXAxis / 2 + 10, 5, 3*intervalForXAxis / 2 + 10, heightHere - 5);
            g2.DrawLine(dashPen, 5*intervalForXAxis / 2 + 10, 5, 5*intervalForXAxis / 2 + 10, heightHere - 5);
            g2.DrawLine(dashPen, 7*intervalForXAxis / 2 + 10, 5, 7*intervalForXAxis / 2 + 10, heightHere - 5);
           



            //draw T signs
            //g2.DrawRectangle(Pens.Yellow, new Rectangle(30, 5, 5, 3));
            g2.FillRectangle(new SolidBrush(Color.Yellow), new Rectangle(20 , 8, 12, 5));
            g2.FillRectangle(new SolidBrush(Color.Yellow), new Rectangle(18, 8, 5, 16));

            g2.FillRectangle(new SolidBrush(Color.Yellow), new RectangleF(2+2*intervalForXAxis, 8, 16, 5));
            g2.FillRectangle(new SolidBrush(Color.Yellow), new RectangleF(8+2*intervalForXAxis, 10, 5, 16));

            g2.FillRectangle(new SolidBrush(Color.Red), new RectangleF(2 + 1 * intervalForXAxis, 24, 16, 5));
            g2.FillRectangle(new SolidBrush(Color.Red), new RectangleF(8 + 1 * intervalForXAxis, 10, 5, 15));

            g2.FillRectangle(new SolidBrush(Color.Red), new RectangleF(2 + 3 * intervalForXAxis, 24, 16, 5));
            g2.FillRectangle(new SolidBrush(Color.Red), new RectangleF(8 + 3 * intervalForXAxis, 10, 5, 15));

            g2.FillRectangle(new SolidBrush(Color.Yellow), new RectangleF(-10+8*intervalForXAxis/2, 8, 12, 5));
            g2.FillRectangle(new SolidBrush(Color.Yellow), new RectangleF(-1+8*intervalForXAxis/2, 8, 5, 16));

            

            if (sequenceForExperiment!=trainOrTest.Count)
            { if (trainOrTest[sequenceForExperiment])
                {
                    g2.DrawString("Train: " + (sequenceForExperiment + 1).ToString(), new Font("Arial", 15), new SolidBrush(Color.LightGray), 30, 20);
                }
                else
                {
                    g2.DrawString(" Test: " + (sequenceForExperiment + 1).ToString(), new Font("Arial", 15), new SolidBrush(Color.LightGray), 30, 20);
                }
            }
            


            

        
            
            positionTransform(position);
            
            
            ////draw commulative position points
            int positionDrawHeightLimit = (int)(heightHere - 30);

            for (int i = 0; i < pnrLength; i++)
            {

                int value = positionNumberRecord[i];
                if (value != 0)
                {
                    if (i == 0)
                    {
                        g2.DrawLine(Pens.Yellow, 10 + i, heightHere - 6, 10 + i, heightHere - 4 - (positionNumberRecord[i] / shortNumber));
                        g2.DrawLine(Pens.Yellow, 10 + i + 1, heightHere - 6, 10 + i + 1, heightHere - 4 - (positionNumberRecord[i] / shortNumber));
                        g2.DrawLine(Pens.Yellow, 10 + i + 2, heightHere - 6, 10 + i + 2, heightHere - 4 - (positionNumberRecord[i] / shortNumber));
                        g2.DrawLine(Pens.Yellow, 10 + i + 3, heightHere - 6, 10 + i + 3, heightHere - 4 - (positionNumberRecord[i] / shortNumber));
                        g2.DrawLine(Pens.Yellow, 10 + i + 4, heightHere - 6, 10 + i + 4, heightHere - 4 - (positionNumberRecord[i] / shortNumber));
                    }
                    else if (i == pnrLength-1)
                    {
                        g2.DrawLine(Pens.Yellow, 10 + i, heightHere - 6, 10 + i, heightHere - 4 - (positionNumberRecord[i] / shortNumber));
                        g2.DrawLine(Pens.Yellow, 10 + i - 1, heightHere - 6, 10 + i - 1, heightHere - 4 - (positionNumberRecord[i] / shortNumber));
                        g2.DrawLine(Pens.Yellow, 10 + i - 2, heightHere - 6, 10 + i - 2, heightHere - 4 - (positionNumberRecord[i] / shortNumber));
                        g2.DrawLine(Pens.Yellow, 10 + i - 3, heightHere - 6, 10 + i - 3, heightHere - 4 - (positionNumberRecord[i] / shortNumber));
                        g2.DrawLine(Pens.Yellow, 10 + i - 4, heightHere - 6, 10 + i - 4, heightHere - 4 - (positionNumberRecord[i] / shortNumber));
                    }
                    else
                    {
                        g2.DrawLine(Pens.Yellow, 10 + i, heightHere - 6, 10 + i, heightHere - 4 - (positionNumberRecord[i] / shortNumber));
                        g2.DrawLine(Pens.Yellow, 10 + i - 1, heightHere - 6, 10 + i - 1, heightHere - 4 - (positionNumberRecord[i] / shortNumber));
                        g2.DrawLine(Pens.Yellow, 10 + i + 1, heightHere - 6, 10 + i + 1, heightHere - 4 - (positionNumberRecord[i] / shortNumber));
                        g2.DrawLine(Pens.Yellow, 10 + i - 2, heightHere - 6, 10 + i - 2, heightHere - 4 - (positionNumberRecord[i] / shortNumber));
                        g2.DrawLine(Pens.Yellow, 10 + i + 2, heightHere - 6, 10 + i + 2, heightHere - 4 - (positionNumberRecord[i] / shortNumber));
                    }
                    
                }

            }



            return image2;
        }

        

        public Bitmap drawSignalCurve(List<float> lpf1,List<float> lpf2)
        {

            g1.Clear(bc);
           
            int y = 90;
            // draw background
            Rectangle rect = new Rectangle(0,0, width, height);
            g1.FillRectangle(new SolidBrush(Color.DarkCyan), rect);


            //draw axis
            g1.DrawRectangle(Pens.MidnightBlue, new Rectangle(60, 60, width - 100, height - 80));

            float intervale = (height - 80) / 10f;
            float intervalePosition = (height - 80) / 4f;
            float intervalePositionFor45 = (height - 80) / 8f;
            //for (int i = 1; i < 18; i++)
            //{
            //    g1.DrawLine(Pens.DarkBlue, 60, 60 + intervale * i, 80, 60 + intervale * i);
            //    g1.DrawString((256 * (i - 1)).ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), 10, 50 + intervale * i);
            //}
            //width 630 间隔 18， 35一道杠，从0加到256


            //左边坐标短线
            for (int i = 1; i < 10; i++)
            {
                // g1.DrawLine(Pens.DarkBlue, 60, 60 + intervale * i, 80, 60 + intervale * i);
                g1.DrawLine(Pens.DarkBlue, 60, intervale* i+60, 65, intervale * i+60);
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
                g1.DrawLine(Pens.DarkBlue, width-45, intervalePosition * i + 60, width-40, intervalePosition * i + 60);
            }
            Pen dashPen = new Pen(Color.DarkBlue);
            dashPen.DashStyle = DashStyle.DashDot;
            //g1.DrawLine(dashPen, 60, intervale * 5 + 60, width - 40, intervale * 5 + 60);
            g1.DrawLine(dashPen, 60, intervale * 5 + 60, width - 40, intervalePosition * 2 + 60);
            g1.DrawString((0).ToString(), new Font("Arial", 10), new SolidBrush(Color.Black), width-40, 50 + intervalePosition * 2);
            g1.DrawString((90).ToString(), new Font("Arial", 10), new SolidBrush(Color.Black), width - 40, 50 + intervalePosition * 1);
            g1.DrawString((180).ToString(), new Font("Arial", 10), new SolidBrush(Color.Black), width - 40, 50 + intervalePosition * 0);
            g1.DrawString((-90).ToString(), new Font("Arial", 10), new SolidBrush(Color.Black), width - 40, 50 + intervalePosition * 3);
            g1.DrawString((-180).ToString(), new Font("Arial", 10), new SolidBrush(Color.Black), width - 40, 50 + intervalePosition * 4);
            for (int i = 1; i < 8; i+=2)
            {
                // g1.DrawLine(Pens.DarkBlue, 60, 60 + intervale * i, 80, 60 + intervale * i);
                g1.DrawLine(Pens.DarkBlue,  60, intervalePositionFor45 * i + 60, width - 40, intervalePositionFor45 * i + 60);
            }

            //draw title
            g1.DrawString("Position", new Font("Arial", 10), new SolidBrush(Color.Yellow), widthCenter-100, 10);            
            g1.DrawString(" Torque", new Font("Arial", 10), new SolidBrush(Color.Red), widthCenter - 20, 10);
            //g1.FillRectangle(new SolidBrush(Color.Yellow), widthCenter - 100, 10, 15, 10);


            //g1.DrawString(isPosition.ToString(), new Font("Arial", 12), new SolidBrush(Color.Green), 0, 10);

            if (isPosition)
            {
                for (int i = 0; i < lpf1.Count - 1; i++)
                {

                    if (Math.Abs(lpf1[i] - lpf1[i + 1]) < 1000)
                    {
                        g1.DrawLine(Pens.Yellow, 65 + i, (lpf1[i] - 702) * (height - 80) / 2048f + 60, 65 + i + 1, (lpf1[i + 1] - 702) * (height - 80) / 2048f + 60);
                    }
                    
                }

            }

            if (isTorque)
            {
                for (int i = 0; i < lpf2.Count - 1; i++)
                {
                    g1.DrawLine(Pens.Red, 65 + i, (lpf2[i] - 65) * (height - 110) / (2797) + 60, 65 + i + 1, (lpf2[i + 1] - 65) * (height - 110) / (2797) + 60);
                }

            }

            return image1;
        }



        public Bitmap drawSignalCurveForReplay(List<float> lpf1, List<float> lpf2)
        {

            g1.Clear(bc);

            int y = 90;
            // draw background
            Rectangle rect = new Rectangle(0, 0, width, height);
            g1.FillRectangle(new SolidBrush(Color.DarkCyan), rect);


            //draw axis
            g1.DrawRectangle(Pens.MidnightBlue, new Rectangle(60, 60, width - 100, height - 110));

            int intervale = (height - 110) / 10;
            int intervalePosition = (height - 110) / 4;
            int intervalePositionFor45 = (height - 110) / 8;
            //for (int i = 1; i < 18; i++)
            //{
            //    g1.DrawLine(Pens.DarkBlue, 60, 60 + intervale * i, 80, 60 + intervale * i);
            //    g1.DrawString((256 * (i - 1)).ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), 10, 50 + intervale * i);
            //}
            //width 630 间隔 18， 35一道杠，从0加到256


            for (int i = 0; i < 10; i++)
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
            for (int i = 1; i < 4; i++)
            {
                // g1.DrawLine(Pens.DarkBlue, 60, 60 + intervale * i, 80, 60 + intervale * i);
                g1.DrawLine(Pens.DarkBlue, width - 45, intervalePosition * i + 60, width - 40, intervalePosition * i + 60);
            }
            Pen dashPen = new Pen(Color.DarkBlue);
            dashPen.DashStyle = DashStyle.DashDot;
            g1.DrawLine(dashPen, 60, intervale * 5 + 60, width - 40, intervale * 5 + 60);
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

            g1.DrawString("Yellow(Position)   Red(Torque)", new Font("Arial", 14), new SolidBrush(Color.White), widthCenter - 100, 10);

            //g1.DrawString(isPosition.ToString(), new Font("Arial", 12), new SolidBrush(Color.Green), 0, 10);

            if (isPosition)
            {
                for (int i = 0; i < lpf1.Count - 1; i++)
                {

                    if (Math.Abs(lpf1[i] - lpf1[i + 1]) < 1000)
                    {
                        g1.DrawLine(Pens.Yellow, 65 + i, (lpf1[i] - 720) * (height - 110) / 2048 + 60, 65 + i + 1, (lpf1[i + 1] - 720) * (height - 110) / 2048 + 60);
                    }

                }

            }

            if (isTorque)
            {
                for (int i = 0; i < lpf2.Count - 1; i++)
                {
                    g1.DrawLine(Pens.Red, 65 + i, (lpf2[i] - 65) * (height - 110) / (2797) + 60, 65 + i + 1, (lpf2[i + 1] - 65) * (height - 110) / (2797) + 60);
                }

            }

            return image1;
        }

    }
}
