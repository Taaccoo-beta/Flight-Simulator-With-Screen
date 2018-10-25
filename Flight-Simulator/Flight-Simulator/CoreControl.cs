using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XControl
{
    class CoreControl
    {
        private PortControl pc;
        public CoreControl()
        {
            pc = new PortControl(0);
            pc = new PortControl(0);
            pc.AnalogPortConfigurationIn();
            pc.AnalogPortConfigurationOut();
            pc.DigitalConfigurationOut();
            pc.ClearALLDigitalPort();
        }


        public void OpenLoop()
        {
            pc.DigitOutput(3, MccDaq.DigitalLogicState.Low);
            pc.DigitOutput(4, MccDaq.DigitalLogicState.High);
            pc.DigitOutput(2, MccDaq.DigitalLogicState.High);
        }

        public void ClosedLoop()
        {
            pc.DigitOutput(3, MccDaq.DigitalLogicState.High);
            pc.DigitOutput(4, MccDaq.DigitalLogicState.Low);
            pc.DigitOutput(2, MccDaq.DigitalLogicState.High);
        }


        public float getPositionSignal()
        {
            float positionVoltageValue;
            float position = float.Parse(pc.AnalogInput10(0, out positionVoltageValue));
            return position;
        }

        public float getTorqueSignal()
        {
            float torqueVlotageValue;
            float torque = float.Parse(pc.AnalogInput(1, out torqueVlotageValue));
            return torque;
        }

        public void punishmentByHeat()
        {
            this.pc.DigitOutput(0, MccDaq.DigitalLogicState.High);
        }

        public void unPunishmentByHeat()
        {
            this.pc.DigitOutput(0, MccDaq.DigitalLogicState.Low);
        }


        public void StartUpBais(float value)
        {
            OpenLoop();
            pc.VOutput(0, -value);
        }

        public void StartDownBais(float value)
        {
            OpenLoop();
            pc.VOutput(0, value);
        }

        public void StopBais()
        {
            pc.DigitOutput(3, MccDaq.DigitalLogicState.Low);
            pc.DigitOutput(4, MccDaq.DigitalLogicState.Low);
            pc.DigitOutput(2, MccDaq.DigitalLogicState.Low);
        }
    }
}
