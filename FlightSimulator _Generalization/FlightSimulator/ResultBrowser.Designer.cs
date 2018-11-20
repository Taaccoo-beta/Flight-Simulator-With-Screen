namespace FlightSimulator
{
    partial class ResultBrowser
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnWebpageOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(9, 10);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(15, 17);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(902, 543);
            this.webBrowser1.TabIndex = 1;
            // 
            // btnWebpageOpen
            // 
            this.btnWebpageOpen.Location = new System.Drawing.Point(926, 53);
            this.btnWebpageOpen.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnWebpageOpen.Name = "btnWebpageOpen";
            this.btnWebpageOpen.Size = new System.Drawing.Size(74, 31);
            this.btnWebpageOpen.TabIndex = 2;
            this.btnWebpageOpen.Text = "Open";
            this.btnWebpageOpen.UseVisualStyleBackColor = true;
            this.btnWebpageOpen.Click += new System.EventHandler(this.btnWebpageOpen_Click);
            // 
            // ResultBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 567);
            this.Controls.Add(this.btnWebpageOpen);
            this.Controls.Add(this.webBrowser1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "ResultBrowser";
            this.Text = "ResultBrowser";
            this.Load += new System.EventHandler(this.ResultBrowser_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnWebpageOpen;
    }
}