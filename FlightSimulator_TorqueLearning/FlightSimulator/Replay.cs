using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rorationSimulation;
using XControl;
using System.IO;

namespace FlightSimulator
{
    public partial class Replay : Form
    {
        public Replay()
        {
            InitializeComponent();
        }

        private drawProcess dp;
        private PortControl pc;
        private List<float> lpf1 = new List<float>();
        private List<float> lpf2 = new List<float>();
        private List<int> positionRawData;
        private List<int> torqueRawData;

        private int ii = 0;
        private void btnTestDrawing_Click(object sender, EventArgs e)
        {
            lblChooseDisplay.Visible = true;
            cbIsPosition.Visible = true;
            cbIsTorque.Visible = true;

            dp = new drawProcess(this.pictureBox1.Size.Width, this.pictureBox1.Size.Height, Color.DarkCyan);
            this.timer1.Start();



            positionRawData = getRawData("dataPosition.txt");
            torqueRawData = getRawData("dataTorque.txt");
            MessageBox.Show("finished");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float positionVoltageValue;
            float torqueVoltageValue;

            float position = float.Parse(pc.AnalogInput10(0, out positionVoltageValue));
            float troque = float.Parse(pc.AnalogInput(1, out torqueVoltageValue));
            

            //if (true)
            //{
            //    position = 1744;
            //    troque = 2862;
            //}


            this.lblPositionValue.Text = positionRawData[ii].ToString();
            this.lblTorqueValue.Text = torqueRawData[ii].ToString();


            if (ii < positionRawData.Count)
            {
                lpf1.Add(positionRawData[ii]);
                lpf2.Add(torqueRawData[ii]);
            }
            else
            {
                lpf1.Add(positionRawData[0]);
                lpf2.Add(torqueRawData[0]);
            }

           
            if (lpf1.Count == 900)
            {
                lpf1.Remove(lpf1[0]);
            }

            if (lpf2.Count == 900)
            {
                lpf2.Remove(lpf2[0]);
            }

            ii++;

            this.pictureBox1.CreateGraphics().DrawImage(dp.drawSignalCurve(lpf1, lpf2,true), 0, 0);
        }

        private List<int> getRawData(string path)
        {

            System.IO.StreamReader sR = File.OpenText(Application.StartupPath+"\\"+path);
            List<int> l = new List<int>();
            string line = sR.ReadLine();
            int index;

            while (true)
            {
                if (line != "")
                {
                    index = line.IndexOf(",");
                    l.Add(int.Parse(line.Substring(0, index)));
                    line = line.Remove(0, index + 1);
                }
                else
                {
                    break;
                }
            }

            return l;
        }
        private void Replay_Load(object sender, EventArgs e)
        {
            pc = new PortControl(0);
            pc.AnalogPortConfigurationIn();
            pc.AnalogPortConfigurationOut();
            pc.DigitalConfigurationOut();
            timer1.Interval = 100; 
        }
    }
}
