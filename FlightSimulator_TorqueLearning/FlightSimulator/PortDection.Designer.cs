namespace FlightSimulator
{
    partial class PortDection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbDigitOutput_1 = new System.Windows.Forms.GroupBox();
            this.cbHighOrLow = new System.Windows.Forms.CheckBox();
            this.tbPortNumber = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSeedByChoose = new System.Windows.Forms.Button();
            this.gbAnalogOutput = new System.Windows.Forms.GroupBox();
            this.btnTorqueBias = new System.Windows.Forms.Button();
            this.btnRotatinBias = new System.Windows.Forms.Button();
            this.tbTroqueBias = new System.Windows.Forms.TextBox();
            this.tbPrtatingBias = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gbDigitalOutput = new System.Windows.Forms.GroupBox();
            this.cbRotatingBias = new System.Windows.Forms.CheckBox();
            this.cbCloseOpen = new System.Windows.Forms.CheckBox();
            this.cbIntergrator = new System.Windows.Forms.CheckBox();
            this.cbHeat = new System.Windows.Forms.CheckBox();
            this.cbShutter = new System.Windows.Forms.CheckBox();
            this.btnSeedRotating = new System.Windows.Forms.Button();
            this.btnSendClosed = new System.Windows.Forms.Button();
            this.btnSendIntergrator = new System.Windows.Forms.Button();
            this.btnSendHeat = new System.Windows.Forms.Button();
            this.btnSendShutter = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbInputDetection = new System.Windows.Forms.GroupBox();
            this.lblTachoVoltageValue = new System.Windows.Forms.Label();
            this.lblTorqueVoltageValue = new System.Windows.Forms.Label();
            this.lblPositionVoltageValue = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Button();
            this.lblTacho = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTorque = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gbPortDetDigitalOutput = new System.Windows.Forms.GroupBox();
            this.btnPortDetSendSwitchHigh_1 = new System.Windows.Forms.Button();
            this.btnPortDetSendSwitchLow_1 = new System.Windows.Forms.Button();
            this.btnPortDetSendSwitchLow_2 = new System.Windows.Forms.Button();
            this.btnPortDetSendSwitchHigh_2 = new System.Windows.Forms.Button();
            this.btnPortDetSendSwitchLow_3 = new System.Windows.Forms.Button();
            this.btnPortDetSendSwitchHigh_3 = new System.Windows.Forms.Button();
            this.btnPortDetSendSwitchLow_4 = new System.Windows.Forms.Button();
            this.btnPortDetSendSwitchHigh_4 = new System.Windows.Forms.Button();
            this.btnPortDetSendSwitchLow_5 = new System.Windows.Forms.Button();
            this.btnPortDetSendSwitchHigh_5 = new System.Windows.Forms.Button();
            this.lblShutterState = new System.Windows.Forms.Label();
            this.lblHeatState = new System.Windows.Forms.Label();
            this.lblIntergratorState = new System.Windows.Forms.Label();
            this.lblCloseOpenState = new System.Windows.Forms.Label();
            this.lblRotatingBias = new System.Windows.Forms.Label();
            this.gbDigitOutput_1.SuspendLayout();
            this.gbAnalogOutput.SuspendLayout();
            this.gbDigitalOutput.SuspendLayout();
            this.gbInputDetection.SuspendLayout();
            this.gbPortDetDigitalOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDigitOutput_1
            // 
            this.gbDigitOutput_1.Controls.Add(this.cbHighOrLow);
            this.gbDigitOutput_1.Controls.Add(this.tbPortNumber);
            this.gbDigitOutput_1.Controls.Add(this.label11);
            this.gbDigitOutput_1.Controls.Add(this.btnSeedByChoose);
            this.gbDigitOutput_1.Location = new System.Drawing.Point(35, 573);
            this.gbDigitOutput_1.Name = "gbDigitOutput_1";
            this.gbDigitOutput_1.Size = new System.Drawing.Size(466, 67);
            this.gbDigitOutput_1.TabIndex = 14;
            this.gbDigitOutput_1.TabStop = false;
            this.gbDigitOutput_1.Text = "DigitOutput";
            // 
            // cbHighOrLow
            // 
            this.cbHighOrLow.AutoSize = true;
            this.cbHighOrLow.Location = new System.Drawing.Point(225, 31);
            this.cbHighOrLow.Name = "cbHighOrLow";
            this.cbHighOrLow.Size = new System.Drawing.Size(48, 17);
            this.cbHighOrLow.TabIndex = 20;
            this.cbHighOrLow.Text = "High";
            this.cbHighOrLow.UseVisualStyleBackColor = true;
            // 
            // tbPortNumber
            // 
            this.tbPortNumber.Location = new System.Drawing.Point(163, 29);
            this.tbPortNumber.Name = "tbPortNumber";
            this.tbPortNumber.Size = new System.Drawing.Size(47, 20);
            this.tbPortNumber.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(59, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "DigitPortNumber:";
            // 
            // btnSeedByChoose
            // 
            this.btnSeedByChoose.Location = new System.Drawing.Point(305, 30);
            this.btnSeedByChoose.Name = "btnSeedByChoose";
            this.btnSeedByChoose.Size = new System.Drawing.Size(99, 20);
            this.btnSeedByChoose.TabIndex = 17;
            this.btnSeedByChoose.Text = "Send";
            this.btnSeedByChoose.UseVisualStyleBackColor = true;
            this.btnSeedByChoose.Click += new System.EventHandler(this.btnSeedByChoose_Click);
            // 
            // gbAnalogOutput
            // 
            this.gbAnalogOutput.Controls.Add(this.btnTorqueBias);
            this.gbAnalogOutput.Controls.Add(this.btnRotatinBias);
            this.gbAnalogOutput.Controls.Add(this.tbTroqueBias);
            this.gbAnalogOutput.Controls.Add(this.tbPrtatingBias);
            this.gbAnalogOutput.Controls.Add(this.label10);
            this.gbAnalogOutput.Controls.Add(this.label9);
            this.gbAnalogOutput.Location = new System.Drawing.Point(35, 175);
            this.gbAnalogOutput.Name = "gbAnalogOutput";
            this.gbAnalogOutput.Size = new System.Drawing.Size(466, 147);
            this.gbAnalogOutput.TabIndex = 13;
            this.gbAnalogOutput.TabStop = false;
            this.gbAnalogOutput.Text = "AnalogOutput";
            // 
            // btnTorqueBias
            // 
            this.btnTorqueBias.Location = new System.Drawing.Point(305, 94);
            this.btnTorqueBias.Name = "btnTorqueBias";
            this.btnTorqueBias.Size = new System.Drawing.Size(99, 20);
            this.btnTorqueBias.TabIndex = 12;
            this.btnTorqueBias.Text = "Send";
            this.btnTorqueBias.UseVisualStyleBackColor = true;
            this.btnTorqueBias.Click += new System.EventHandler(this.btnTorqueBias_Click);
            // 
            // btnRotatinBias
            // 
            this.btnRotatinBias.Location = new System.Drawing.Point(305, 52);
            this.btnRotatinBias.Name = "btnRotatinBias";
            this.btnRotatinBias.Size = new System.Drawing.Size(99, 20);
            this.btnRotatinBias.TabIndex = 11;
            this.btnRotatinBias.Text = "Send";
            this.btnRotatinBias.UseVisualStyleBackColor = true;
            this.btnRotatinBias.Click += new System.EventHandler(this.btnRotatinBias_Click);
            // 
            // tbTroqueBias
            // 
            this.tbTroqueBias.Location = new System.Drawing.Point(173, 94);
            this.tbTroqueBias.Name = "tbTroqueBias";
            this.tbTroqueBias.Size = new System.Drawing.Size(100, 20);
            this.tbTroqueBias.TabIndex = 8;
            // 
            // tbPrtatingBias
            // 
            this.tbPrtatingBias.Location = new System.Drawing.Point(173, 52);
            this.tbPrtatingBias.Name = "tbPrtatingBias";
            this.tbPrtatingBias.Size = new System.Drawing.Size(100, 20);
            this.tbPrtatingBias.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(88, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Torque Bias:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(82, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Rotating Bias:";
            // 
            // gbDigitalOutput
            // 
            this.gbDigitalOutput.Controls.Add(this.gbPortDetDigitalOutput);
            this.gbDigitalOutput.Controls.Add(this.cbRotatingBias);
            this.gbDigitalOutput.Controls.Add(this.cbCloseOpen);
            this.gbDigitalOutput.Controls.Add(this.cbIntergrator);
            this.gbDigitalOutput.Controls.Add(this.cbHeat);
            this.gbDigitalOutput.Controls.Add(this.cbShutter);
            this.gbDigitalOutput.Controls.Add(this.btnSeedRotating);
            this.gbDigitalOutput.Controls.Add(this.btnSendClosed);
            this.gbDigitalOutput.Controls.Add(this.btnSendIntergrator);
            this.gbDigitalOutput.Controls.Add(this.btnSendHeat);
            this.gbDigitalOutput.Controls.Add(this.btnSendShutter);
            this.gbDigitalOutput.Controls.Add(this.label8);
            this.gbDigitalOutput.Controls.Add(this.label7);
            this.gbDigitalOutput.Controls.Add(this.label6);
            this.gbDigitalOutput.Controls.Add(this.label4);
            this.gbDigitalOutput.Controls.Add(this.label2);
            this.gbDigitalOutput.Location = new System.Drawing.Point(35, 328);
            this.gbDigitalOutput.Name = "gbDigitalOutput";
            this.gbDigitalOutput.Size = new System.Drawing.Size(466, 214);
            this.gbDigitalOutput.TabIndex = 12;
            this.gbDigitalOutput.TabStop = false;
            this.gbDigitalOutput.Text = "DigitalOutput";
            // 
            // cbRotatingBias
            // 
            this.cbRotatingBias.AutoSize = true;
            this.cbRotatingBias.Location = new System.Drawing.Point(173, 174);
            this.cbRotatingBias.Name = "cbRotatingBias";
            this.cbRotatingBias.Size = new System.Drawing.Size(48, 17);
            this.cbRotatingBias.TabIndex = 19;
            this.cbRotatingBias.Text = "High";
            this.cbRotatingBias.UseVisualStyleBackColor = true;
            // 
            // cbCloseOpen
            // 
            this.cbCloseOpen.AutoSize = true;
            this.cbCloseOpen.Location = new System.Drawing.Point(173, 139);
            this.cbCloseOpen.Name = "cbCloseOpen";
            this.cbCloseOpen.Size = new System.Drawing.Size(48, 17);
            this.cbCloseOpen.TabIndex = 18;
            this.cbCloseOpen.Text = "High";
            this.cbCloseOpen.UseVisualStyleBackColor = true;
            // 
            // cbIntergrator
            // 
            this.cbIntergrator.AutoSize = true;
            this.cbIntergrator.Location = new System.Drawing.Point(173, 108);
            this.cbIntergrator.Name = "cbIntergrator";
            this.cbIntergrator.Size = new System.Drawing.Size(48, 17);
            this.cbIntergrator.TabIndex = 17;
            this.cbIntergrator.Text = "High";
            this.cbIntergrator.UseVisualStyleBackColor = true;
            // 
            // cbHeat
            // 
            this.cbHeat.AutoSize = true;
            this.cbHeat.Location = new System.Drawing.Point(173, 78);
            this.cbHeat.Name = "cbHeat";
            this.cbHeat.Size = new System.Drawing.Size(48, 17);
            this.cbHeat.TabIndex = 16;
            this.cbHeat.Text = "High";
            this.cbHeat.UseVisualStyleBackColor = true;
            // 
            // cbShutter
            // 
            this.cbShutter.AutoSize = true;
            this.cbShutter.Location = new System.Drawing.Point(173, 44);
            this.cbShutter.Name = "cbShutter";
            this.cbShutter.Size = new System.Drawing.Size(48, 17);
            this.cbShutter.TabIndex = 15;
            this.cbShutter.Text = "High";
            this.cbShutter.UseVisualStyleBackColor = true;
            // 
            // btnSeedRotating
            // 
            this.btnSeedRotating.Location = new System.Drawing.Point(227, 171);
            this.btnSeedRotating.Name = "btnSeedRotating";
            this.btnSeedRotating.Size = new System.Drawing.Size(46, 20);
            this.btnSeedRotating.TabIndex = 14;
            this.btnSeedRotating.Text = "Send";
            this.btnSeedRotating.UseVisualStyleBackColor = true;
            this.btnSeedRotating.Click += new System.EventHandler(this.btnSeedRotating_Click);
            // 
            // btnSendClosed
            // 
            this.btnSendClosed.Location = new System.Drawing.Point(227, 139);
            this.btnSendClosed.Name = "btnSendClosed";
            this.btnSendClosed.Size = new System.Drawing.Size(46, 20);
            this.btnSendClosed.TabIndex = 13;
            this.btnSendClosed.Text = "Send";
            this.btnSendClosed.UseVisualStyleBackColor = true;
            this.btnSendClosed.Click += new System.EventHandler(this.btnSendClosed_Click);
            // 
            // btnSendIntergrator
            // 
            this.btnSendIntergrator.Location = new System.Drawing.Point(227, 108);
            this.btnSendIntergrator.Name = "btnSendIntergrator";
            this.btnSendIntergrator.Size = new System.Drawing.Size(46, 20);
            this.btnSendIntergrator.TabIndex = 12;
            this.btnSendIntergrator.Text = "Send";
            this.btnSendIntergrator.UseVisualStyleBackColor = true;
            this.btnSendIntergrator.Click += new System.EventHandler(this.btnSendIntergrator_Click);
            // 
            // btnSendHeat
            // 
            this.btnSendHeat.Location = new System.Drawing.Point(227, 75);
            this.btnSendHeat.Name = "btnSendHeat";
            this.btnSendHeat.Size = new System.Drawing.Size(46, 20);
            this.btnSendHeat.TabIndex = 11;
            this.btnSendHeat.Text = "Send";
            this.btnSendHeat.UseVisualStyleBackColor = true;
            this.btnSendHeat.Click += new System.EventHandler(this.btnSendHeat_Click);
            // 
            // btnSendShutter
            // 
            this.btnSendShutter.Location = new System.Drawing.Point(227, 41);
            this.btnSendShutter.Name = "btnSendShutter";
            this.btnSendShutter.Size = new System.Drawing.Size(46, 20);
            this.btnSendShutter.TabIndex = 10;
            this.btnSendShutter.Text = "Send";
            this.btnSendShutter.UseVisualStyleBackColor = true;
            this.btnSendShutter.Click += new System.EventHandler(this.btnSendShutter_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(76, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Rotating Bias";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(82, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Close/Open";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Intergrator";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Heat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Shutter";
            // 
            // gbInputDetection
            // 
            this.gbInputDetection.Controls.Add(this.lblTachoVoltageValue);
            this.gbInputDetection.Controls.Add(this.lblTorqueVoltageValue);
            this.gbInputDetection.Controls.Add(this.lblPositionVoltageValue);
            this.gbInputDetection.Controls.Add(this.lblStart);
            this.gbInputDetection.Controls.Add(this.lblTacho);
            this.gbInputDetection.Controls.Add(this.label5);
            this.gbInputDetection.Controls.Add(this.lblTorque);
            this.gbInputDetection.Controls.Add(this.label3);
            this.gbInputDetection.Controls.Add(this.lblPosition);
            this.gbInputDetection.Controls.Add(this.label1);
            this.gbInputDetection.Location = new System.Drawing.Point(35, 12);
            this.gbInputDetection.Name = "gbInputDetection";
            this.gbInputDetection.Size = new System.Drawing.Size(466, 157);
            this.gbInputDetection.TabIndex = 11;
            this.gbInputDetection.TabStop = false;
            this.gbInputDetection.Text = "InputDetection";
            // 
            // lblTachoVoltageValue
            // 
            this.lblTachoVoltageValue.AutoSize = true;
            this.lblTachoVoltageValue.Location = new System.Drawing.Point(213, 109);
            this.lblTachoVoltageValue.Name = "lblTachoVoltageValue";
            this.lblTachoVoltageValue.Size = new System.Drawing.Size(35, 13);
            this.lblTachoVoltageValue.TabIndex = 9;
            this.lblTachoVoltageValue.Text = "NULL";
            // 
            // lblTorqueVoltageValue
            // 
            this.lblTorqueVoltageValue.AutoSize = true;
            this.lblTorqueVoltageValue.Location = new System.Drawing.Point(213, 73);
            this.lblTorqueVoltageValue.Name = "lblTorqueVoltageValue";
            this.lblTorqueVoltageValue.Size = new System.Drawing.Size(35, 13);
            this.lblTorqueVoltageValue.TabIndex = 8;
            this.lblTorqueVoltageValue.Text = "NULL";
            // 
            // lblPositionVoltageValue
            // 
            this.lblPositionVoltageValue.AutoSize = true;
            this.lblPositionVoltageValue.Location = new System.Drawing.Point(213, 41);
            this.lblPositionVoltageValue.Name = "lblPositionVoltageValue";
            this.lblPositionVoltageValue.Size = new System.Drawing.Size(35, 13);
            this.lblPositionVoltageValue.TabIndex = 7;
            this.lblPositionVoltageValue.Text = "NULL";
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(305, 63);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(99, 33);
            this.lblStart.TabIndex = 6;
            this.lblStart.Text = "Start";
            this.lblStart.UseVisualStyleBackColor = true;
            this.lblStart.Click += new System.EventHandler(this.lblStart_Click);
            // 
            // lblTacho
            // 
            this.lblTacho.AutoSize = true;
            this.lblTacho.Location = new System.Drawing.Point(154, 109);
            this.lblTacho.Name = "lblTacho";
            this.lblTacho.Size = new System.Drawing.Size(35, 13);
            this.lblTacho.TabIndex = 5;
            this.lblTacho.Text = "NULL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tacho:";
            // 
            // lblTorque
            // 
            this.lblTorque.AutoSize = true;
            this.lblTorque.Location = new System.Drawing.Point(154, 73);
            this.lblTorque.Name = "lblTorque";
            this.lblTorque.Size = new System.Drawing.Size(35, 13);
            this.lblTorque.TabIndex = 3;
            this.lblTorque.Text = "NULL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Torque:";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(154, 41);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(35, 13);
            this.lblPosition.TabIndex = 1;
            this.lblPosition.Text = "NULL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Position:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gbPortDetDigitalOutput
            // 
            this.gbPortDetDigitalOutput.Controls.Add(this.lblRotatingBias);
            this.gbPortDetDigitalOutput.Controls.Add(this.lblCloseOpenState);
            this.gbPortDetDigitalOutput.Controls.Add(this.lblIntergratorState);
            this.gbPortDetDigitalOutput.Controls.Add(this.lblHeatState);
            this.gbPortDetDigitalOutput.Controls.Add(this.lblShutterState);
            this.gbPortDetDigitalOutput.Controls.Add(this.btnPortDetSendSwitchLow_5);
            this.gbPortDetDigitalOutput.Controls.Add(this.btnPortDetSendSwitchHigh_5);
            this.gbPortDetDigitalOutput.Controls.Add(this.btnPortDetSendSwitchLow_4);
            this.gbPortDetDigitalOutput.Controls.Add(this.btnPortDetSendSwitchHigh_4);
            this.gbPortDetDigitalOutput.Controls.Add(this.btnPortDetSendSwitchLow_3);
            this.gbPortDetDigitalOutput.Controls.Add(this.btnPortDetSendSwitchHigh_3);
            this.gbPortDetDigitalOutput.Controls.Add(this.btnPortDetSendSwitchLow_2);
            this.gbPortDetDigitalOutput.Controls.Add(this.btnPortDetSendSwitchHigh_2);
            this.gbPortDetDigitalOutput.Controls.Add(this.btnPortDetSendSwitchLow_1);
            this.gbPortDetDigitalOutput.Controls.Add(this.btnPortDetSendSwitchHigh_1);
            this.gbPortDetDigitalOutput.Location = new System.Drawing.Point(294, 19);
            this.gbPortDetDigitalOutput.Name = "gbPortDetDigitalOutput";
            this.gbPortDetDigitalOutput.Size = new System.Drawing.Size(166, 189);
            this.gbPortDetDigitalOutput.TabIndex = 15;
            this.gbPortDetDigitalOutput.TabStop = false;
            this.gbPortDetDigitalOutput.Text = "SendSwitch";
            // 
            // btnPortDetSendSwitchHigh_1
            // 
            this.btnPortDetSendSwitchHigh_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPortDetSendSwitchHigh_1.Location = new System.Drawing.Point(6, 22);
            this.btnPortDetSendSwitchHigh_1.Name = "btnPortDetSendSwitchHigh_1";
            this.btnPortDetSendSwitchHigh_1.Size = new System.Drawing.Size(46, 20);
            this.btnPortDetSendSwitchHigh_1.TabIndex = 11;
            this.btnPortDetSendSwitchHigh_1.Text = "High";
            this.btnPortDetSendSwitchHigh_1.UseVisualStyleBackColor = true;
            this.btnPortDetSendSwitchHigh_1.Click += new System.EventHandler(this.btnPortDetSendSwitchHigh_1_Click);
            // 
            // btnPortDetSendSwitchLow_1
            // 
            this.btnPortDetSendSwitchLow_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPortDetSendSwitchLow_1.Location = new System.Drawing.Point(58, 21);
            this.btnPortDetSendSwitchLow_1.Name = "btnPortDetSendSwitchLow_1";
            this.btnPortDetSendSwitchLow_1.Size = new System.Drawing.Size(46, 20);
            this.btnPortDetSendSwitchLow_1.TabIndex = 12;
            this.btnPortDetSendSwitchLow_1.Text = "Low";
            this.btnPortDetSendSwitchLow_1.UseVisualStyleBackColor = true;
            this.btnPortDetSendSwitchLow_1.Click += new System.EventHandler(this.btnPortDetSendSwitchLow_1_Click);
            // 
            // btnPortDetSendSwitchLow_2
            // 
            this.btnPortDetSendSwitchLow_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPortDetSendSwitchLow_2.Location = new System.Drawing.Point(58, 55);
            this.btnPortDetSendSwitchLow_2.Name = "btnPortDetSendSwitchLow_2";
            this.btnPortDetSendSwitchLow_2.Size = new System.Drawing.Size(46, 20);
            this.btnPortDetSendSwitchLow_2.TabIndex = 14;
            this.btnPortDetSendSwitchLow_2.Text = "Low";
            this.btnPortDetSendSwitchLow_2.UseVisualStyleBackColor = true;
            this.btnPortDetSendSwitchLow_2.Click += new System.EventHandler(this.btnPortDetSendSwitchLow_2_Click);
            // 
            // btnPortDetSendSwitchHigh_2
            // 
            this.btnPortDetSendSwitchHigh_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPortDetSendSwitchHigh_2.Location = new System.Drawing.Point(6, 55);
            this.btnPortDetSendSwitchHigh_2.Name = "btnPortDetSendSwitchHigh_2";
            this.btnPortDetSendSwitchHigh_2.Size = new System.Drawing.Size(46, 20);
            this.btnPortDetSendSwitchHigh_2.TabIndex = 13;
            this.btnPortDetSendSwitchHigh_2.Text = "High";
            this.btnPortDetSendSwitchHigh_2.UseVisualStyleBackColor = true;
            this.btnPortDetSendSwitchHigh_2.Click += new System.EventHandler(this.btnPortDetSendSwitchHigh_2_Click);
            // 
            // btnPortDetSendSwitchLow_3
            // 
            this.btnPortDetSendSwitchLow_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPortDetSendSwitchLow_3.Location = new System.Drawing.Point(58, 89);
            this.btnPortDetSendSwitchLow_3.Name = "btnPortDetSendSwitchLow_3";
            this.btnPortDetSendSwitchLow_3.Size = new System.Drawing.Size(46, 20);
            this.btnPortDetSendSwitchLow_3.TabIndex = 16;
            this.btnPortDetSendSwitchLow_3.Text = "Low";
            this.btnPortDetSendSwitchLow_3.UseVisualStyleBackColor = true;
            this.btnPortDetSendSwitchLow_3.Click += new System.EventHandler(this.btnPortDetSendSwitchLow_3_Click);
            // 
            // btnPortDetSendSwitchHigh_3
            // 
            this.btnPortDetSendSwitchHigh_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPortDetSendSwitchHigh_3.Location = new System.Drawing.Point(6, 89);
            this.btnPortDetSendSwitchHigh_3.Name = "btnPortDetSendSwitchHigh_3";
            this.btnPortDetSendSwitchHigh_3.Size = new System.Drawing.Size(46, 20);
            this.btnPortDetSendSwitchHigh_3.TabIndex = 15;
            this.btnPortDetSendSwitchHigh_3.Text = "High";
            this.btnPortDetSendSwitchHigh_3.UseVisualStyleBackColor = true;
            this.btnPortDetSendSwitchHigh_3.Click += new System.EventHandler(this.btnPortDetSendSwitchHigh_3_Click);
            // 
            // btnPortDetSendSwitchLow_4
            // 
            this.btnPortDetSendSwitchLow_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPortDetSendSwitchLow_4.Location = new System.Drawing.Point(58, 120);
            this.btnPortDetSendSwitchLow_4.Name = "btnPortDetSendSwitchLow_4";
            this.btnPortDetSendSwitchLow_4.Size = new System.Drawing.Size(46, 20);
            this.btnPortDetSendSwitchLow_4.TabIndex = 18;
            this.btnPortDetSendSwitchLow_4.Text = "Low";
            this.btnPortDetSendSwitchLow_4.UseVisualStyleBackColor = true;
            this.btnPortDetSendSwitchLow_4.Click += new System.EventHandler(this.btnPortDetSendSwitchLow_4_Click);
            // 
            // btnPortDetSendSwitchHigh_4
            // 
            this.btnPortDetSendSwitchHigh_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPortDetSendSwitchHigh_4.Location = new System.Drawing.Point(6, 120);
            this.btnPortDetSendSwitchHigh_4.Name = "btnPortDetSendSwitchHigh_4";
            this.btnPortDetSendSwitchHigh_4.Size = new System.Drawing.Size(46, 20);
            this.btnPortDetSendSwitchHigh_4.TabIndex = 17;
            this.btnPortDetSendSwitchHigh_4.Text = "High";
            this.btnPortDetSendSwitchHigh_4.UseVisualStyleBackColor = true;
            this.btnPortDetSendSwitchHigh_4.Click += new System.EventHandler(this.btnPortDetSendSwitchHigh_4_Click);
            // 
            // btnPortDetSendSwitchLow_5
            // 
            this.btnPortDetSendSwitchLow_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPortDetSendSwitchLow_5.Location = new System.Drawing.Point(58, 152);
            this.btnPortDetSendSwitchLow_5.Name = "btnPortDetSendSwitchLow_5";
            this.btnPortDetSendSwitchLow_5.Size = new System.Drawing.Size(46, 20);
            this.btnPortDetSendSwitchLow_5.TabIndex = 20;
            this.btnPortDetSendSwitchLow_5.Text = "Low";
            this.btnPortDetSendSwitchLow_5.UseVisualStyleBackColor = true;
            this.btnPortDetSendSwitchLow_5.Click += new System.EventHandler(this.btnPortDetSendSwitchLow_5_Click);
            // 
            // btnPortDetSendSwitchHigh_5
            // 
            this.btnPortDetSendSwitchHigh_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPortDetSendSwitchHigh_5.Location = new System.Drawing.Point(6, 152);
            this.btnPortDetSendSwitchHigh_5.Name = "btnPortDetSendSwitchHigh_5";
            this.btnPortDetSendSwitchHigh_5.Size = new System.Drawing.Size(46, 20);
            this.btnPortDetSendSwitchHigh_5.TabIndex = 19;
            this.btnPortDetSendSwitchHigh_5.Text = "High";
            this.btnPortDetSendSwitchHigh_5.UseVisualStyleBackColor = true;
            this.btnPortDetSendSwitchHigh_5.Click += new System.EventHandler(this.btnPortDetSendSwitchHigh_5_Click);
            // 
            // lblShutterState
            // 
            this.lblShutterState.AutoSize = true;
            this.lblShutterState.Location = new System.Drawing.Point(110, 25);
            this.lblShutterState.Name = "lblShutterState";
            this.lblShutterState.Size = new System.Drawing.Size(27, 13);
            this.lblShutterState.TabIndex = 21;
            this.lblShutterState.Text = "Low";
            // 
            // lblHeatState
            // 
            this.lblHeatState.AutoSize = true;
            this.lblHeatState.Location = new System.Drawing.Point(110, 58);
            this.lblHeatState.Name = "lblHeatState";
            this.lblHeatState.Size = new System.Drawing.Size(27, 13);
            this.lblHeatState.TabIndex = 22;
            this.lblHeatState.Text = "Low";
            // 
            // lblIntergratorState
            // 
            this.lblIntergratorState.AutoSize = true;
            this.lblIntergratorState.Location = new System.Drawing.Point(110, 92);
            this.lblIntergratorState.Name = "lblIntergratorState";
            this.lblIntergratorState.Size = new System.Drawing.Size(27, 13);
            this.lblIntergratorState.TabIndex = 23;
            this.lblIntergratorState.Text = "Low";
            // 
            // lblCloseOpenState
            // 
            this.lblCloseOpenState.AutoSize = true;
            this.lblCloseOpenState.Location = new System.Drawing.Point(110, 123);
            this.lblCloseOpenState.Name = "lblCloseOpenState";
            this.lblCloseOpenState.Size = new System.Drawing.Size(27, 13);
            this.lblCloseOpenState.TabIndex = 24;
            this.lblCloseOpenState.Text = "Low";
            // 
            // lblRotatingBias
            // 
            this.lblRotatingBias.AutoSize = true;
            this.lblRotatingBias.Location = new System.Drawing.Point(110, 156);
            this.lblRotatingBias.Name = "lblRotatingBias";
            this.lblRotatingBias.Size = new System.Drawing.Size(27, 13);
            this.lblRotatingBias.TabIndex = 25;
            this.lblRotatingBias.Text = "Low";
            // 
            // PortDection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 652);
            this.Controls.Add(this.gbDigitOutput_1);
            this.Controls.Add(this.gbAnalogOutput);
            this.Controls.Add(this.gbDigitalOutput);
            this.Controls.Add(this.gbInputDetection);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "PortDection";
            this.Text = "PortDection";
            this.Load += new System.EventHandler(this.PortDection_Load);
            this.gbDigitOutput_1.ResumeLayout(false);
            this.gbDigitOutput_1.PerformLayout();
            this.gbAnalogOutput.ResumeLayout(false);
            this.gbAnalogOutput.PerformLayout();
            this.gbDigitalOutput.ResumeLayout(false);
            this.gbDigitalOutput.PerformLayout();
            this.gbInputDetection.ResumeLayout(false);
            this.gbInputDetection.PerformLayout();
            this.gbPortDetDigitalOutput.ResumeLayout(false);
            this.gbPortDetDigitalOutput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDigitOutput_1;
        private System.Windows.Forms.CheckBox cbHighOrLow;
        private System.Windows.Forms.TextBox tbPortNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSeedByChoose;
        private System.Windows.Forms.GroupBox gbAnalogOutput;
        private System.Windows.Forms.Button btnTorqueBias;
        private System.Windows.Forms.Button btnRotatinBias;
        private System.Windows.Forms.TextBox tbTroqueBias;
        private System.Windows.Forms.TextBox tbPrtatingBias;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbDigitalOutput;
        private System.Windows.Forms.CheckBox cbRotatingBias;
        private System.Windows.Forms.CheckBox cbCloseOpen;
        private System.Windows.Forms.CheckBox cbIntergrator;
        private System.Windows.Forms.CheckBox cbHeat;
        private System.Windows.Forms.CheckBox cbShutter;
        private System.Windows.Forms.Button btnSeedRotating;
        private System.Windows.Forms.Button btnSendClosed;
        private System.Windows.Forms.Button btnSendIntergrator;
        private System.Windows.Forms.Button btnSendHeat;
        private System.Windows.Forms.Button btnSendShutter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbInputDetection;
        private System.Windows.Forms.Label lblTachoVoltageValue;
        private System.Windows.Forms.Label lblTorqueVoltageValue;
        private System.Windows.Forms.Label lblPositionVoltageValue;
        private System.Windows.Forms.Button lblStart;
        private System.Windows.Forms.Label lblTacho;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTorque;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox gbPortDetDigitalOutput;
        private System.Windows.Forms.Label lblRotatingBias;
        private System.Windows.Forms.Label lblCloseOpenState;
        private System.Windows.Forms.Label lblIntergratorState;
        private System.Windows.Forms.Label lblHeatState;
        private System.Windows.Forms.Label lblShutterState;
        private System.Windows.Forms.Button btnPortDetSendSwitchLow_5;
        private System.Windows.Forms.Button btnPortDetSendSwitchHigh_5;
        private System.Windows.Forms.Button btnPortDetSendSwitchLow_4;
        private System.Windows.Forms.Button btnPortDetSendSwitchHigh_4;
        private System.Windows.Forms.Button btnPortDetSendSwitchLow_3;
        private System.Windows.Forms.Button btnPortDetSendSwitchHigh_3;
        private System.Windows.Forms.Button btnPortDetSendSwitchLow_2;
        private System.Windows.Forms.Button btnPortDetSendSwitchHigh_2;
        private System.Windows.Forms.Button btnPortDetSendSwitchLow_1;
        private System.Windows.Forms.Button btnPortDetSendSwitchHigh_1;
    }
}