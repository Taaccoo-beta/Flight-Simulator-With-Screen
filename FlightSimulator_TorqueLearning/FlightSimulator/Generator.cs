using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visual_stimulus_generator
{
    class Generator
    {
        public List<List<int>> complexCanvas;
        public List<int> simpleCanvas;
        private int width;
        private int height;

        //image rectangle
        public Generator(int width,int height)
        {
            this.width = width;
            this.height = height;

         
        }

        public void SetSimpleCanvas()
        {
            simpleCanvas = new List<int>();
            for (int i = 0; i != width; i++)
            {
                simpleCanvas.Add(0);
            }

        }

        public void ClearListForSimpleCanvas()
        {
            for(int i = 0; i!=width;i++)
            {
                simpleCanvas[i] = 0;

            }
        }

        public void SetSimpleCanvasPosition(float degree)
        {
            if (degree <= 0)
            {
                //degree to pixel
                int stepForReal = DegreeToWidth(-degree);
                MoveLeftForSimpleCanvas(stepForReal);
            }
            if (degree > 0)
            {
                //degree to pixel
                int stepForReal = DegreeToWidth(degree);
                MoveRightForSimpleCanvas(stepForReal);
            }
        }


        public void MoveRightForSimpleCanvas(int step)
        {
            for (int i = 0; i != step; i++)
            {
                simpleCanvas.Insert(0, simpleCanvas[width - 1]);
                simpleCanvas.RemoveAt(simpleCanvas.Count - 1);
            }
        }


        public void MoveLeftForSimpleCanvas(int step)
        {
            for (int i = 0; i != step; i++)
            {
                simpleCanvas.Add(simpleCanvas[0]);
                simpleCanvas.Remove(simpleCanvas[0]);
            }
        }


        
        public int DegreeToWidth(float degree)
        {
            return (int)(degree / 360f * width);
        }

        public int DegreeToPosition(float degree)
        {
            return (int)(degree / 360f * width + width / 2f);

            //-180 to 180   ---> 0 to width
        }



        public void setBigAndSmallStimulus()
        {
            
            for (int i = 67; i != 187; i++)
            {
                simpleCanvas[i] = 1;
            }
            for (int i = 263; i != 503; i++)
            {
                simpleCanvas[i] = 1;
            }
            for (int i = 579; i != 700; i++)
            {
                simpleCanvas[i] = 1;
            }
            for (int i = 776; i != 1016; i++)
            {
                simpleCanvas[i] = 1;
            }


        }
        
    }
}
