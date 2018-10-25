using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flight_Simulator
{
    public partial class SigleExpResultPre : Form
    {
        private string dateTime;
        private string expName;
       
     
        private string path;
        private Dictionary<int, List<float>> troqueData;
        private int[] expOrder;

        public SigleExpResultPre(string dateTime, string expName, string path, Dictionary<int, List<float>> troqueData, int[] expOrder)
        {
            this.dateTime = dateTime;
            this.expName = expName;
          
           
            this.troqueData = troqueData;
            this.path = path;
            this.expOrder = expOrder;
            InitializeComponent();

        }

        //public SigleExpResultPre()
        //{
        //    InitializeComponent();
        //}

      
        private void SigleExpResultPre_Load(object sender, EventArgs e)
        {

        }

        private void DataSave()
        {
            FileInfo myFile = new FileInfo(path);
            StreamWriter sW = myFile.CreateText();

            sW.WriteLine("ExpName: " + expName);
            sW.WriteLine("Date: " + dateTime);

            sW.Write("ExpOrder:  [");
            for (int i = 0; i != expOrder.Length-1; i++)
            {
                sW.Write(expOrder[i] + ",");
            }

            sW.Write(expOrder[expOrder.Length - 1]);
            sW.Write("]");

            sW.WriteLine();


            sW.WriteLine();
            sW.WriteLine();
            sW.Write("Torque");
            sW.WriteLine();

            for (int i = 1; i != troqueData.Count+1; i++)
            {
                sW.Write("exp" + i);
                sW.WriteLine();
                int indexInside = troqueData[i].Count;
                for (int j = 0; j != indexInside; j++)
                {
                    sW.WriteLine(troqueData[i][j].ToString("00.00"));
                }

            }

            sW.Close();
        }
        public void showResult()
        {
            
            lblExpName.Text = expName;
            lblExpTime.Text = dateTime;
            lblPathValue.Text = path;
            DataSave();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Press OK to delete", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                File.Delete(path);
                this.Close();
            }
            else
            {
                this.Close();
            }

        }
    }
}

