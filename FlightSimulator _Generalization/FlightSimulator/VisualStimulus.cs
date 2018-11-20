using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator
{
    class VisualStimulus
    {
        private int width,height;
   
        public VisualStimulus(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public float DegreeToValue(float degree)
        {
            return width / 2f + width / 360f * degree;

        }

        public Bitmap

    }
}
