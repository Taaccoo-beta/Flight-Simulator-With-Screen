using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using  XControl;
namespace FlightSimulator
{
    public partial  class SpeedDetection : Form
    {
        public SpeedDetection()
        {
            InitializeComponent();
        }
        [DllImport("winmm")]
        static extern uint timeGetTime();

        [DllImport("winmm")]
        static extern void timeBeginPeriod(int t);
        [DllImport("winmm")]
        static extern void timeEndPeriod(int t);


        private PortControl pc;

        private Thread t;

        private uint timeCount = 0;

        private bool isTheardCircleClosed;

        private float iniPosition;
        private float positionNow;
        private float endPosition;

        private uint timeSpent;

        bool UpOrDown;
        private void SpeedDetection_Load(object sender, EventArgs e)
        {
            pc = new PortControl(0);
            pc.AnalogPortConfigurationIn();
            pc.AnalogPortConfigurationOut();
            pc.DigitalConfigurationOut();
        }

        private void setOpenLoop()
        {
            pc.DigitOutput(3, MccDaq.DigitalLogicState.Low);
            pc.DigitOutput(4, MccDaq.DigitalLogicState.High);
            pc.DigitOutput(2, MccDaq.DigitalLogicState.High);
        }
        private void Close()
        {
            pc.DigitOutput(3, MccDaq.DigitalLogicState.Low);
            pc.DigitOutput(4, MccDaq.DigitalLogicState.Low);
            pc.DigitOutput(2, MccDaq.DigitalLogicState.Low);
        }


        private void myTimer()
        {
            timeBeginPeriod(1);
            uint start = timeGetTime();
            uint newStart;
            
            while (!isTheardCircleClosed)
            {

                float positionVoltageValue;
                endPosition = float.Parse(pc.AnalogInput(0, out positionVoltageValue));

                timeCount++;
                if (timeCount > 100)
                {
                    if (UpOrDown)
                    {
                        if (endPosition > iniPosition && Math.Abs(endPosition-iniPosition)>100)
                        {

                            isTheardCircleClosed = true;
                            newStart = timeGetTime();
                            timeSpent = newStart - start;
                            this.lblTimespan.Text = timeSpent.ToString();
                            pc.VOutput(0, 2.5f);
                            Close();
                            timer1.Stop();
                            t.Abort();

                        }
                    }
                    else
                    {
                        if (endPosition < iniPosition && Math.Abs(endPosition - iniPosition) > 100)
                        {

                            isTheardCircleClosed = true;
                            newStart = timeGetTime();
                            timeSpent = newStart - start;
                            this.lblTimespan.Text = timeSpent.ToString();
                            pc.VOutput(0, 2.5f);
                            Close();
                            timer1.Stop();
                            t.Abort();
                        }
                    }
                }
                
            }


        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            float voltageValue=2.5f;
            try
            {
                voltageValue = float.Parse(this.tbVoltageValue.Text);
            }
            catch
            {
                MessageBox.Show("Voltage is NULL");
            }
            float positionVoltageValue;
            iniPosition = float.Parse(pc.AnalogInput(0, out positionVoltageValue));


            timeCount = 0;

            if (voltageValue > 2.5)
            {
                UpOrDown = false;
            }
            else
            {
                UpOrDown = true;
            }

            setOpenLoop();
            pc.VOutput(0, voltageValue);

            t = new Thread(myTimer);
            isTheardCircleClosed = false;
            t.Start();

            timer1.Interval = 100;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblPositionNowValue.Text = endPosition.ToString();
        }

        private void lblPositionNowValue_Click(object sender, EventArgs e)
        {

        }
    }
}
