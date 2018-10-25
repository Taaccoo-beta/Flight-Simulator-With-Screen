namespace Flight_Simulator
{
    partial class SigleExpResultPre
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
            this.lblPathValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblExpName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblExpTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPathValue
            // 
            this.lblPathValue.AutoSize = true;
            this.lblPathValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPathValue.Location = new System.Drawing.Point(447, 195);
            this.lblPathValue.Name = "lblPathValue";
            this.lblPathValue.Size = new System.Drawing.Size(62, 25);
            this.lblPathValue.TabIndex = 16;
            this.lblPathValue.Text = "NULL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(304, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Path:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 35);
            this.button1.TabIndex = 14;
            this.button1.Text = "删除";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblExpName
            // 
            this.lblExpName.AutoSize = true;
            this.lblExpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblExpName.Location = new System.Drawing.Point(447, 153);
            this.lblExpName.Name = "lblExpName";
            this.lblExpName.Size = new System.Drawing.Size(62, 25);
            this.lblExpName.TabIndex = 13;
            this.lblExpName.Text = "NULL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(304, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "EexName:";
            // 
            // lblExpTime
            // 
            this.lblExpTime.AutoSize = true;
            this.lblExpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblExpTime.Location = new System.Drawing.Point(447, 106);
            this.lblExpTime.Name = "lblExpTime";
            this.lblExpTime.Size = new System.Drawing.Size(62, 25);
            this.lblExpTime.TabIndex = 11;
            this.lblExpTime.Text = "NULL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(311, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "EepTime:";
            // 
            // SigleExpResultPre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 408);
            this.Controls.Add(this.lblPathValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblExpName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblExpTime);
            this.Controls.Add(this.label1);
            this.Name = "SigleExpResultPre";
            this.Text = "SigleExpResultPre";
            this.Load += new System.EventHandler(this.SigleExpResultPre_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPathValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblExpName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblExpTime;
        private System.Windows.Forms.Label label1;
    }
}