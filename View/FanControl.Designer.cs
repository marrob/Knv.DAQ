namespace Knv.Fun.View
{
    partial class FanControl
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFrequency = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAIN0 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAIN1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAIN2 = new System.Windows.Forms.TextBox();
            this.textBoxCurr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxTemp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(48, 34);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 199);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Duty Cycle %";
            // 
            // textBoxFrequency
            // 
            this.textBoxFrequency.Location = new System.Drawing.Point(99, 61);
            this.textBoxFrequency.Name = "textBoxFrequency";
            this.textBoxFrequency.Size = new System.Drawing.Size(100, 20);
            this.textBoxFrequency.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Frequency [Hz]:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "AIN0 [V]:";
            // 
            // textBoxAIN0
            // 
            this.textBoxAIN0.Location = new System.Drawing.Point(99, 100);
            this.textBoxAIN0.Name = "textBoxAIN0";
            this.textBoxAIN0.Size = new System.Drawing.Size(100, 20);
            this.textBoxAIN0.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "AIN1 [V]:";
            // 
            // textBoxAIN1
            // 
            this.textBoxAIN1.Location = new System.Drawing.Point(99, 144);
            this.textBoxAIN1.Name = "textBoxAIN1";
            this.textBoxAIN1.Size = new System.Drawing.Size(100, 20);
            this.textBoxAIN1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "AIN2 [V]:";
            // 
            // textBoxAIN2
            // 
            this.textBoxAIN2.Location = new System.Drawing.Point(99, 184);
            this.textBoxAIN2.Name = "textBoxAIN2";
            this.textBoxAIN2.Size = new System.Drawing.Size(100, 20);
            this.textBoxAIN2.TabIndex = 9;
            // 
            // textBoxCurr
            // 
            this.textBoxCurr.Location = new System.Drawing.Point(217, 100);
            this.textBoxCurr.Name = "textBoxCurr";
            this.textBoxCurr.Size = new System.Drawing.Size(100, 20);
            this.textBoxCurr.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "NTC Current [mA]:";
            // 
            // textBoxRes
            // 
            this.textBoxRes.Location = new System.Drawing.Point(335, 100);
            this.textBoxRes.Name = "textBoxRes";
            this.textBoxRes.Size = new System.Drawing.Size(100, 20);
            this.textBoxRes.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(332, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "NTC Resistance [OHM]:";
            // 
            // textBoxTemp
            // 
            this.textBoxTemp.Location = new System.Drawing.Point(457, 100);
            this.textBoxTemp.Name = "textBoxTemp";
            this.textBoxTemp.Size = new System.Drawing.Size(100, 20);
            this.textBoxTemp.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(454, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Temp [C]:";
            // 
            // FanControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxTemp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxRes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxCurr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxAIN2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxAIN1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxAIN0);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFrequency);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Name = "FanControl";
            this.Size = new System.Drawing.Size(770, 266);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFrequency;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAIN0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAIN1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAIN2;
        private System.Windows.Forms.TextBox textBoxCurr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxRes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxTemp;
        private System.Windows.Forms.Label label8;
    }
}
