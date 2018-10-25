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

        private List<float> singlePosition = new List<float>();
        private List<float> singleTroque = new List<float>();
        private List<float> PIValue = new List<float>();
        private bool isTpunishment;
        public PICalc(List<List<float>> position, List<List<float>> troque,bool isTpunishment)
        {
            this.position = position;
            this.troque = troque;
            this.isTpunishment = isTpunishment;

        }
        public PICalc(List<float> position,List<float> torque, bool isTpunishment)
        {
            this.singlePosition = position;
            this.singleTroque = torque;
            this.isTpunishment = isTpunishment;
        }


        public float getSinglePIValue()
        {
            int indexT = 0;
            int indexInverseT = 0;
            float PIValueNow=0f;
            for (int i = 0; i != singlePosition.Count; i++)
            {
                
               
               if (getPIDecision(singlePosition[i]))
               {
                        indexT++;
               }
               else
               {
                        indexInverseT++;
               }

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
                    if (getPIDecision(position[i][j]))
                    {
                        indexT++;
                    }
                    else
                    {
                        indexInverseT++;
                    }
                   
                }
                float PIValueNow = (float)(indexT - indexInverseT) / (float)(indexT + indexInverseT);
                PIValue.Add(PIValueNow);

            }
            return PIValue;
        }

        /// <summary>
        /// 获取当前位置属于哪个区域
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool getPIDecision(float value)
        {
            if (isTpunishment)
            {
                if ((value > -45 & value < 45) || (value > 135 || value < -135))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if ((value > -135 & value < -45) || (value > 45 || value < 135))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

       

    }
}
