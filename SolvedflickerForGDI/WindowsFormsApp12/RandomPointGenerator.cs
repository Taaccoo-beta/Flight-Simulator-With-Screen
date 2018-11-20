using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visual_stimulus_generator
{
    class RandomPointGenerator
    {
        private int pointSize;
        private int barSize;

        private int width;
        private int height;

        private int pointWidth;
        private int pointHeight;

        private Graphics g;
        private Bitmap bm;
        public List<List<int>> randomCanvasBackground;

        public List<List<int>> barOne;
        public List<List<int>> barTwo;


        private int randomSeed = 0;

        public RandomPointGenerator(int width, int height, int pointSize, int barSize)
        {
            this.width = width;
            this.height = height;
            this.pointSize = pointSize;
            this.barSize = barSize;

            pointWidth = width / pointSize;
            pointHeight = height / pointSize;


            randomCanvasBackground = new List<List<int>>();
            barOne = new List<List<int>>();
            barTwo = new List<List<int>>();
            for (int i = 0; i != width; i++)
            {
                randomCanvasBackground.Add(new List<int>());
                for (int j = 0; j != height; j++)
                {
                    randomCanvasBackground[i].Add(0);
                }
            }

            for (int i = 0; i != barSize; i++)
            {
                barOne.Add(new List<int>());
                barTwo.Add(new List<int>());
                for (int j = 0; j != height; j++)
                {
                    barOne[i].Add(0);
                    barTwo[i].Add(0);
                }
            }

        }

        public void setRandomPoint(int rate)
        {
            Random rd = new Random();
            for (int i = 0; i != pointWidth; i++)
            {
                for (int j = 0; j != pointHeight; j++)
                {
                    int value = rd.Next(0, 100);
                    if (value < rate)
                    {

                        for (int ii = i * pointSize; ii != (i + 1) * pointSize; ii++)
                        {
                            for (int jj = j * pointSize; jj != (j + 1) * pointSize; jj++)
                            {


                                randomCanvasBackground[ii][jj] = 1;
                            }
                        }

                    }

                }
            }
        }


        public void MoveRightForSimpleCanvas(int step)
        {
            for (int i = 0; i != step; i++)
            {
                randomCanvasBackground.Insert(0, randomCanvasBackground[width - 1]);
                randomCanvasBackground.RemoveAt(randomCanvasBackground.Count - 1);
            }
        }


        public void MoveLeftForSimpleCanvas(int step)
        {
            for (int i = 0; i != step; i++)
            {
                randomCanvasBackground.Add(randomCanvasBackground[0]);
                randomCanvasBackground.Remove(randomCanvasBackground[0]);
            }
        }



    }
}
