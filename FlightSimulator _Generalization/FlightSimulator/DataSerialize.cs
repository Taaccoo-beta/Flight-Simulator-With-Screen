using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



/// <summary>
/// 序列化参数：包括温度拟合系数，PID控制参数
/// 对这些参数进行存储
/// 温度系数存放在 tempPID.dat 文件中         
/// PID系数存放在 tempTParameters.dat 文件中
/// </summary>
namespace SerieslizeControlModule
{


    [Serializable]
    class TParameters
    {
        public double p1_1;
        public double p2_1;
        public double p1_2;
        public double p2_2;
        public double p1_3;
        public double p2_3;
        public double p1_4;
        public double p2_4;
        public double p1_5;
        public double p2_5;
        public double p1_6;
        public double p2_6;
        public double p1_7;
        public double p2_7;
        public double p1_8;
        public double p2_8;
    }
    [Serializable]
    class PIDParameters
    {
        public double kp_up_1;
        public double ki_up_1;
        public double kd_up_1;
        public double kp_up_2;
        public double ki_up_2;
        public double kd_up_2;
        public double kp_up_3;
        public double ki_up_3;
        public double kd_up_3;
        public double kp_up_4;
        public double ki_up_4;
        public double kd_up_4;
        public double kp_up_5;
        public double ki_up_5;
        public double kd_up_5;
        public double kp_up_6;
        public double ki_up_6;
        public double kd_up_6;
        public double kp_up_7;
        public double ki_up_7;
        public double kd_up_7;
        public double kp_up_8;
        public double ki_up_8;
        public double kd_up_8;

        public double kp_down_1;
        public double ki_down_1;
        public double kd_down_1;
        public double kp_down_2;
        public double ki_down_2;
        public double kd_down_2;
        public double kp_down_3;
        public double ki_down_3;
        public double kd_down_3;
        public double kp_down_4;
        public double ki_down_4;
        public double kd_down_4;
        public double kp_down_5;
        public double ki_down_5;
        public double kd_down_5;
        public double kp_down_6;
        public double ki_down_6;
        public double kd_down_6;
        public double kp_down_7;
        public double ki_down_7;
        public double kd_down_7;
        public double kp_down_8;
        public double ki_down_8;
        public double kd_down_8;

    }


    


    class CoreSerialize
    {

        private string Path_PID;
        private string Path_TParam;
       
        public CoreSerialize()
        {
           
                Path_PID = @"tempPID.dat";          
                Path_TParam = @"tempTParameters.dat";
           
        }

        public void TParammSerializeNow(TParameters data)
        {
            FileStream fileStream = new FileStream(Path_TParam, FileMode.OpenOrCreate);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(fileStream, data);
            fileStream.Close();
        }

        public TParameters TParamDeSerializeNow()
        {
            TParameters data = new TParameters();
            FileStream fileStream = new FileStream(Path_TParam, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryFormatter b = new BinaryFormatter();
            data = b.Deserialize(fileStream) as TParameters;
            fileStream.Close();

            return data;
        }

        public void PIDSerializeNow(PIDParameters data)
        {
            FileStream fileStream = new FileStream(Path_PID, FileMode.OpenOrCreate);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(fileStream, data);
            fileStream.Close();
        }

        public PIDParameters PIDDeSerializeNow()
        {
            PIDParameters data = new PIDParameters();
            FileStream fileStream = new FileStream(Path_PID, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryFormatter b = new BinaryFormatter();
            data = b.Deserialize(fileStream) as PIDParameters;
            fileStream.Close();

            return data;
        }

    }
}
