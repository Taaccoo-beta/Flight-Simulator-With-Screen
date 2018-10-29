using rorationSimulation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XControl;

namespace Flight_Simulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("winmm")]
        static extern uint timeGetTime();

        [DllImport("winmm")]
        static extern void timeBeginPeriod(int t);
        [DllImport("winmm")]
        static extern void timeEndPeriod(int t);

        [DllImport("kernel32.dll ")]
        static extern bool QueryPerformanceCounter(ref long lpPerformanceCount);

        [DllImport("kernel32")]
        static extern bool QueryPerformanceFrequency(ref long PerformanceFrequency);
        private Player p;
        private void button1_Click(object sender, EventArgs e)
        {
            //vlcControl1.SetMedia(new FileInfo("d:/video/1.avi"));
            //vlcControl1.Play();
            ////this.label1.Text = vlcControl1.GetCurrentMedia().Duration.TotalSeconds.ToString();
            ////this.timer1.Interval = 100;
            ////this.timer1.Start();
            p = new Player();
            p.vlcControl1.SetMedia(new FileInfo("d:/video/1.avi"));
            p.Show();
            p.vlcControl1.Play();


            //p.vlcControl1.SetMedia(new FileInfo("d:/video/2.avi"));
            //p.vlcControl1.Play();
        }
        bool ifEnd = true;

        private void vlcControl1_EndReached(object sender, Vlc.DotNet.Core.VlcMediaPlayerEndReachedEventArgs e)
        {
            p.vlcControl1.SetMedia(new FileInfo("d:/video/1.avi"));
            p.vlcControl1.Play();
        }

        bool ifStop = false;
        private void button2_Click(object sender, EventArgs e)
        {

        }


        private PortControl pc;
        private float troque_trans;
        private float degreeForClosedLoop = 0;
        private List<float> lpf1 = new List<float>();
        private List<float> lpf2 = new List<float>();

        private List<float> lpf3 = new List<float>();
        private List<float> lpf4 = new List<float>();
        drawProcess dp;
        drawProcess dp1;
        drawProcess dp2;

        private CoreControl cc;
        private VisionFigure vf;
        private float bias;
        private void timer1_Tick(object sender, EventArgs e)
        {

            float torqueVoltageValue;
            float troque = float.Parse(pc.AnalogInput(1, out torqueVoltageValue));
            //troque = troque / 100;
            troque_trans = (troque - 2048) / 2048 *50;


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
                degreeForClosedLoop = 360 - degreeForClosedLoop;
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

            this.vf.pbCanvas.CreateGraphics().DrawImage(vf.getBlackBarWhiteBackground(degreeForClosedLoop), 0, 0);




        }
        private List<int> expSequence;
        private void Form1_Load(object sender, EventArgs e)
        {
            sequenceFileName_1 = new List<string>();
            sequenceFilePath_1 = new List<string>();
            sequenceFileTime_1 = new List<double>();

            sequenceFileName_2 = new List<string>();
            sequenceFilePath_2 = new List<string>();
            sequenceFileTime_2 = new List<double>();

            sequenceFileName_3 = new List<string>();
            sequenceFilePath_3 = new List<string>();
            sequenceFileTime_3 = new List<double>();
            //-------------read video path
            try
            {
                StreamReader sR = File.OpenText(Application.StartupPath + "\\FileName_1.txt");
                int length = int.Parse(sR.ReadLine());
                for (int i = 0; i != length; i++)
                {
                    string temp = sR.ReadLine();
                    this.sequenceFileName_1.Add(temp);
                    this.lbExpSequence_1.Items.Add(temp);
                }
                sR.Close();
                sR = File.OpenText(Application.StartupPath + "\\Path_1.txt");
                length = int.Parse(sR.ReadLine());
                for (int i = 0; i != length; i++)
                {
                    string temp = sR.ReadLine();
                    this.sequenceFilePath_1.Add(temp);
                }


                sR.Close();

                sR = File.OpenText(Application.StartupPath + "\\FileTime_1.txt");
                length = int.Parse(sR.ReadLine());
                for (int i = 0; i != length; i++)
                {
                    string temp = sR.ReadLine();
                    this.sequenceFileTime_1.Add(double.Parse(temp));
                }


                sR.Close();


            }
            catch
            {
                //MessageBox.Show("No Path File");
            }

            try
            {
                StreamReader sR = File.OpenText(Application.StartupPath + "\\FileName_2.txt");
                int length = int.Parse(sR.ReadLine());
                for (int i = 0; i != length; i++)
                {
                    string temp = sR.ReadLine();
                    this.sequenceFileName_2.Add(temp);
                    this.lbExpSequence_2.Items.Add(temp);
                }
                sR.Close();
                sR = File.OpenText(Application.StartupPath + "\\Path_2.txt");
                length = int.Parse(sR.ReadLine());
                for (int i = 0; i != length; i++)
                {
                    string temp = sR.ReadLine();
                    this.sequenceFilePath_2.Add(temp);
                }


                sR.Close();

                sR = File.OpenText(Application.StartupPath + "\\FileTime_2.txt");
                length = int.Parse(sR.ReadLine());
                for (int i = 0; i != length; i++)
                {
                    string temp = sR.ReadLine();
                    this.sequenceFileTime_2.Add(double.Parse(temp));
                }


                sR.Close();


            }
            catch
            {
                // MessageBox.Show("No Path File");
            }

            try
            {
                StreamReader sR = File.OpenText(Application.StartupPath + "\\FileName_3.txt");
                int length = int.Parse(sR.ReadLine());
                for (int i = 0; i != length; i++)
                {
                    string temp = sR.ReadLine();
                    this.sequenceFileName_3.Add(temp);
                    this.lbExpSequence_3.Items.Add(temp);
                }
                sR.Close();
                sR = File.OpenText(Application.StartupPath + "\\Path_3.txt");
                length = int.Parse(sR.ReadLine());
                for (int i = 0; i != length; i++)
                {
                    string temp = sR.ReadLine();
                    this.sequenceFilePath_3.Add(temp);
                }


                sR.Close();

                sR = File.OpenText(Application.StartupPath + "\\FileTime_3.txt");
                length = int.Parse(sR.ReadLine());
                for (int i = 0; i != length; i++)
                {
                    string temp = sR.ReadLine();
                    this.sequenceFileTime_3.Add(double.Parse(temp));
                }


                sR.Close();


            }
            catch
            {
                //MessageBox.Show("No Path File");
            }

            //--end read;

            pc = new PortControl(0);
            pc.AnalogPortConfigurationIn();
            pc.AnalogPortConfigurationOut();
            pc.DigitalConfigurationOut();
            pc.ClearALLDigitalPort();

            torqueData = new Dictionary<int, List<float>>();



            expSequence = new List<int>();

            cc = new CoreControl();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            vf = new VisionFigure();
            vf.Size = new System.Drawing.Size(1038, 400);
            vf.Show();

            vf.Location = new Point(3043, 439);
            //vf.Location = new Point(10, 10);
            vf.pbCanvas.Size = new System.Drawing.Size(1022, 330);
            //vf.Location = new Point(3043, 439);


            p = new Player();
            p.Size = new System.Drawing.Size(1038, 400);
            p.Show();
            //p.Location = new Point(10, 10);
            p.Location = new Point(3043, 439);
            p.vlcControl1.Size = new System.Drawing.Size(1022, 330);
            p.Visible = false;

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

        private List<string> sequenceFilePath_1;
        private List<string> sequenceFileName_1;
        private List<double> sequenceFileTime_1;

        private List<string> sequenceFilePath_2;
        private List<string> sequenceFileName_2;
        private List<double> sequenceFileTime_2;

        private List<string> sequenceFilePath_3;
        private List<string> sequenceFileName_3;
        private List<double> sequenceFileTime_3;

        private void btnSetSAdd_1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();



            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;

                string fileName = path.Substring(path.LastIndexOf("\\") + 1);

                lbExpSequence_1.Items.Add(fileName);
                sequenceFilePath_1.Add(path);
                sequenceFileName_1.Add(fileName);

                p.vlcControl1.SetMedia(new FileInfo(path));
                p.vlcControl1.Play();
                double time = 0;
                while (true)
                {
                    if (p.vlcControl1.GetCurrentMedia().Duration.TotalSeconds > 0)
                    {
                        time = p.vlcControl1.GetCurrentMedia().Duration.TotalSeconds;
                        break;
                    }
                }
                p.vlcControl1.Stop();
                this.lblShowVideoTime_1.Text = time.ToString();
                sequenceFileTime_1.Add(time);
            }


        }

        private void btnSetSDelete_1_Click(object sender, EventArgs e)
        {

            try
            {
                int index = lbExpSequence_1.SelectedIndex;
                lbExpSequence_1.Items.RemoveAt(index);
                sequenceFileName_1.RemoveAt(index);
                sequenceFilePath_1.RemoveAt(index);
                sequenceFileTime_1.RemoveAt(index);
            }
            catch
            {
                MessageBox.Show("No item choosed!");
            }
        }

        private void btnSetSequenceSave_1_Click(object sender, EventArgs e)
        {
            if (sequenceFilePath_1.Count == 0)
            {
                MessageBox.Show("Not item found");
            }
            else
            {

                FileStream fs1 = new FileStream(Application.StartupPath + "\\Path_1.txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);

                sw.WriteLine(sequenceFilePath_1.Count);//开始写入值
                for (int i = 0; i < sequenceFilePath_1.Count; i++)
                {
                    sw.WriteLine(sequenceFilePath_1[i]);
                }

                sw.Close();
                fs1.Close();

                fs1 = new FileStream(Application.StartupPath + "\\FileName_1.txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                sw = new StreamWriter(fs1);

                sw.WriteLine(sequenceFileName_1.Count);//开始写入值
                for (int i = 0; i < sequenceFileName_1.Count; i++)
                {
                    sw.WriteLine(sequenceFileName_1[i]);
                }

                sw.Close();
                fs1.Close();

                fs1 = new FileStream(Application.StartupPath + "\\FileTime_1.txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                sw = new StreamWriter(fs1);

                sw.WriteLine(sequenceFileTime_1.Count);//开始写入值
                for (int i = 0; i < sequenceFileTime_1.Count; i++)
                {
                    sw.WriteLine(sequenceFileTime_1[i]);
                }

                sw.Close();
                fs1.Close();


            }

        }



        private string interVideoFile = "";
        private double interVideoTime;

        private void btnAddIntervalFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();



            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;

                string fileName = path.Substring(path.LastIndexOf("\\") + 1);

                interVideoFile = path;

                p.vlcControl1.SetMedia(new FileInfo(path));
                p.vlcControl1.Play();
                double time = 0;
                while (true)
                {
                    if (p.vlcControl1.GetCurrentMedia().Duration.TotalSeconds > 0)
                    {
                        time = p.vlcControl1.GetCurrentMedia().Duration.TotalSeconds;
                        break;
                    }
                }
                p.vlcControl1.Stop();
                this.lblIntervalFileName.Text = fileName.ToString();
                interVideoTime = time;
            }
        }

        private void btnGoStep_2_Click(object sender, EventArgs e)
        {
            string dataPath = this.lblDPValue.Text;
            DirectoryInfo folder = new DirectoryInfo(dataPath);
            string expFileName = this.tbExperimentName.Text + ".txt";
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
                        this.vf.Visible = true;
                        this.p.Visible = false;
                    }
                }
            }

           
                
        }
        private bool ifFromTab1ToTab2 = true;
        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl.SelectedIndex == 1 & ifFromTab1ToTab2)
            {
                string dataPath = this.lblDPValue.Text;
                DirectoryInfo folder = new DirectoryInfo(dataPath);
                string expFileName = this.tbExperimentName.Text + ".txt";
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
                            tabControl.SelectTab(1);
                            this.vf.Visible = true;
                            p.Visible = false;

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
                timer2.Stop();
                timer1.Stop();
                timer3.Stop();
                vf.Visible = false;

                p = new Player();
                p.Size = new System.Drawing.Size(1038, 400);
                p.Show();

                //vf.Location = new Point(3043, 439);
                //p.Location = new Point(10, 10);
                p.Location = new Point(3043, 439);
                p.vlcControl1.Size = new System.Drawing.Size(1022, 330);

                k = float.Parse(tbKValue.Text);

                if (cbCheckVideo.Checked)
                {
                    if (lblIntervalFileName.Text == "NULL")
                    {
                        MessageBox.Show("NO Video choosed!");
                        tabControl.SelectTab(0);
                    }
                }



            }
        }
        private float k;

        private bool ifDegreeForDebugUp = false;
        private bool ifDegreeForDebugDown = false;
        private void btnDegreeUp_Click(object sender, EventArgs e)
        {
            ifDegreeForDebugUp = true;
            ifDegreeForDebugDown = false;
        }

        private void btnDegreeDown_Click(object sender, EventArgs e)
        {
            ifDegreeForDebugDown = true;
            ifDegreeForDebugUp = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ifDegreeForDebugDown = false;
            ifDegreeForDebugUp = false;
        }

        private void btnGoStep_3_Click(object sender, EventArgs e)
        {
            //timer2.Stop();
            //timer3.Stop();

            vf.Visible = false ;

            p = new Player();
            p.Size = new System.Drawing.Size(1038, 400);
            p.Show();

            //vf.Location = new Point(3043, 439);
            //p.Location = new Point(10, 10);
            p.Location = new Point(3043, 439);
            p.vlcControl1.Size = new System.Drawing.Size(1022, 330);



            tabControl.SelectTab(2);
            k = float.Parse(tbKValue.Text);
            if (cbCheckVideo.Checked)
            {
                if (lblIntervalFileName.Text == "NULL")
                {
                    MessageBox.Show("NO Video choosed!");
                    tabControl.SelectTab(0);
                }
            }
            
                
        }

        private void btnClosedTest_Click(object sender, EventArgs e)
        {
            this.timer3.Stop();
            this.timer2.Stop();
            this.gbSetPar.Enabled = true;
            lblChooseDisplay.Visible = true;
            cbIsPosition.Visible = true;
            cbIsTorque.Visible = true;

            degreeForClosedLoop = float.Parse(tbBiasValue.Text);
            dp1 = new drawProcess(this.pictureBox1.Width, this.pictureBox1.Height, Color.DarkCyan);
            vf.SetRandomPoint();
            timer1.Interval = 50;
            timer1.Start();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.gbSetPar.Enabled = false;
        }

        private void btnCalibrate_Click(object sender, EventArgs e)
        {
            this.timer3.Stop();
            this.timer1.Stop();
            this.gbSetPar.Enabled = false;
            lblChooseDisplay.Visible = true;
            cbIsPosition.Visible = true;
            cbIsTorque.Visible = true;


            dp1 = new drawProcess(this.pictureBox1.Width, this.pictureBox1.Height, Color.DarkCyan);
            vf.SetRandomPoint();
            timer2.Interval = 50;
            timer2.Start();
        }

        private void btnRecorectBias_Click(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer2.Stop();
        }
        private float degree = 0;
        private float settingDegree = 0;
        private void timer3_Tick(object sender, EventArgs e)
        {
            float torqueVoltageValue;
            //float troque = float.Parse(pc.AnalogInput(1, out torqueVoltageValue));
            //troque = troque / 100;
            float troque =2048;
            troque_trans = (troque - 2048) / 2048 * 50;

            degree = 0;
            this.lblPositionValue.Text = settingDegree.ToString();
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

        private void btnStopRotating_Click(object sender, EventArgs e)
        {
            timer3.Stop();
        }

        private float oritation = 5;
        private void timer2_Tick(object sender, EventArgs e)
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
                oritation = -5;
            }
            if (settingDegree < -90)
            {
                oritation = 5;
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

            this.vf.pbCanvas.CreateGraphics().DrawImage(vf.getBlackBarWhiteBackground(settingDegree), 0, 0);




        }


        public int[] getShufferArr(int number)
        {
            int[] arr = new int[number];
            for (int i = 0; i != arr.Length; i++)
            {
                arr[i] = i + 1;
            }


            int k = 0;
            int[] newarr = new int[number];
            while (k < arr.Length)
            {
                int temp = new Random().Next(0, arr.Length);
                if (arr[temp] != 0)
                {
                    newarr[k] = arr[temp];
                    k++;
                    arr[temp] = 0;
                }
            }

            return newarr;

        }


        private Dictionary<int, List<float>> torqueData;
        private int sequenceIndexForExperiment = 0;
        private DrawTorque dt;
        private bool isExpModule = true;
        private bool isInterModule = false;
        private bool ifStartPlay = true;
        private bool ifStartPlayInterval = true;
        private List<string> UsedSequencePath;
        private List<string> UsedSequenceFileName;
        private List<double> UsedSequenceTime;

        private void btnStep3Start_Click(object sender, EventArgs e)
        {
            lblChooseDisplay.Visible = true;
            cbIsPosition.Visible = true;
            cbIsTorque.Visible = true;
            lbShowRandomValue.Items.Clear();

            UsedSequenceFileName = new List<string>();
            UsedSequencePath = new List<string>();
            UsedSequenceTime = new List<double>();
            timeBeginPeriod(1);
            uint start = timeGetTime();
            uint newStart;
            int count = 0;

            ifStop = false;

            dt = new DrawTorque(this.pbPosition.Width, this.pbPosition.Height, Color.DarkCyan);
            dp1 = new drawProcess(this.pbPosition.Width, this.pbPosition.Height, Color.DarkCyan);



            vf.SetRandomPoint();


            lpf4.Clear();
            torqueData.Clear();


            expSequence.Clear();
            sequenceIndexForExperiment = 0;

            //
            double IntervalDuration = double.Parse(tbDuration.Text);
            int TotalCircle = int.Parse(this.tbCircle.Text);
            int circle = 0;



            if (cbSetSeqChoosed_1.Checked)
            {
                UsedSequenceTime = sequenceFileTime_1;
                UsedSequencePath = sequenceFilePath_1;
                UsedSequenceFileName = sequenceFileName_1;
            }
            else if (cbSetSeqChoosed_2.Checked)
            {
                UsedSequenceTime = sequenceFileTime_2;
                UsedSequencePath = sequenceFilePath_2;
                UsedSequenceFileName = sequenceFileName_2;
            }
            else
            {
                UsedSequenceTime = sequenceFileTime_3;
                UsedSequencePath = sequenceFilePath_3;
                UsedSequenceFileName = sequenceFileName_3;
            }
            int[] expOrder = getShufferArr(UsedSequencePath.Count);
            //1-count
            int expIndex = 0;

            string strSequenc = "";
            for (int jj = 0; jj != expOrder.Length; jj++)
            {
                strSequenc += expOrder[jj].ToString();

            }
            lbShowRandomValue.Items.Add(strSequenc);
            strSequenc = "";
            int expID = expOrder[expIndex];

            lblShowDescribe.Text = UsedSequenceFileName[expID - 1];


            //start from 1 for saved file
            torqueData.Add(expID, new List<float>());



            string lblshowDTemp = "";
            this.btnStep3Start.Enabled = false;



            //get closed loop parameters
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

            ifStartPlayInterval = true ;
            ifStartPlay = true;
            isExpModule = true;
            isInterModule = false;
            float troque = 0;
            while (!ifStop)
            {

                Application.DoEvents();
                newStart = timeGetTime();

                if (newStart - start >= 100)
                {


                    float torqueVoltageValue;
                    troque = float.Parse(pc.AnalogInput(1, out torqueVoltageValue));
                    //troque = troque / 100;
                    troque_trans = (troque - 2048) / 2048 * 50;


                    //debug mode
                    //troque_trans = 10;

                    count++;
                    start = newStart;

                    //Wert = p1_c1 * p1_c2 * trq + p1_c3 * p1_c4 * p1_bias_  'p1_c1=0/1 (open closed); p1_c2=+1/-1 (norm/inverted); p1_c3=0/1 (p1_bias on/off); p1_c4=+1/-1 (cw/ccw)
                    //dPsi1 = p1_k * Wert * dt_
                    //ArenaPos1 = ArenaPos1 + dPsi1


                    if (isExpModule)
                    {

                        if (ifStartPlay)
                        {
                            this.p.vlcControl1.SetMedia(new FileInfo(UsedSequencePath[expID - 1]));
                            this.p.vlcControl1.Play();
                            ifStartPlay = false;
                        }




                        this.lblEXPStateTRaw.Text = troque.ToString();
                        this.lblEXPSTateT.Text = troque_trans.ToString();


                        //debug mode
                        //degree += 1;


                        //v.pictureBox1.CreateGraphics().DrawImage(vSti.DrawV_Test(degree), 0, 0);


                        lpf4.Add(troque_trans);
                        //Console.WriteLine(degree);
                        //positionForEverySequence[sequenceIndexForExperiment].Add(settingDegree);
                        //torqueForEverySequence[sequenceIndexForExperiment].Add(troque_trans);

                        torqueData[expID].Add(troque_trans);




                        if (lpf4.Count == 400)
                        {
                            lpf4.Remove(lpf4[0]);
                        }

                        this.pbPosition.CreateGraphics().DrawImage(dt.drawSignalCurve(lpf4), 0, 0);

                        if (count == (int)(UsedSequenceTime[expID - 1] * 10))
                        {
                            count = 0;


                            lpf4.Clear();
                            lpf3.Clear();


                            expIndex++;
                            if (expIndex < UsedSequenceTime.Count)
                            {
                                expID = expOrder[expIndex];
                                lblshowDTemp = sequenceFileName_1[expID - 1];
                                torqueData.Add(expID, new List<float>());

                            }
                            else
                            {
                                ;
                            }
                            isExpModule = false;
                            isInterModule = true;
                            ifStartPlayInterval = true;
                            lblShowDescribe.Text = "InterFigure";


                        }


                        //this.pictureBox2.CreateGraphics().DrawImage(dp1.drawSignalCurve(lpf3, lpf4), 0, 0);


                        //imageNow = dp2.drawCommunitivePoint(degree, false,sequenceIndexForExperiment);
                        //this.pbCommunitive.CreateGraphics().DrawImage(imageNow, 0, 0);



                    }
                    if (isInterModule & cbCheckVideo.Checked)
                    {

                        if (ifStartPlayInterval)
                        {
                            this.p.vlcControl1.SetMedia(new FileInfo(interVideoFile));
                            this.p.vlcControl1.Play();
                            ifStartPlayInterval = false;
                        }
                        lpf4.Add(troque_trans);

                       
                        if (lpf4.Count == 400)
                        {
                            lpf4.Remove(lpf4[0]);
                        }



                        this.lblEXPStateTRaw.Text = troque.ToString();
                        this.lblEXPSTateT.Text = troque_trans.ToString();

                       

                        this.pbPosition.CreateGraphics().DrawImage(dt.drawSignalCurve(lpf4), 0, 0);



                        if (count == (int)(interVideoTime * 10))
                        {
                            count = 0;

                            
                            lpf4.Clear();
                          
                            if (expIndex == UsedSequenceFileName.Count)
                            {


                                DataSave(expOrder, circle);

                                circle++;
                                if (circle == TotalCircle)
                                {
                                    ifStop = true;
                                    this.btnStep3Start.Enabled = true;
                                    pc.ClearALLDigitalPort();
                                    //OpenLoop();


                                }
                                else
                                {


                                    torqueData.Clear();
                                    expOrder = getShufferArr(UsedSequenceFileName.Count);
                                    expIndex = 0;
                                    strSequenc = "";
                                    for (int jj = 0; jj != expOrder.Length; jj++)
                                    {
                                        strSequenc += expOrder[jj].ToString();

                                    }
                                    lbShowRandomValue.Items.Add(strSequenc);

                                    expID = expOrder[expIndex];
                                    lblShowDescribe.Text = UsedSequenceFileName[expID - 1];

                                    torqueData.Add(expID, new List<float>());


                                }
                            }
                            else
                            {
                                this.lblShowDescribe.Text = lblshowDTemp;
                            }
                            isExpModule = true;
                            isInterModule = false;
                            ifStartPlay = true;



                        }





                        this.vf.pbCanvas.CreateGraphics().DrawImage(vf.getBlackBarWhiteBackground(degree), 0, 0);


                    }


                    if (isInterModule & cbCheckCloseLoop.Checked)
                    {


                        p.Visible = false;
                        vf.Visible = true;
                        degree += (troque_trans + bias) * k * 0.02f;

                        lpf3.Add(degree);
                        lpf4.Add(troque_trans);

                        if (lpf3.Count == 400)
                        {
                            lpf3.Remove(lpf3[0]);
                        }

                        if (lpf4.Count == 400)
                        {
                            lpf4.Remove(lpf4[0]);
                        }



                        this.lblEXPStateTRaw.Text = troque.ToString();
                        this.lblEXPSTateT.Text = troque_trans.ToString();

                        if (degree > 180)
                        {
                            degree = degree - 180;
                        }
                        if (degree < -180)
                        {
                            degree = degree + 180;
                        }
                        //debug mode
                        //degree += 1;

                        this.pbPosition.CreateGraphics().DrawImage(dp1.drawSignalCurve(lpf3, lpf4), 0, 0);



                        if (count == (int)(IntervalDuration * 20))
                        {
                            count = 0;

                            lpf3.Clear();
                            lpf4.Clear();
                            p.Visible = true;
                            vf.Visible = false;
                            if (expIndex == UsedSequenceFileName.Count)
                            {


                                DataSave(expOrder, circle);

                                circle++;
                                if (circle == TotalCircle)
                                {
                                    ifStop = true;
                                    this.btnStep3Start.Enabled = true;
                                    pc.ClearALLDigitalPort();
                                    //OpenLoop();


                                }
                                else
                                {


                                    torqueData.Clear();
                                    expOrder = getShufferArr(UsedSequenceFileName.Count);
                                    expIndex = 0;
                                    strSequenc = "";
                                    for (int jj = 0; jj != expOrder.Length; jj++)
                                    {
                                        strSequenc += expOrder[jj].ToString();

                                    }
                                    lbShowRandomValue.Items.Add(strSequenc);

                                    expID = expOrder[expIndex];
                                    lblShowDescribe.Text = UsedSequenceFileName[expID - 1];

                                    torqueData.Add(expID, new List<float>());


                                }
                            }
                            else
                            {
                                this.lblShowDescribe.Text = lblshowDTemp;
                            }
                            isExpModule = true;
                            isInterModule = false;
                            ifStartPlay = true;



                        }





                        this.vf.pbCanvas.CreateGraphics().DrawImage(vf.getBlackBarWhiteBackground(degree), 0, 0);


                    }


                }







            }
        }


        private void DataSave(int[] expOrder, int circleNumber)
        {
            string ExpFinishTime = DateTime.Now.ToString();

            string ExpName = tbExperimentName.Text;

            //positionForEverySequence
            //torqueForEverySequence

            string path = this.lblDPValue.Text.ToString() + "\\" + ExpName + "_" + (circleNumber + 1).ToString() + ".txt";

            SigleExpResultPre serp = new SigleExpResultPre(ExpFinishTime, ExpName, path, torqueData, expOrder);

            serp.showResult();
            serp.Show();


        }





        private void btnEXPStop_Click(object sender, EventArgs e)
        {
            btnStep3Start.Enabled = true;
            ifStop = true;
            p.vlcControl1.Stop();
            p.Visible = true;
            vf.Visible = false;
        }

        private void lbExpSequence_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectIndex = lbExpSequence_1.SelectedIndex;
                this.lblShowVideoTime_1.Text = sequenceFileTime_1[selectIndex].ToString();
            }
            catch
            {
                ;
            }
        }

        private void btnSetSAdd_2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();



            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;

                string fileName = path.Substring(path.LastIndexOf("\\") + 1);

                lbExpSequence_2.Items.Add(fileName);
                sequenceFilePath_2.Add(path);
                sequenceFileName_2.Add(fileName);

                p.vlcControl1.SetMedia(new FileInfo(path));
                p.vlcControl1.Play();
                double time = 0;
                while (true)
                {
                    if (p.vlcControl1.GetCurrentMedia().Duration.TotalSeconds > 0)
                    {
                        time = p.vlcControl1.GetCurrentMedia().Duration.TotalSeconds;
                        break;
                    }
                }
                p.vlcControl1.Stop();
                this.lblShowVideoTime_2.Text = time.ToString();
                sequenceFileTime_2.Add(time);
            }

        }

        private void btnSetSAdd_3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();



            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;

                string fileName = path.Substring(path.LastIndexOf("\\") + 1);

                lbExpSequence_3.Items.Add(fileName);
                sequenceFilePath_3.Add(path);
                sequenceFileName_3.Add(fileName);

                p.vlcControl1.SetMedia(new FileInfo(path));
                p.vlcControl1.Play();
                double time = 0;
                while (true)
                {
                    if (p.vlcControl1.GetCurrentMedia().Duration.TotalSeconds > 0)
                    {
                        time = p.vlcControl1.GetCurrentMedia().Duration.TotalSeconds;
                        break;
                    }
                }
                p.vlcControl1.Stop();
                this.lblShowVideoTime_3.Text = time.ToString();
                sequenceFileTime_3.Add(time);
            }
        }

        private void btnSetSDelete_2_Click(object sender, EventArgs e)
        {
            try
            {
                int index = lbExpSequence_2.SelectedIndex;
                lbExpSequence_2.Items.RemoveAt(index);
                sequenceFileName_2.RemoveAt(index);
                sequenceFilePath_2.RemoveAt(index);
                sequenceFileTime_2.RemoveAt(index);
            }
            catch
            {
                MessageBox.Show("No item choosed!");
            }

        }

        private void btnSetSDelete_3_Click(object sender, EventArgs e)
        {
            try
            {
                int index = lbExpSequence_3.SelectedIndex;
                lbExpSequence_3.Items.RemoveAt(index);
                sequenceFileName_3.RemoveAt(index);
                sequenceFilePath_3.RemoveAt(index);
                sequenceFileTime_3.RemoveAt(index);
            }
            catch
            {

                MessageBox.Show("No item choosed!");

            }
        }

        private void btnSetSequenceSave_2_Click(object sender, EventArgs e)
        {
            if (sequenceFilePath_2.Count == 0)
            {
                MessageBox.Show("Not item found");
            }
            else
            {

                FileStream fs1 = new FileStream(Application.StartupPath + "\\Path_2.txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);

                sw.WriteLine(sequenceFilePath_2.Count);//开始写入值
                for (int i = 0; i < sequenceFilePath_2.Count; i++)
                {
                    sw.WriteLine(sequenceFilePath_2[i]);
                }

                sw.Close();
                fs1.Close();

                fs1 = new FileStream(Application.StartupPath + "\\FileName_2.txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                sw = new StreamWriter(fs1);

                sw.WriteLine(sequenceFileName_2.Count);//开始写入值
                for (int i = 0; i < sequenceFileName_2.Count; i++)
                {
                    sw.WriteLine(sequenceFileName_2[i]);
                }

                sw.Close();
                fs1.Close();

                fs1 = new FileStream(Application.StartupPath + "\\FileTime_2.txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                sw = new StreamWriter(fs1);

                sw.WriteLine(sequenceFileTime_2.Count);//开始写入值
                for (int i = 0; i < sequenceFileTime_2.Count; i++)
                {
                    sw.WriteLine(sequenceFileTime_2[i]);
                }

                sw.Close();
                fs1.Close();


            }
        }

        private void btnSetSequenceSave_3_Click(object sender, EventArgs e)
        {
            if (sequenceFilePath_3.Count == 0)
            {
                MessageBox.Show("Not item found");
            }
            else
            {

                FileStream fs1 = new FileStream(Application.StartupPath + "\\Path_3.txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);

                sw.WriteLine(sequenceFilePath_3.Count);//开始写入值
                for (int i = 0; i < sequenceFilePath_3.Count; i++)
                {
                    sw.WriteLine(sequenceFilePath_3[i]);
                }

                sw.Close();
                fs1.Close();

                fs1 = new FileStream(Application.StartupPath + "\\FileName_3.txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                sw = new StreamWriter(fs1);

                sw.WriteLine(sequenceFileName_3.Count);//开始写入值
                for (int i = 0; i < sequenceFileName_3.Count; i++)
                {
                    sw.WriteLine(sequenceFileName_3[i]);
                }

                sw.Close();
                fs1.Close();

                fs1 = new FileStream(Application.StartupPath + "\\FileTime_3.txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                sw = new StreamWriter(fs1);

                sw.WriteLine(sequenceFileTime_3.Count);//开始写入值
                for (int i = 0; i < sequenceFileTime_3.Count; i++)
                {
                    sw.WriteLine(sequenceFileTime_3[i]);
                }

                sw.Close();
                fs1.Close();


            }
        }

        private void lbExpSequence_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectIndex = lbExpSequence_2.SelectedIndex;
                this.lblShowVideoTime_2.Text = sequenceFileTime_2[selectIndex].ToString();
            }
            catch
            {
                ;
            }
        }

        private void lbExpSequence_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectIndex = lbExpSequence_3.SelectedIndex;
                this.lblShowVideoTime_3.Text = sequenceFileTime_3[selectIndex].ToString();
            }
            catch
            {
                ;
            }
        }

        private void cbSetSeqChoosed_1_Click(object sender, EventArgs e)
        {
            if (cbSetSeqChoosed_1.Checked == true)
            {
                cbSetSeqChoosed_1.Checked = true;
                cbSetSeqChoosed_2.Checked = false;
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

        private void rbNoStimulus_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private Color staticColor;
       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

       

        private void cbCheckVideo_Click(object sender, EventArgs e)
        {
            
            cbCheckCloseLoop.Checked = false;
        }

        private void cbCheckCloseLoop_Click(object sender, EventArgs e)
        {
           
            cbCheckVideo.Checked = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ifStop = false;
        }
    }
}
