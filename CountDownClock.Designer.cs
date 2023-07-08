namespace WindowsFormsApp1
{
    partial class CountDownClock
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ClockTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ClockTxt
            // 
            this.ClockTxt.BackColor = System.Drawing.SystemColors.Window;
            this.ClockTxt.Font = new System.Drawing.Font("Arial", 20F);
            this.ClockTxt.Location = new System.Drawing.Point(22, 13);
            this.ClockTxt.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ClockTxt.Name = "ClockTxt";
            this.ClockTxt.Size = new System.Drawing.Size(133, 38);
            this.ClockTxt.TabIndex = 0;
            this.ClockTxt.Text = "00:00:00";
            this.ClockTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CountDownClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ClockTxt);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "CountDownClock";
            this.Size = new System.Drawing.Size(171, 51);
            this.Load += new System.EventHandler(this.CountDown_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ClockTxt;
    }
}
