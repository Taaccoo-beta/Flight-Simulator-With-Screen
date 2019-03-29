namespace FlightSimulator
{
    partial class SpeedDetection
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblPositionEndlabel = new System.Windows.Forms.Label();
            this.lblPositionNowValue = new System.Windows.Forms.Label();
            this.tbVoltageValue = new System.Windows.Forms.TextBox();
            this.lblVoltageValue = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblTimespan = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblPositionEndlabel
            // 
            this.lblPositionEndlabel.AutoSize = true;
            this.lblPositionEndlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPositionEndlabel.Location = new System.Drawing.Point(79, 118);
            this.lblPositionEndlabel.Name = "lblPositionEndlabel";
            this.lblPositionEndlabel.Size = new System.Drawing.Size(167, 31);
            this.lblPositionEndlabel.TabIndex = 0;
            this.lblPositionEndlabel.Text = "EndPosition:";
            // 
            // lblPositionNowValue
            // 
            this.lblPositionNowValue.AutoSize = true;
            this.lblPositionNowValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPositionNowValue.Location = new System.Drawing.Point(259, 118);
            this.lblPositionNowValue.Name = "lblPositionNowValue";
            this.lblPositionNowValue.Size = new System.Drawing.Size(84, 31);
            this.lblPositionNowValue.TabIndex = 1;
            this.lblPositionNowValue.Text = "NULL";
            this.lblPositionNowValue.Click += new System.EventHandler(this.lblPositionNowValue_Click);
            // 
            // tbVoltageValue
            // 
            this.tbVoltageValue.Location = new System.Drawing.Point(219, 295);
            this.tbVoltageValue.Name = "tbVoltageValue";
            this.tbVoltageValue.Size = new System.Drawing.Size(100, 20);
            this.tbVoltageValue.TabIndex = 2;
            // 
            // lblVoltageValue
            // 
            this.lblVoltageValue.AutoSize = true;
            this.lblVoltageValue.Location = new System.Drawing.Point(96, 298);
            this.lblVoltageValue.Name = "lblVoltageValue";
            this.lblVoltageValue.Size = new System.Drawing.Size(73, 13);
            this.lblVoltageValue.TabIndex = 3;
            this.lblVoltageValue.Text = "VoltageValue:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(346, 293);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblTimespan
            // 
            this.lblTimespan.AutoSize = true;
            this.lblTimespan.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTimespan.Location = new System.Drawing.Point(259, 180);
            this.lblTimespan.Name = "lblTimespan";
            this.lblTimespan.Size = new System.Drawing.Size(84, 31);
            this.lblTimespan.TabIndex = 7;
            this.lblTimespan.Text = "NULL";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResult.Location = new System.Drawing.Point(105, 180);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(141, 31);
            this.lblResult.TabIndex = 8;
            this.lblResult.Text = "Timespan:";
            // 
            // SpeedDetection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 426);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblTimespan);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblVoltageValue);
            this.Controls.Add(this.tbVoltageValue);
            this.Controls.Add(this.lblPositionNowValue);
            this.Controls.Add(this.lblPositionEndlabel);
            this.Name = "SpeedDetection";
            this.Text = "SpeedDetection";
            this.Load += new System.EventHandler(this.SpeedDetection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblPositionEndlabel;
        private System.Windows.Forms.Label lblPositionNowValue;
        private System.Windows.Forms.TextBox tbVoltageValue;
        private System.Windows.Forms.Label lblVoltageValue;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblTimespan;
        private System.Windows.Forms.Label lblResult;
    }
}