namespace Knv.DAQ.Controls
{
    partial class KnvAnalogOutputControl
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUnit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxOffset = new System.Windows.Forms.TextBox();
            this.labelCustomValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxMulti = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRaw = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxDivider = new System.Windows.Forms.TextBox();
            this.labelSamplesCount = new System.Windows.Forms.Label();
            this.textBoxSamplesCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxDutyCycle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxWaveOffset = new System.Windows.Forms.TextBox();
            this.textBoxAmpl = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxWave = new System.Windows.Forms.ComboBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.comboBoxRunMode = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxUnit);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxOffset);
            this.panel1.Controls.Add(this.labelCustomValue);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxMulti);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxRaw);
            this.panel1.Location = new System.Drawing.Point(59, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 155);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Unit:";
            // 
            // textBoxUnit
            // 
            this.textBoxUnit.Location = new System.Drawing.Point(41, 89);
            this.textBoxUnit.Name = "textBoxUnit";
            this.textBoxUnit.Size = new System.Drawing.Size(63, 20);
            this.textBoxUnit.TabIndex = 7;
            this.textBoxUnit.Text = "V";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Offset:";
            // 
            // textBoxOffset
            // 
            this.textBoxOffset.Location = new System.Drawing.Point(41, 41);
            this.textBoxOffset.Name = "textBoxOffset";
            this.textBoxOffset.Size = new System.Drawing.Size(63, 20);
            this.textBoxOffset.TabIndex = 5;
            this.textBoxOffset.Text = "0.00";
            this.textBoxOffset.TextChanged += new System.EventHandler(this.textBoxOffset_TextChanged);
            // 
            // labelCustomValue
            // 
            this.labelCustomValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomValue.Location = new System.Drawing.Point(4, 6);
            this.labelCustomValue.Name = "labelCustomValue";
            this.labelCustomValue.Size = new System.Drawing.Size(102, 26);
            this.labelCustomValue.TabIndex = 4;
            this.labelCustomValue.Text = "0.000V";
            this.labelCustomValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Multi:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitle.Location = new System.Drawing.Point(3, 3);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(450, 29);
            this.textBoxTitle.TabIndex = 2;
            this.textBoxTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxTitle.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxMulti
            // 
            this.textBoxMulti.Location = new System.Drawing.Point(41, 65);
            this.textBoxMulti.Name = "textBoxMulti";
            this.textBoxMulti.Size = new System.Drawing.Size(63, 20);
            this.textBoxMulti.TabIndex = 1;
            this.textBoxMulti.Text = "1.00";
            this.textBoxMulti.TextChanged += new System.EventHandler(this.textBoxMulti_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Raw:";
            // 
            // textBoxRaw
            // 
            this.textBoxRaw.Location = new System.Drawing.Point(41, 113);
            this.textBoxRaw.Name = "textBoxRaw";
            this.textBoxRaw.ReadOnly = true;
            this.textBoxRaw.Size = new System.Drawing.Size(63, 20);
            this.textBoxRaw.TabIndex = 0;
            this.textBoxRaw.Text = "0.00";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(3, 3);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 146);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.trackBar1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 38);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(456, 161);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.textBoxDivider);
            this.panel2.Controls.Add(this.labelSamplesCount);
            this.panel2.Controls.Add(this.textBoxSamplesCount);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.textBoxDutyCycle);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBoxWaveOffset);
            this.panel2.Controls.Add(this.textBoxAmpl);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.comboBoxWave);
            this.panel2.Controls.Add(this.buttonStop);
            this.panel2.Controls.Add(this.buttonStartStop);
            this.panel2.Controls.Add(this.comboBoxRunMode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(172, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(281, 155);
            this.panel2.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(147, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Divider:";
            // 
            // textBoxDivider
            // 
            this.textBoxDivider.Location = new System.Drawing.Point(196, 126);
            this.textBoxDivider.Name = "textBoxDivider";
            this.textBoxDivider.Size = new System.Drawing.Size(63, 20);
            this.textBoxDivider.TabIndex = 16;
            this.textBoxDivider.Text = "0";
            // 
            // labelSamplesCount
            // 
            this.labelSamplesCount.AutoSize = true;
            this.labelSamplesCount.Location = new System.Drawing.Point(140, 101);
            this.labelSamplesCount.Name = "labelSamplesCount";
            this.labelSamplesCount.Size = new System.Drawing.Size(50, 13);
            this.labelSamplesCount.TabIndex = 15;
            this.labelSamplesCount.Text = "Samples:";
            // 
            // textBoxSamplesCount
            // 
            this.textBoxSamplesCount.Location = new System.Drawing.Point(196, 97);
            this.textBoxSamplesCount.Name = "textBoxSamplesCount";
            this.textBoxSamplesCount.Size = new System.Drawing.Size(63, 20);
            this.textBoxSamplesCount.TabIndex = 14;
            this.textBoxSamplesCount.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(158, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Duty:";
            // 
            // textBoxDutyCycle
            // 
            this.textBoxDutyCycle.Location = new System.Drawing.Point(196, 68);
            this.textBoxDutyCycle.Name = "textBoxDutyCycle";
            this.textBoxDutyCycle.Size = new System.Drawing.Size(63, 20);
            this.textBoxDutyCycle.TabIndex = 12;
            this.textBoxDutyCycle.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Offset:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Amplitude:";
            // 
            // textBoxWaveOffset
            // 
            this.textBoxWaveOffset.Location = new System.Drawing.Point(65, 127);
            this.textBoxWaveOffset.Name = "textBoxWaveOffset";
            this.textBoxWaveOffset.Size = new System.Drawing.Size(63, 20);
            this.textBoxWaveOffset.TabIndex = 9;
            this.textBoxWaveOffset.Text = "0.00";
            // 
            // textBoxAmpl
            // 
            this.textBoxAmpl.Location = new System.Drawing.Point(65, 101);
            this.textBoxAmpl.Name = "textBoxAmpl";
            this.textBoxAmpl.Size = new System.Drawing.Size(63, 20);
            this.textBoxAmpl.TabIndex = 8;
            this.textBoxAmpl.Text = "0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Wave";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Run Mode";
            // 
            // comboBoxWave
            // 
            this.comboBoxWave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWave.FormattingEnabled = true;
            this.comboBoxWave.Location = new System.Drawing.Point(3, 20);
            this.comboBoxWave.Name = "comboBoxWave";
            this.comboBoxWave.Size = new System.Drawing.Size(105, 21);
            this.comboBoxWave.TabIndex = 5;
            this.comboBoxWave.SelectedIndexChanged += new System.EventHandler(this.comboBoxWave_SelectedIndexChanged);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(114, 18);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Location = new System.Drawing.Point(196, 18);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStartStop.TabIndex = 3;
            this.buttonStartStop.Text = "Start";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
            // 
            // comboBoxRunMode
            // 
            this.comboBoxRunMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRunMode.FormattingEnabled = true;
            this.comboBoxRunMode.Location = new System.Drawing.Point(3, 64);
            this.comboBoxRunMode.Name = "comboBoxRunMode";
            this.comboBoxRunMode.Size = new System.Drawing.Size(105, 21);
            this.comboBoxRunMode.TabIndex = 2;
            // 
            // KnvAnalogOutputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.textBoxTitle);
            this.Name = "KnvAnalogOutputControl";
            this.Size = new System.Drawing.Size(456, 201);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxRaw;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBoxMulti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCustomValue;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxOffset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxUnit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBoxRunMode;
        private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ComboBox comboBoxWave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxDutyCycle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxWaveOffset;
        private System.Windows.Forms.TextBox textBoxAmpl;
        private System.Windows.Forms.Label labelSamplesCount;
        private System.Windows.Forms.TextBox textBoxSamplesCount;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxDivider;
    }
}
