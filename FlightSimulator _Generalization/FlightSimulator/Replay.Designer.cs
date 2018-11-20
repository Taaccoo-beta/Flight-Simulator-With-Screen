namespace FlightSimulator
{
    partial class Replay
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblChooseDisplay = new System.Windows.Forms.Label();
            this.cbIsTorque = new System.Windows.Forms.CheckBox();
            this.cbIsPosition = new System.Windows.Forms.CheckBox();
            this.btnTestDrawing = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTorqueValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPositionValue = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(736, 453);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblChooseDisplay
            // 
            this.lblChooseDisplay.AutoSize = true;
            this.lblChooseDisplay.BackColor = System.Drawing.Color.DarkCyan;
            this.lblChooseDisplay.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblChooseDisplay.Location = new System.Drawing.Point(228, 432);
            this.lblChooseDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChooseDisplay.Name = "lblChooseDisplay";
            this.lblChooseDisplay.Size = new System.Drawing.Size(127, 15);
            this.lblChooseDisplay.TabIndex = 24;
            this.lblChooseDisplay.Text = "Choose display:";
            this.lblChooseDisplay.Visible = false;
            // 
            // cbIsTorque
            // 
            this.cbIsTorque.AutoSize = true;
            this.cbIsTorque.BackColor = System.Drawing.Color.DarkCyan;
            this.cbIsTorque.Checked = true;
            this.cbIsTorque.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsTorque.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbIsTorque.Location = new System.Drawing.Point(460, 430);
            this.cbIsTorque.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbIsTorque.Name = "cbIsTorque";
            this.cbIsTorque.Size = new System.Drawing.Size(77, 19);
            this.cbIsTorque.TabIndex = 23;
            this.cbIsTorque.Text = "Torque";
            this.cbIsTorque.UseVisualStyleBackColor = false;
            this.cbIsTorque.Visible = false;
            // 
            // cbIsPosition
            // 
            this.cbIsPosition.AutoSize = true;
            this.cbIsPosition.BackColor = System.Drawing.Color.DarkCyan;
            this.cbIsPosition.Checked = true;
            this.cbIsPosition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsPosition.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbIsPosition.Location = new System.Drawing.Point(358, 430);
            this.cbIsPosition.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbIsPosition.Name = "cbIsPosition";
            this.cbIsPosition.Size = new System.Drawing.Size(93, 19);
            this.cbIsPosition.TabIndex = 22;
            this.cbIsPosition.Text = "Position";
            this.cbIsPosition.UseVisualStyleBackColor = false;
            this.cbIsPosition.Visible = false;
            // 
            // btnTestDrawing
            // 
            this.btnTestDrawing.Location = new System.Drawing.Point(683, 486);
            this.btnTestDrawing.Name = "btnTestDrawing";
            this.btnTestDrawing.Size = new System.Drawing.Size(75, 23);
            this.btnTestDrawing.TabIndex = 25;
            this.btnTestDrawing.Text = "Draw";
            this.btnTestDrawing.UseVisualStyleBackColor = true;
            this.btnTestDrawing.Click += new System.EventHandler(this.btnTestDrawing_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTorqueValue
            // 
            this.lblTorqueValue.AutoSize = true;
            this.lblTorqueValue.Location = new System.Drawing.Point(119, 516);
            this.lblTorqueValue.Name = "lblTorqueValue";
            this.lblTorqueValue.Size = new System.Drawing.Size(39, 15);
            this.lblTorqueValue.TabIndex = 29;
            this.lblTorqueValue.Text = "NULL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 516);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 28;
            this.label3.Text = "Torque:";
            // 
            // lblPositionValue
            // 
            this.lblPositionValue.AutoSize = true;
            this.lblPositionValue.Location = new System.Drawing.Point(119, 486);
            this.lblPositionValue.Name = "lblPositionValue";
            this.lblPositionValue.Size = new System.Drawing.Size(39, 15);
            this.lblPositionValue.TabIndex = 27;
            this.lblPositionValue.Text = "NULL";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(35, 486);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(79, 15);
            this.lblPosition.TabIndex = 26;
            this.lblPosition.Text = "Position:";
            // 
            // Replay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 625);
            this.Controls.Add(this.lblTorqueValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPositionValue);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.btnTestDrawing);
            this.Controls.Add(this.lblChooseDisplay);
            this.Controls.Add(this.cbIsTorque);
            this.Controls.Add(this.cbIsPosition);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Replay";
            this.Text = "Replay";
            this.Load += new System.EventHandler(this.Replay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblChooseDisplay;
        private System.Windows.Forms.CheckBox cbIsTorque;
        private System.Windows.Forms.CheckBox cbIsPosition;
        private System.Windows.Forms.Button btnTestDrawing;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTorqueValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPositionValue;
        private System.Windows.Forms.Label lblPosition;
    }
}