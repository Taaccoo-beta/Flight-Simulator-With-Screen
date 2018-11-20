using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator
{
    /// <summary>
    /// 计算PI值
    /// </summary>
    class PICalc
    {
        private List<List<float>> position = new List<List<float>>();
        private List<List<float>> troque = new List<List<float>>();
        private List<float> PIValue = new List<float>();
        private List<float> pos = new List<float>();
        private List<float> tro = new List<float>();

        private bool isTpunishment;
        public PICalc(List<List<float>> position, List<List<float>> troque,bool isTpunishment)
        {
            this.position = position;
            this.troque = troque;
            this.isTpunishment = isTpunishment;

        }

        public PICalc(List<float> position, List<float> troque, bool isTpunishment)
        {
            pos = position;
            tro = troque;
            this.isTpunishment = isTpunishment;
        }

        public float getSiglePIValue()
        {
            int indexT = 0;
            int indexInverseT = 0;
            for (int j = 0; j != pos.Count; j++)
            {
                if (getPIPosition(pos[j]))
                {
                    indexT++;
                }
                else
                {
                    indexInverseT++;
                }

            }

            float PIValueNow;
            if (isTpunishment)
            {
                PIValueNow = (float)(indexInverseT - indexT) / (float)(indexT + indexInverseT);
            }
            else
            {
                PIValueNow = (float)(indexT - indexInverseT) / (float)(indexT + indexInverseT);
            }

            


            return PIValueNow;
        }

        /// <summary>
        /// 计算并返回PI值
        /// </summary>
        /// <returns></returns>
        public List<float> getPIValue()
        {

            for (int i = 0; i != position.Count; i++)
            {
                int indexT = 0;
                int indexInverseT = 0;
                for (int j = 0; j != position[i].Count; j++)
                {
                    if (getPIPosition(position[i][j]))
                    {
                        indexT++;
                    }
                    else
                    {
                        indexInverseT++;
                    }
                   
                }

                float PIValueNow;
                if (isTpunishment)
                {
                    PIValueNow = (float)(indexInverseT - indexT) / (float)(indexT + indexInverseT);
                }
                else
                {
                    PIValueNow = (float)(indexT - indexInverseT) / (float)(indexT + indexInverseT);
                }

                PIValue.Add(PIValueNow);

            }
            return PIValue;
        }

        /// <summary>
        /// 获取当前位置属于哪个区域
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool getPIPosition(float value)
        {
            
                if ((value > 1470 & value < 1982) || (value > 2494 || value < 976))
                {
                    return true;
                }
                else
                {
                    return false;
                }
           
        }

       

    }
}
