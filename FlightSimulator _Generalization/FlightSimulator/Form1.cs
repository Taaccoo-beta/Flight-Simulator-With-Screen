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
using System.Runtime.InteropServices;
using visual_stimulus_generator;

namespace FlightSimulator
{
    public partial class FlightSimulator : Form
    {
        [DllImport("winmm")]
        static extern uint timeGetTime();

        [DllImport("winmm")]
        static extern void timeBeginPeriod(int t);
        [DllImport("winmm")]
        static extern void timeEndPeriod(int t);



        //Train  true    Test  false
        private List<bool> trainOrTest_1 = new List<bool>();
        private List<int> experimentTime_1 = new List<int>();

        private List<bool> trainOrTest_2 = new List<bool>();
        private List<int> experimentTime_2 = new List<int>();

        private List<bool> trainOrTest_3 = new List<bool>();
        private List<int> experimentTime_3 = new List<int>();

        private List<Control> controls;
        //test in step 3
        private List<bool> trainOrTestForTest = new List<bool>();
        private List<int> experimentTimeForTest = new List<int>();


        drawProcess dp;
        drawProcess dp1;
        drawProcess dp2;


        private int upBiasCount = 0;
        private int downBiasCount = 0;
        private float iniBiasValue = 2.5f;

        private int sequenceIndex = 0;

        private Bitmap imageNow;

        //debug mode start
        bool ifStartDebugMode = false;

        //save position and torque point
        private List<float> lpf1 = new List<float>();
        private List<float> lpf2 = new List<float>();

        private List<float> lpf3 = new List<float>();
        private List<float> lpf4 = new List<float>();

        private uint timeIndex = 0;
        private int sequenceIndexForExperiment = 0;
        private List<List<float>> positionForEverySequence;
        private List<List<float>> torqueForEverySequence;


        private PortControl pc;

        //false minute, true second
        private bool isSecond_1 = true;
        private bool isSecond_2 = true;
        private bool isSecond_3 = true;

        List<bool> trainOrTestUsed;
        List<int> experimentTimeUsed;

        private bool backToZeroControlSwitch = true;

        //
        private bool isOpenCircle = true;

        public FlightSimulator()
        {
            InitializeComponent();
        }

        
        private void portDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PortDection pt = new PortDection();
            int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
            int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;
            pt.Location = new Point(iActulaWidth/2, iActulaHeight/10);
            pt.Show();
        }

        private void btnSetSAdd_Click(object sender, EventArgs e)
        {
            if (rbTest_1.Checked)
            {
                trainOrTest_1.Add(false);
                
                if (isSecond_1)
                {
                    experimentTime_1.Add(int.Parse(tbLastTime_1.Text));
                    lbExpSequence_1.Items.Add(trainOrTest_1.Count.ToString("00") + "   " + "Test  " + tbLastTime_1.Text + "s");
                }
                else
                {

                    experimentTime_1.Add(60 * int.Parse(tbLastTime_1.Text));
                    lbExpSequence_1.Items.Add(trainOrTest_1.Count.ToString("00") + "   " + "Test  " + 60*int.Parse(tbLastTime_1.Text) + "s");

                }


            }
            else
            {
                trainOrTest_1.Add(true);
                
                if (isSecond_1)
                {
                    experimentTime_1.Add(int.Parse(tbLastTime_1.Text));
                    lbExpSequence_1.Items.Add(trainOrTest_1.Count.ToString("00") + "  " + "Train  " + tbLastTime_1.Text + "s");
                }
                else
                {
                    experimentTime_1.Add(60 * int.Parse(tbLastTime_1.Text));
                    lbExpSequence_1.Items.Add(trainOrTest_1.Count.ToString("00") + "  " + "Train  " + 60*int.Parse(tbLastTime_1.Text) + "s");
                }


            }
        }

        private void btnSetSDelete_Click(object sender, EventArgs e)
        {
            try
            {
                trainOrTest_1.RemoveAt(lbExpSequence_1.SelectedIndex);
                experimentTime_1.RemoveAt(lbExpSequence_1.SelectedIndex);
            }
            catch
            {
                MessageBox.Show("Wrong, no item choosed!");

            }

            lbExpSequence_1.Items.Clear();

            for (int i = 0; i != trainOrTest_1.Count; i++)
            {
                if (trainOrTest_1[i] == true)
                {
                    if (isSecond_1)
                    {
                        lbExpSequence_1.Items.Add((i + 1).ToString("00") + "  " + "Train  " + experimentTime_1[i].ToString() + "s");
                    }
                    else
                    {
                        lbExpSequence_1.Items.Add((i + 1).ToString("00") + "  " + "Train  " + experimentTime_1[i].ToString() + "m");
                    }

                }
                else
                {
                    if (isSecond_1)
                    {
                        lbExpSequence_1.Items.Add((i + 1).ToString("00") + "   " + "Test  " + experimentTime_1[i].ToString() + "s");
                    }
                    else
                    {
                        lbExpSequence_1.Items.Add((i + 1).ToString("00") + "   " + "Test  " + experimentTime_1[i].ToString() + "m");
                    }


                }
            }

        }

        private void btnSetSAdd_2_Click(object sender, EventArgs e)
        {
            if (rbTest_2.Checked)
            {
                trainOrTest_2.Add(false);
                
                if (isSecond_2)
                {
                    experimentTime_2.Add(int.Parse(tbLastTime_2.Text));
                    lbExpSequence_2.Items.Add(trainOrTest_2.Count.ToString("00") + "   " + "Test  " + tbLastTime_2.Text + "s");
                }
                else
                {
                    experimentTime_2.Add(60*int.Parse(tbLastTime_2.Text));
                    lbExpSequence_2.Items.Add(trainOrTest_2.Count.ToString("00") + "   " + "Test  " + 60 * int.Parse(tbLastTime_2.Text) + "s");
                }


            }
            else
            {
                trainOrTest_2.Add(true);
                
                if (isSecond_2)
                {
                    experimentTime_2.Add(int.Parse(tbLastTime_2.Text));
                    lbExpSequence_2.Items.Add(trainOrTest_2.Count.ToString("00") + "  " + "Train  " + tbLastTime_2.Text + "s");
                }
                else
                {
                    experimentTime_2.Add(60*int.Parse(tbLastTime_2.Text));
                    lbExpSequence_2.Items.Add(trainOrTest_2.Count.ToString("00") + "  " + "Train  " + 60 * int.Parse(tbLastTime_2.Text) + "s");
                }


            }
        }

        private void btnSetSAdd_3_Click(object sender, EventArgs e)
        {
            if (rbTest_3.Checked)
            {
                trainOrTest_3.Add(false);
                
                if (isSecond_3)
                {
                    experimentTime_3.Add(int.Parse(tbLastTime_3.Text));
                    lbExpSequence_3.Items.Add(trainOrTest_3.Count.ToString("00") + "   " + "Test  " + tbLastTime_3.Text + "s");
                }
                else
                {
                    experimentTime_3.Add(60*int.Parse(tbLastTime_3.Text));
                    lbExpSequence_3.Items.Add(trainOrTest_3.Count.ToString("00") + "   " + "Test  " + 60 * int.Parse(tbLastTime_3.Text) + "s");
                }


            }
            else
            {
                trainOrTest_3.Add(true);
                
                if (isSecond_3)
                {
                    experimentTime_3.Add(int.Parse(tbLastTime_3.Text));
                    lbExpSequence_3.Items.Add(trainOrTest_3.Count.ToString("00") + "  " + "Train  " + tbLastTime_3.Text + "s");
                }
                else
                {
                    experimentTime_3.Add(60*int.Parse(tbLastTime_3.Text));
                    lbExpSequence_3.Items.Add(trainOrTest_3.Count.ToString("00") + "  " + "Train  " + 60 * int.Parse(tbLastTime_3.Text) + "m");
                }


            }
        }

        private void btnSetSDelete_2_Click(object sender, EventArgs e)
        {
            try
            {
                trainOrTest_2.RemoveAt(lbExpSequence_2.SelectedIndex);
                experimentTime_2.RemoveAt(lbExpSequence_2.SelectedIndex);
            }
            catch
            {
                MessageBox.Show("Wrong, no item choosed!");

            }

            lbExpSequence_2.Items.Clear();

            for (int i = 0; i != trainOrTest_2.Count; i++)
            {
                if (trainOrTest_2[i] == true)
                {
                    if (isSecond_2)
                    {
                        lbExpSequence_2.Items.Add((i + 1).ToString("00") + "  " + "Train  " + experimentTime_2[i].ToString() + "s");
                    }
                    else
                    {
                        lbExpSequence_2.Items.Add((i + 1).ToString("00") + "  " + "Train  " + experimentTime_2[i].ToString() + "m");
                    }

                }
                else
                {
                    if (isSecond_2)
                    {
                        lbExpSequence_2.Items.Add((i + 1).ToString("00") + "   " + "Test  " + experimentTime_2[i].ToString() + "s");
                    }
                    else
                    {
                        lbExpSequence_2.Items.Add((i + 1).ToString("00") + "   " + "Test  " + experimentTime_2[i].ToString() + "m");
                    }


                }
            }

        }

        private void btnSetSDelete_3_Click(object sender, EventArgs e)
        {
            try
            {
                trainOrTest_3.RemoveAt(lbExpSequence_3.SelectedIndex);
                experimentTime_3.RemoveAt(lbExpSequence_3.SelectedIndex);
            }
            catch
            {
                MessageBox.Show("Wrong, no item choosed!");

            }

            lbExpSequence_3.Items.Clear();

            for (int i = 0; i != trainOrTest_3.Count; i++)
            {
                if (trainOrTest_3[i] == true)
                {
                    if (isSecond_3)
                    {
                        lbExpSequence_3.Items.Add((i + 1).ToString("00") + "  " + "Train  " + experimentTime_3[i].ToString() + "s");
                    }
                    else
                    {
                        lbExpSequence_3.Items.Add((i + 1).ToString("00") + "  " + "Train  " + experimentTime_3[i].ToString() + "m");
                    }

                }
                else
                {
                    if (isSecond_3)
                    {
                        lbExpSequence_3.Items.Add((i + 1).ToString("00") + "   " + "Test  " + experimentTime_3[i].ToString() + "s");
                    }
                    else
                    {
                        lbExpSequence_3.Items.Add((i + 1).ToString("00") + "   " + "Test  " + experimentTime_3[i].ToString() + "m");
                    }


                }
            }

        }

        private void cbSecondOrMinute_1_CheckedChanged(object sender, EventArgs e)
        {
           
        }


        

        private void btnSetSequenceSave_3_Click(object sender, EventArgs e)
        {
            if (trainOrTest_3.Count == 0)
            {
                MessageBox.Show("Not item found");
            }
            else
            {

                FileStream fs3 = new FileStream(Application.StartupPath + "\\set-3.txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs3);
                sw.WriteLine(trainOrTest_3.Count);//开始写入值
                for (int i = 0; i < trainOrTest_3.Count; i++)
                {
                    if (trainOrTest_3[i] == true)
                    {
                        sw.WriteLine("Train");
                        sw.WriteLine(experimentTime_3[i].ToString());

                    }
                    else
                    {
                        sw.WriteLine("Test");
                        sw.WriteLine(experimentTime_3[i].ToString());
                    }
                }

                sw.Close();
                fs3.Close();


            }



        }

        private void gbSetSequence_2_Enter(object sender, EventArgs e)
        {

        }

        private void cbSetSeqChoosed_1_Click(object sender, EventArgs e)
        {
            if (cbSetSeqChoosed_1.Checked == true)
            {
                cbSetSeqChoosed_1.Checked = true;
                cbSetSeqChoosed_2.Checked = false ;
                cbSetSeqChoosed_3.Checked = false;
            }
            else
            {
                cbSetSeqChoosed_1.Checked = false;
                
            }
        }

        private void cbSetSeqChoosed_2_Click(object sender, EventArgs e)
        {
            if (cbSetSeqChoosed_2.Checked == true)
            {
                cbSetSeqChoosed_2.Checked = true;
                cbSetSeqChoosed_1.Checked = false;
                cbSetSeqChoosed_3.Checked = false;
            }
            else
            {
                cbSetSeqChoosed_2.Checked = false;

            }
        }

        private void cbSetSeqChoosed_3_Click(object sender, EventArgs e)
        {
            if (cbSetSeqChoosed_3.Checked == true)
            {
                cbSetSeqChoosed_3.Checked = true;
                cbSetSeqChoosed_1.Checked = false;
                cbSetSeqChoosed_2.Checked = false;
            }
            else
            {
                cbSetSeqChoosed_3.Checked = false;

            }
        }

        private void btnChooseDataPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog BrowDialog = new FolderBrowserDialog();
            BrowDialog.ShowNewFolderButton = true;
            BrowDialog.Description = "请选择数据保存位置";
            BrowDialog.ShowDialog();
            string path = BrowDialog.SelectedPath;
            lblDPValue.Text = path;
        }

        private void lblDPValue_Click(object sender, EventArgs e)
        {

        }
        private bool ifFromTab1ToTab2 = true;
        private void btnGoStep_2_Click(object sender, EventArgs e)
        {
            string dataPath = this.lblDPValue.Text;
            DirectoryInfo folder = new DirectoryInfo(dataPath);
            string expFileName = this.tbExperimentName.Text + ".txt";
            if (folder.GetFiles("*.txt").Length == 0)
            {
                tabControl.SelectTab(1);
            }
            else
            {
                foreach (FileInfo file in folder.GetFiles("*.txt"))
                {
                    if (expFileName.Equals(file.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        DialogResult dr = MessageBox.Show("实验名重复，是否重设？", "是", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.OK)
                        {
                            tabControl.SelectTab(0);
                        }
                        else
                        {
                            ifFromTab1ToTab2 = false;
                            tabControl.SelectTab(1);
                        }
                    }
                }
            }
        }

        bool ifStop;
        private void btnTestDrawing_Click(object sender, EventArgs e)
        {
            lblChooseDisplay.Visible = true;
            cbIsPosition.Visible = true;
            cbIsTorque.Visible = true;

            dp = new drawProcess(this.pictureBox1.Size.Width, this.pictureBox1.Size.Height, Color.DarkCyan);

            timer1.Interval = 100;
            timer1.Start();

          
        }


        private void tpStep2_Click(object sender, EventArgs e)
        {

        }
        private CoreControl cc;
        private void Form1_Load(object sender, EventArgs e)
        {
            pc = new PortControl(0);
            pc.AnalogPortConfigurationIn();
            pc.AnalogPortConfigurationOut();
            pc.DigitalConfigurationOut();
            pc.ClearALLDigitalPort();
            positionForEverySequence = new List<List<float>>();
            torqueForEverySequence = new List<List<float>>();
            cc = new CoreControl();

            StreamReader sR = File.OpenText(Application.StartupPath+"\\set-1.txt");
            int length = int.Parse(sR.ReadLine());
            for (int i = 0; i != length; i++)
            {
                string temp = sR.ReadLine();
                if (temp == "Train")
                {
                    trainOrTest_1.Add(true);
                    experimentTime_1.Add(int.Parse(sR.ReadLine()));
                    lbExpSequence_1.Items.Add(trainOrTest_1.Count.ToString("00") + "   " + "Train  " + experimentTime_1[i] + "s");
                }
                else
                {
                    trainOrTest_1.Add(false);
                    experimentTime_1.Add(int.Parse(sR.ReadLine()));
                    lbExpSequence_1.Items.Add(trainOrTest_1.Count.ToString("00") + "   " + "Test   " + experimentTime_1[i] + "s");
                }


                



            }
            sR.Close();


            StreamReader sR2 = File.OpenText(Application.StartupPath + "\\set-2.txt");
            int length2 = int.Parse(sR2.ReadLine());
            for (int i = 0; i != length2; i++)
            {
                string temp = sR2.ReadLine();
                if (temp == "Train")
                {
                    trainOrTest_2.Add(true);
                    experimentTime_2.Add(int.Parse(sR2.ReadLine()));
                    lbExpSequence_2.Items.Add(trainOrTest_2.Count.ToString("00") + "   " + "Train  " + experimentTime_2[i] + "s");
                }
                else
                {
                    trainOrTest_2.Add(false);
                    experimentTime_2.Add(int.Parse(sR2.ReadLine()));
                    lbExpSequence_2.Items.Add(trainOrTest_2.Count.ToString("00") + "   " + "Test   " + experimentTime_2[i] + "s");
                }






            }
            sR2.Close();

            StreamReader sR3 = File.OpenText(Application.StartupPath + "\\set-2.txt");
            int length3 = int.Parse(sR3.ReadLine());
            for (int i = 0; i != length3; i++)
            {
                string temp = sR3.ReadLine();
                if (temp == "Train")
                {
                    trainOrTest_3.Add(true);
                    experimentTime_3.Add(int.Parse(sR3.ReadLine()));
                    lbExpSequence_3.Items.Add(trainOrTest_3.Count.ToString("00") + "   " + "Train  " + experimentTime_3[i] + "s");
                }
                else
                {
                    trainOrTest_3.Add(false);
                    experimentTime_3.Add(int.Parse(sR3.ReadLine()));
                    lbExpSequence_3.Items.Add(trainOrTest_3.Count.ToString("00") + "   " + "Test   " + experimentTime_3[i] + "s");
                }






            }
            sR3.Close();




            vf = new VisionFigure();
            vf.Size = new System.Drawing.Size(1024, 330);
            vf.Show();

            //vf.Location = new Point(3043, 439);
            vf.Location = new Point(10, 10);
           
            //vf.Location = new Point(3043, 439);

           
        }

        private float k;
        private float bias;

        private void timer1_Tick(object sender, EventArgs e)
        {


            float torqueVoltageValue;
            float troque = float.Parse(pc.AnalogInput(1, out torqueVoltageValue));
            //troque = troque / 100;
            troque_trans = (troque - 2048) / 2048 * 50;


            this.lblPositionValue.Text = degreeForClosedLoop.ToString();

            this.lblTorqueValue.Text = troque.ToString();
            this.lblTroqueTransValue.Text = troque_trans.ToString();
            try
            {
                k = float.Parse(this.tbKValue.Text);
                bias = float.Parse(this.tbBiasValue.Text);
            }
            catch
            {
                k = -11;
                bias = 0;
            }

            if (ifDegreeForDebugUp)
            {
                k += 2;
                this.tbKValue.Text = k.ToString();
                ifDegreeForDebugUp = false;
                ifDegreeForDebugDown = false;

            }
            else if (ifDegreeForDebugDown)
            {
                k -= 2;
                this.tbKValue.Text = k.ToString();
                ifDegreeForDebugUp = false;
                ifDegreeForDebugDown = false;
            }



            degreeForClosedLoop += (troque_trans + bias) * k * 0.01f;
            
            if (degreeForClosedLoop >= 180)
            {
                degreeForClosedLoop =  degreeForClosedLoop-360;
            }
            if (degreeForClosedLoop <= -180)
            {
                degreeForClosedLoop = 360 + degreeForClosedLoop;
            }

            lpf1.Add(degreeForClosedLoop);
            lpf2.Add(troque_trans);

            //lpf1.Add(180);
            //lpf2.Add(10);
            if (lpf1.Count == 400)
            {
                lpf1.Remove(lpf1[0]);
            }

            if (lpf2.Count == 400)
            {
                lpf2.Remove(lpf2[0]);
            }

            this.pictureBox1.CreateGraphics().DrawImage(dp1.drawSignalCurve(lpf1, lpf2), 0, 0);

            this.vf.g2.Clear(Color.White);
            for (int i = 0; i != 1024; i++)
            {
                if (gg.simpleCanvas[i] == 1)
                {
                    this.vf.g2.DrawLine(Pens.Black, i, 105, i, 225);
                }
            }
            this.vf.Refresh();
            gg.SetSimpleCanvasPosition(degreeForClosedLoop);


        }

        private void cbIsPosition_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsPosition.Checked)
            {
                dp.isPosition = true;
            }
            else
            {
                dp.isPosition = false;
            }
        }

        private void cbIsTorque_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsTorque.Checked)
            {
                dp.isTorque = true;
            }
            else
            {
                dp.isTorque = false;
            }
        }

        private void OpenLoop()
        {
            pc.DigitOutput(3, MccDaq.DigitalLogicState.Low);
            pc.DigitOutput(4, MccDaq.DigitalLogicState.High);
            pc.DigitOutput(2, MccDaq.DigitalLogicState.High);
        }

        private void ClosedLoop()
        {
            pc.DigitOutput(3, MccDaq.DigitalLogicState.High);
            pc.DigitOutput(4, MccDaq.DigitalLogicState.Low);
            pc.DigitOutput(2, MccDaq.DigitalLogicState.High);
        }

        private void cbOpenOrClosed_CheckedChanged(object sender, EventArgs e)
        {
            //    if (cbOpenOrClosed.Checked)
            //    {
            //        cbOpenOrClosed.Text = "Closed";
            //        ClosedLoop();
            //        isOpenCircle = false;



            //    }
            //    else
            //    {
            //        cbOpenOrClosed.Text = "Open";
            //        OpenLoop();
            //        isOpenCircle = true;
            //        float v = 2.5f;
            //        pc.VOutput(0,v);
            //    }
            //}
        }
        private void btnGoStep_3_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(2);
            timer1.Stop();
        }



        /// <summary>
        /// save data after finished a sigle experiment
        /// </summary>
        private void DataSave()
        {
            string ExpFinishTime = DateTime.Now.ToString();

            List<int> ExpTime = experimentTimeUsed;

            List<bool> TrainOrTest = trainOrTestUsed;
            string ExpName = tbExperimentName.Text;
            bool ifTPunishment = rbUpT.Checked ? true : false;
            //positionForEverySequence
            //torqueForEverySequence


            string path = this.lblDPValue.Text.ToString() + "\\" + ExpName + ".txt";
            



            //FileInfo myFile = new FileInfo(path);
            //StreamWriter sW = myFile.CreateText();

            //sW.WriteLine("ExpName: " + ExpName);
            //sW.WriteLine("Date: "+ExpFinishTime);

            //sW.Write("ExpSequence: ");
            //foreach (var item in TrainOrTest)
            //{
            //    if (item)
            //    {
            //        sW.Write("Te;");
            //    }
            //    else
            //    {
            //        sW.Write("Tr;");
            //    }
            //}

            //sW.WriteLine();
            //sW.Write("TimeSequence: ");
            //foreach (var item in ExpTime)
            //{
            //    sW.Write(item.ToString() + ";");
            //}

            //sW.WriteLine();
            //sW.Write("If_T_Punishment: " + (ifTPunishment ? 1 : 0).ToString());

            //sW.WriteLine();
            //sW.WriteLine();

            //int index = positionForEverySequence.Count;
            //for (int i = 0; i != index; i++)
            //{
            //    int indexInside = positionForEverySequence[i].Count;
            //    for (int j = 0; j != indexInside; j++)
            //    {
            //        sW.WriteLine(positionForEverySequence[i][j].ToString("00.00") + "," + torqueForEverySequence[i][j].ToString("00.00"));
            //    }
            //}
            
            //sW.Close();

            SigleExpResultPre serp = new SigleExpResultPre(ExpFinishTime, ExpName, ExpTime, TrainOrTest, ifTPunishment,path,positionForEverySequence,torqueForEverySequence);
            serp.setPositionAndTroque(positionForEverySequence, torqueForEverySequence);
            serp.showResult();
            serp.Show();

        }


        /// <summary>
        /// control the port to punish the fruit fly
        /// </summary>
        private void punishmentByHeat()
        {
            this.pc.DigitOutput(0, MccDaq.DigitalLogicState.High);
        }
        private void unPunishmentByHeat()
        {
            this.pc.DigitOutput(0, MccDaq.DigitalLogicState.Low);
        }


        bool ifBreakTime = true;
        private void timer2_Tick(object sender, EventArgs e)
        {

            float torqueVoltageValue;
            float troque = float.Parse(pc.AnalogInput(1, out torqueVoltageValue));
            //troque = troque / 100;
            //troque_trans = (troque - 2048) / 2048 * 50;
            troque_trans = -180;
            
            //this.lblPositionValue.Text = degreeForClosedLoop.ToString();

            //this.lblTorqueValue.Text = troque.ToString();
            //this.lblTroqueTransValue.Text = troque_trans.ToString();
            try
            {
                k = float.Parse(this.tbKValue.Text);
                bias = float.Parse(this.tbBiasValue.Text);
            }
            catch
            {
                k = -11;
                bias = 0;
            }

           
            degreeForClosedLoop += (troque_trans + bias) * k * 0.01f;

            if (degreeForClosedLoop >= 180)
            {
                degreeForClosedLoop = degreeForClosedLoop - 360;
            }
            if (degreeForClosedLoop <= -180)
            {
                degreeForClosedLoop = 360 + degreeForClosedLoop;
            }
            

            positionForEverySequence[sequenceIndexForExperiment].Add(degreeForClosedLoop);
            torqueForEverySequence[sequenceIndexForExperiment].Add(troque_trans);

            lblShowPosStep3.Text = degreeForClosedLoop.ToString("00.00");
            lblShowTorStep3.Text = troque_trans.ToString("00.00");
            if (trainOrTestUsed[sequenceIndexForExperiment])
            {

                if (rbUpT.Checked)
                {
                    if ((degreeForClosedLoop > -45 & degreeForClosedLoop < 45) || (degreeForClosedLoop > 135 || degreeForClosedLoop < -135))
                    {
                        punishmentByHeat();
                        lblPunishmentStateValue.Text = "True";
                    }
                    else
                    {
                        unPunishmentByHeat();
                        lblPunishmentStateValue.Text = "False";
                    }
                }
                else
                {
                    if ((degreeForClosedLoop > 45 & degreeForClosedLoop < 135) || (degreeForClosedLoop > -135 & degreeForClosedLoop < -45))
                    {
                        unPunishmentByHeat();
                        lblPunishmentStateValue.Text = "False";
                    }
                    else
                    {
                        punishmentByHeat();
                        lblPunishmentStateValue.Text = "True";
                    }
                }

            }
            else
            {
                unPunishmentByHeat();
                lblPunishmentStateValue.Text = "False";
            }

            timeIndex++;
            if (timeIndex == experimentTimeUsed[sequenceIndexForExperiment] * 10)
            {
                timeIndex = 0;
                sequenceIndexForExperiment++;
                dp2.clearCommunitivePosition();
                lpf3.Clear();
                lpf4.Clear();
                if (sequenceIndexForExperiment == experimentTimeUsed.Count)
                {
                    timer4.Stop();
                    this.btnStep3Start.Enabled = true;
                    pc.ClearALLDigitalPort();
                    
                   
                    DataSave();




                }
                else
                {
                    positionForEverySequence.Add(new List<float>());
                    torqueForEverySequence.Add(new List<float>());
                    controls[sequenceIndexForExperiment].BackColor = Color.DarkCyan;
                }



                PICalc pic = new PICalc(positionForEverySequence[sequenceIndexForExperiment - 1], torqueForEverySequence[sequenceIndexForExperiment - 1], rbUpT.Checked);
                float piValue = pic.getSiglePIValue();


                Bitmap imageHere = new Bitmap(imageNow);
                PictureBox pb = new PictureBox();
                float width = this.flpBottomForImageList.Size.Width - 30;
                float height = (int)(((float)this.pictureBox3.Size.Height / (float)this.pictureBox3.Size.Width) * width);
                pb.Size = new Size((int)width, (int)height);
                Graphics g = Graphics.FromImage(imageHere);
                g.DrawString("PIValue: " + piValue.ToString(), new Font("Arial", 15), new SolidBrush(Color.LightGray), 130, 20);
                pb.Image = imageHere;
                pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

                this.flpBottomForImageList.Controls.Add(pb);
            }









            ////debug mode
            //   position = 721;
            //   troque = 100;








            lpf3.Add(degreeForClosedLoop);
            lpf4.Add(troque_trans);
            if (lpf3.Count == 300)
            {
                lpf3.Remove(lpf3[0]);
            }

            if (lpf4.Count == 300)
            {
                lpf4.Remove(lpf4[0]);
            }



            this.pictureBox2.CreateGraphics().DrawImage(dp1.drawSignalCurve(lpf3, lpf4), 0, 0);
            imageNow = dp2.drawCommunitivePoint(degreeForClosedLoop, ifStartDebugMode, sequenceIndexForExperiment);
            this.pictureBox3.CreateGraphics().DrawImage(imageNow, 0, 0);
            

        }

        private void btnStep3Start_Click(object sender, EventArgs e)
        {
            dp1 = new drawProcess(this.pictureBox2.Width, this.pictureBox2.Height, Color.DarkCyan);
            dp2 = new drawProcess(this.pictureBox3.Width, this.pictureBox3.Height, Color.DarkCyan);
            //for (int i = 0; i < 6; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        trainOrTestForTest.Add(true);
            //    }
            //    else
            //    {
            //        trainOrTestForTest.Add(false);
            //    }

            //    experimentTimeForTest.Add(300);


            //}

            if (tbExperimentName.Text == "")
            {
                MessageBox.Show("ExpName is NULL");
            }
            else
            {
                lpf3.Clear();
                lpf4.Clear();
                positionForEverySequence.Clear();
                torqueForEverySequence.Clear();
                sequenceIndexForExperiment = 0;
                this.flpTopForLabel.Controls.Clear();
                this.flpBottomForImageList.Controls.Clear();
                int controlsLength;
                if (cbSetSeqChoosed_1.Checked)
                {
                    controlsLength = trainOrTest_1.Count;
                    trainOrTestUsed = trainOrTest_1;
                    experimentTimeUsed = experimentTime_1;
                }
                else if (cbSetSeqChoosed_2.Checked)
                {
                    controlsLength = trainOrTest_2.Count;
                    trainOrTestUsed = trainOrTest_2;
                    experimentTimeUsed = experimentTime_2;
                }
                else
                {
                    controlsLength = trainOrTest_3.Count;
                    trainOrTestUsed = trainOrTest_3;
                    experimentTimeUsed = experimentTime_3;
                }


                dp1.getTrainOrTestSequence(trainOrTestUsed);
                dp2.getTrainOrTestSequence(trainOrTestUsed);

                controls = new List<Control>();
                for (int i = 0; i < controlsLength; i++)
                {
                    Label l = new Label();
                    l.Name = "lblDForSequence" + i.ToString();
                    l.AutoSize = true;
                    l.BorderStyle = BorderStyle.FixedSingle;
                    l.Margin = new System.Windows.Forms.Padding(3);
                    l.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    if (trainOrTestUsed[i] == true)
                    {
                        l.Text = "Tr: " + experimentTimeUsed[i].ToString();
                    }
                    else
                    {
                        l.Text = "Te: " + experimentTimeUsed[i].ToString();
                    }
                    controls.Add(l);

                    this.flpTopForLabel.Controls.Add(l);
                }
                controls[0].BackColor = Color.DarkCyan;

                positionForEverySequence.Add(new List<float>());
                torqueForEverySequence.Add(new List<float>());
                ifBreakTime = true;
                degreeForClosedLoop = 0;
           
                gg = new Generator(this.vf.Width, this.vf.Height);
                gg.SetSimpleCanvas();
                gg.setBigAndSmallStimulus();


                timer4.Start();
                timer1.Stop();
                this.btnStep3Start.Enabled = false;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tpStep1_Click(object sender, EventArgs e)
        {

        }

        private void lblSecondOrMinute_1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSeOrMi_1_Click(object sender, EventArgs e)
        {
            if (isSecond_1)
            {
                this.btnSeOrMi_1.Text = "M";
                isSecond_1 = false;
            }
            else
            {
                this.btnSeOrMi_1.Text = "S";
                isSecond_1 = true;
            }
        }

        private void btnSeOrMi_2_Click(object sender, EventArgs e)
        {
            if (isSecond_2)
            {
                this.btnSeOrMi_2.Text = "M";
                isSecond_2 = false;
            }
            else
            {
                this.btnSeOrMi_2.Text = "S";
                isSecond_2 = true;
            }
        }

        private void btnSeOrMi_3_Click(object sender, EventArgs e)
        {
            if (isSecond_3)
            {
                this.btnSeOrMi_3.Text = "M";
                isSecond_3 = false;
            }
            else
            {
                this.btnSeOrMi_3.Text = "S";
                isSecond_3 = true;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void resultBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultBrowser rb = new ResultBrowser();
            rb.Show();
        }

        private void btnSetSequenceSave_1_Click(object sender, EventArgs e)
        {
            if (trainOrTest_1.Count == 0)
            {
                MessageBox.Show("Not item found");
            }
            else
            {
               
                    FileStream fs1 = new FileStream(Application.StartupPath + "\\set-1.txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                    StreamWriter sw = new StreamWriter(fs1);
                    sw.WriteLine(trainOrTest_1.Count);//开始写入值
                    for (int i = 0; i < trainOrTest_1.Count; i++)
                    {
                        if (trainOrTest_1[i] == true)
                        {
                            sw.WriteLine("Train");
                            sw.WriteLine(experimentTime_1[i].ToString());

                        }
                        else
                        {
                            sw.WriteLine("Test");
                            sw.WriteLine(experimentTime_1[i].ToString());
                        }
                    }

                    sw.Close();
                    fs1.Close();


            }
          







            
        }

        private void btnSetSequenceSave_2_Click(object sender, EventArgs e)
        {
            if (trainOrTest_2.Count == 0)
            {
                MessageBox.Show("Not item found");
            }
            else
            {

                FileStream fs1 = new FileStream(Application.StartupPath + "\\set-2.txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine(trainOrTest_2.Count);//开始写入值
                for (int i = 0; i < trainOrTest_2.Count; i++)
                {
                    if (trainOrTest_2[i] == true)
                    {
                        sw.WriteLine("Train");
                        sw.WriteLine(experimentTime_2[i].ToString());

                    }
                    else
                    {
                        sw.WriteLine("Test");
                        sw.WriteLine(experimentTime_2[i].ToString());
                    }
                }

                sw.Close();
                fs1.Close();


            }




        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void createRecordFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecordFileSetting rfs = new RecordFileSetting();
            rfs.Show();
        }

        private void debugModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (debugModeToolStripMenuItem.Checked)
            {
                debugModeToolStripMenuItem.Checked = false;
                ifStartDebugMode = false;
            }
            else
            {
                debugModeToolStripMenuItem.Checked = true;
                ifStartDebugMode = true;
            }
        }

       

       


        //private void backToZeroTimer()
        //{
        //    timeBeginPeriod(1);
        //    uint start = timeGetTime();
        //    uint newStart;

        //    while (!isTheardCircleClosed)
        //    {

        //        float positionVoltageValue;
        //        endPosition = float.Parse(pc.AnalogInput(0, out positionVoltageValue));

        //        timeCount++;
        //        if (timeCount > 100)
        //        {
        //            if (UpOrDown)
        //            {
        //                if (endPosition > iniPosition)
        //                {

        //                    isTheardCircleClosed = true;
        //                    newStart = timeGetTime();
        //                    timeSpent = newStart - start;
        //                    this.lblTimespan.Text = timeSpent.ToString();
        //                    pc.VOutput(0, 2.5f);
        //                    Close();
        //                    timer1.Stop();
        //                    t.Abort();

        //                }
        //            }
        //            else
        //            {
        //                if (endPosition < iniPosition)
        //                {

        //                    isTheardCircleClosed = true;
        //                    newStart = timeGetTime();
        //                    timeSpent = newStart - start;
        //                    this.lblTimespan.Text = timeSpent.ToString();
        //                    pc.VOutput(0, 2.5f);
        //                    Close();
        //                    timer1.Stop();
        //                    t.Abort();
        //                }
        //            }
        //        }

        //    }


        //}


        private bool ifBackToZeroStop = true;
        private void btnBack_Click(object sender, EventArgs e)
        {

            OpenLoop();
            timeBeginPeriod(1);
            uint start = timeGetTime();
            uint newStart;
            int count = 0;
            int i = 0, j = 0;
            ifBackToZeroStop = false;


            while (!ifBackToZeroStop)
            {
                Application.DoEvents();
                newStart = timeGetTime();

                if (newStart - start >= 5)
                {

                    count++;
                    start = newStart;


                    float positionVoltageValue;
                    float position = float.Parse(pc.AnalogInput10(0, out positionVoltageValue));
                    if (position < 1744)
                    {
                        backToZeroControlSwitch = true;
                        if (Math.Abs(position - 1744) > 30)
                        {
                            pc.VOutput(0, 3f);
                        }
                        else
                        {

                            pc.VOutput(0, 2.52f);
                        }

                        if (Math.Abs(position - 1744) < 2)
                        {
                            pc.VOutput(0, 2.5f);
                            ifBackToZeroStop = true;
                        }
                       
                    }
                    else
                    {
                        backToZeroControlSwitch = false;
                        if (Math.Abs(position - 1744) > 30)
                        {
                            pc.VOutput(0, 2f);
                        }
                        else
                        {
                            pc.VOutput(0, 2.48f);

                        }

                        if (Math.Abs(position - 1744) < 2)
                        {
                            pc.VOutput(0, 2.5f);
                            ifBackToZeroStop = true;
                        }
                       
                    }

                }



            }



        }

        private void timer3_Tick(object sender, EventArgs e)
        {
           
        }

        private void btnStopRotating_Click(object sender, EventArgs e)
        {
            pc.DigitOutput(3, MccDaq.DigitalLogicState.Low);
            pc.DigitOutput(4, MccDaq.DigitalLogicState.Low);
            pc.DigitOutput(2, MccDaq.DigitalLogicState.Low);
        }

        private void speedDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpeedDetection sd = new SpeedDetection();
            sd.Show();
        }

        private void replayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Replay r = new Replay();
            r.Show();
        }

        private void btnSetSettings_Click(object sender, EventArgs e)
        {

        }

        private void tpSetp3_Click(object sender, EventArgs e)
        {

        }

        private void rbUpT_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl.SelectedIndex == 1 & ifFromTab1ToTab2)
            {
                string dataPath = this.lblDPValue.Text;
                DirectoryInfo folder = new DirectoryInfo(dataPath);
                string expFileName = this.tbExperimentName.Text + ".txt";
                if (folder.GetFiles("*.txt").Length == 0)
                {
                    tabControl.SelectTab(1);
                }
                else
                {
                    foreach (FileInfo file in folder.GetFiles("*.txt"))
                    {
                        if (expFileName.Equals(file.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            DialogResult dr = MessageBox.Show("实验名重复，是否重设？", "是", MessageBoxButtons.OKCancel);
                            if (dr == DialogResult.OK)
                            {
                                tabControl.SelectTab(0);
                            }
                            else
                            {
                                ifFromTab1ToTab2 = false;
                                tabControl.SelectTab(1);
                            }
                        }
                    }
                }
                ifFromTab1ToTab2 = false;
            }
            if (tabControl.SelectedIndex == 0)
            {
                ifFromTab1ToTab2 = true;
            }

            if (tabControl.SelectedIndex == 2)
            {
                timer1.Stop();
            }

        }

        private void btnSaveSettingInStep2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lblChooseDisplay_Click(object sender, EventArgs e)
        {

        }

        private void gbStatelooking_Enter(object sender, EventArgs e)
        {

        }

       
        private void button1_Click_2(object sender, EventArgs e)
        {
            Random rd = new Random();
            int i = rd.Next(0,50);

            float biasValue = i * 0.04f + 2;  //0-50  --->  2-4
            OpenLoop();


            pc.VOutput(0, biasValue);

            time3Count = 0;
            timer3.Interval = 50;
            timer3.Start();
        }

        int time3Count = 0;
        int degree;
        float troque_trans;
        private void timer3_Tick_1(object sender, EventArgs e)
        {
            float torqueVoltageValue;
            float troque = float.Parse(pc.AnalogInput(1, out torqueVoltageValue));
            //troque = troque / 100;

            troque_trans = (troque - 2048) / 2048 * 50;

            degree = 0;
            this.lblPositionValue.Text = degree.ToString();
            this.lblTorqueValue.Text = troque.ToString();
            this.lblTroqueTransValue.Text = troque_trans.ToString();




            lpf1.Add(degree);
            lpf2.Add(troque_trans);

            if (lpf1.Count == 400)
            {
                lpf1.Remove(lpf1[0]);
            }

            if (lpf2.Count == 400)
            {
                lpf2.Remove(lpf2[0]);
            }

            this.pictureBox1.CreateGraphics().DrawImage(dp1.drawSignalCurve(lpf1, lpf2), 0, 0);
        }

        private void btnDegreeUp_Click(object sender, EventArgs e)
        {
            ifDegreeForDebugUp = true;
            ifDegreeForDebugDown = false;
        }
        private float degreeForClosedLoop;
        private Generator gg;
        private void btnClosedTest_Click(object sender, EventArgs e)
        {
            this.timer3.Stop();
            this.timer2.Stop();
            this.gbSetPar.Enabled = true;
            lblChooseDisplay.Visible = true;
            cbIsPosition.Visible = true;
            cbIsTorque.Visible = true;

            degreeForClosedLoop = 0;
            dp1 = new drawProcess(this.pictureBox1.Width, this.pictureBox1.Height, Color.DarkCyan);
            gg = new Generator(this.vf.Width, this.vf.Height);
            gg.SetSimpleCanvas();
            gg.setBigAndSmallStimulus();
            
            timer1.Interval = 50;
            timer1.Start();
        }
        private VisionFigure vf;
        private void btnOpenLoopTest_Click(object sender, EventArgs e)
        {
            this.timer3.Stop();
            this.timer1.Stop();
            this.gbSetPar.Enabled = false;
            lblChooseDisplay.Visible = true;
            cbIsPosition.Visible = true;
            cbIsTorque.Visible = true;


            dp1 = new drawProcess(this.pictureBox1.Width, this.pictureBox1.Height, Color.DarkCyan);
            //vf.timer1.Start();
            timer2.Interval = 50;
            timer2.Start();
        }

        private void btnCalibration_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            timer1.Stop();
            this.gbSetPar.Enabled = false;
            lblChooseDisplay.Visible = true;
            cbIsPosition.Visible = true;
            cbIsTorque.Visible = true;


            dp1 = new drawProcess(this.pictureBox1.Width, this.pictureBox1.Height, Color.DarkCyan);

            timer3.Interval = 50;
            timer3.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.gbSetPar.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer2.Stop();
        }

        private void btnStopRotating_Click_1(object sender, EventArgs e)
        {
            timer3.Stop();
        }


        public int DegreeToPosition(float degree)
        {
            return (int)(degree / 360f * 1024 + 1024 / 2f);

            //-180 to 180   ---> 0 to width
        }


        private float settingDegree = 0;
        private int oritation = 4;
        private void timer2_Tick_1(object sender, EventArgs e)
        {
            float torqueVoltageValue;
            float troque = float.Parse(pc.AnalogInput(1, out torqueVoltageValue));
            //troque = troque / 100;
            troque_trans = (troque - 2048) / 2048 * 50;


            this.lblPositionValue.Text = settingDegree.ToString();

            this.lblTorqueValue.Text = troque.ToString();
            this.lblTroqueTransValue.Text = troque_trans.ToString();

            settingDegree += oritation * 2;

            if (settingDegree > 90)
            {
                oritation = -4;
            }
            if (settingDegree < -90)
            {
                oritation = 4;
            }

            lpf1.Add(settingDegree);
            lpf2.Add(troque_trans);

            //lpf1.Add(180);
            //lpf2.Add(10);
            if (lpf1.Count == 400)
            {
                lpf1.Remove(lpf1[0]);
            }

            if (lpf2.Count == 400)
            {
                lpf2.Remove(lpf2[0]);
            }

            this.pictureBox1.CreateGraphics().DrawImage(dp1.drawSignalCurve(lpf1, lpf2), 0, 0);

            //this.vf.pbCanvas.CreateGraphics().DrawImage(vf.getBlackBarWhiteBackground(settingDegree), 0, 0);


            vf.g2.Clear(Color.White);
            float position = DegreeToPosition(settingDegree);
            vf.g2.FillRectangle(new SolidBrush(Color.Black), position-20, 0,40,vf.Height);
            vf.Refresh();
        }
        private bool ifDegreeForDebugUp = false;
        private bool ifDegreeForDebugDown = false;
        private void btnDegreeDown_Click(object sender, EventArgs e)
        {
            ifDegreeForDebugDown = true;
            ifDegreeForDebugUp = false;
        }
    }
}
