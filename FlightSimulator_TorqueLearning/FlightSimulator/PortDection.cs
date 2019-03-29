using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XControl;
namespace FlightSimulator
{
    public partial class PortDection : Form
    {

        private PortControl pc;
        private float position;
        private float troque;
        private float tacho;

        private float positionVoltageValue;
        private float torqueVoltageValue;
        private float tachoVoltageValue;


        public PortDection()
        {
            InitializeComponent();
            timer1.Interval = 100;

            
        }


        private bool isStart = true;
        private void PortDection_Load(object sender, EventArgs e)
        {
            pc = new PortControl(0);
            pc.AnalogPortConfigurationIn();
            pc.AnalogPortConfigurationOut();
            pc.DigitalConfigurationOut();
        }

        private void lblStart_Click(object sender, EventArgs e)
        {
            if (isStart)
            {
                this.lblStart.Text = "Stop";
                isStart = false;

               


               
                timer1.Start();
            }
            else
            {
                this.lblStart.Text = "Start";
                isStart = true;
                timer1.Stop();
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            position = float.Parse(pc.AnalogInput(0, out positionVoltageValue));
            troque = float.Parse(pc.AnalogInput(1, out torqueVoltageValue));
            tacho = float.Parse(pc.AnalogInput(2, out tachoVoltageValue));


          


            this.lblPosition.Text = position.ToString();
            this.lblTorque.Text = troque.ToString();
            this.lblTacho.Text = tacho.ToString();

            this.lblPositionVoltageValue.Text = positionVoltageValue.ToString("0.000");
            this.lblTorqueVoltageValue.Text = torqueVoltageValue.ToString("0.000");
            this.lblTachoVoltageValue.Text = tachoVoltageValue.ToString("0.000");
        }

        private void btnRotatinBias_Click(object sender, EventArgs e)
        {
            pc.VOutput(0, float.Parse(this.tbPrtatingBias.Text));
        }

        private void btnTorqueBias_Click(object sender, EventArgs e)
        {
            this.pc.VOutput(1, float.Parse(this.tbTroqueBias.Text));
        }

        private void btnSendShutter_Click(object sender, EventArgs e)
        {
            if (this.cbShutter.Checked)
            {
                this.pc.DigitOutput(0, MccDaq.DigitalLogicState.High);
            }
            else
            {
                this.pc.DigitOutput(0, MccDaq.DigitalLogicState.Low);
            }
        }

        private void btnSendHeat_Click(object sender, EventArgs e)
        {
            if (this.cbHeat.Checked)
            {
                this.pc.DigitOutput(1, MccDaq.DigitalLogicState.High);
            }
            else
            {
                this.pc.DigitOutput(1, MccDaq.DigitalLogicState.Low);
            }
        }

        private void btnSendIntergrator_Click(object sender, EventArgs e)
        {
            if (this.cbIntergrator.Checked)
            {
                this.pc.DigitOutput(2, MccDaq.DigitalLogicState.High);
            }
            else
            {
                this.pc.DigitOutput(2, MccDaq.DigitalLogicState.Low);
            }
        }

        private void btnSendClosed_Click(object sender, EventArgs e)
        {
            if (this.cbCloseOpen.Checked)
            {
                this.pc.DigitOutput(3, MccDaq.DigitalLogicState.High);
            }
            else
            {
                this.pc.DigitOutput(3, MccDaq.DigitalLogicState.Low);
            }
        }

        private void btnSeedRotating_Click(object sender, EventArgs e)
        {
            if (this.cbRotatingBias.Checked)
            {
                this.pc.DigitOutput(4, MccDaq.DigitalLogicState.High);
            }
            else
            {
                this.pc.DigitOutput(4, MccDaq.DigitalLogicState.Low);
            }
        }

        private void btnSeedByChoose_Click(object sender, EventArgs e)
        {
            if (this.cbHighOrLow.Checked)
            {
                this.pc.DigitOutput(int.Parse(tbPortNumber.Text), MccDaq.DigitalLogicState.High);
            }
            else
            {
                this.pc.DigitOutput(int.Parse(tbPortNumber.Text), MccDaq.DigitalLogicState.Low);
            }
        }

        private void btnPortDetSendSwitchHigh_1_Click(object sender, EventArgs e)
        {
            this.pc.DigitOutput(0, MccDaq.DigitalLogicState.High);
            lblShutterState.Text = "High";
        }

        private void btnPortDetSendSwitchLow_1_Click(object sender, EventArgs e)
        {
            this.pc.DigitOutput(0, MccDaq.DigitalLogicState.Low);
            lblShutterState.Text = "Low";
        }

        private void btnPortDetSendSwitchHigh_2_Click(object sender, EventArgs e)
        {
            this.pc.DigitOutput(1, MccDaq.DigitalLogicState.High);
            lblHeatState.Text = "High";
        }

        private void btnPortDetSendSwitchLow_2_Click(object sender, EventArgs e)
        {
            this.pc.DigitOutput(1, MccDaq.DigitalLogicState.Low);
            lblHeatState.Text = "Low";
        }

        private void btnPortDetSendSwitchHigh_3_Click(object sender, EventArgs e)
        {
            this.pc.DigitOutput(2, MccDaq.DigitalLogicState.High);
            lblIntergratorState.Text = "High";
        }

        private void btnPortDetSendSwitchLow_3_Click(object sender, EventArgs e)
        {
            this.pc.DigitOutput(2, MccDaq.DigitalLogicState.Low);
            lblIntergratorState.Text = "Low";
        }

        private void btnPortDetSendSwitchHigh_4_Click(object sender, EventArgs e)
        {
            this.pc.DigitOutput(3, MccDaq.DigitalLogicState.High);
            lblCloseOpenState.Text = "High";

        }

        private void btnPortDetSendSwitchLow_4_Click(object sender, EventArgs e)
        {
            this.pc.DigitOutput(3, MccDaq.DigitalLogicState.Low);
            lblCloseOpenState.Text = "Low";
        }

        private void btnPortDetSendSwitchHigh_5_Click(object sender, EventArgs e)
        {
            this.pc.DigitOutput(4, MccDaq.DigitalLogicState.High);
            lblRotatingBias.Text = "High";
        }

        private void btnPortDetSendSwitchLow_5_Click(object sender, EventArgs e)
        {
            this.pc.DigitOutput(4, MccDaq.DigitalLogicState.Low);
            lblRotatingBias.Text = "Low";
        }
    }
}
