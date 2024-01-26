namespace Knv.DAQ
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numericUpDownSPS = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.timerSampling = new System.Windows.Forms.Timer(this.components);
            this.knvStackPanel1 = new Knv.DAQ.Controls.KnvStackPanel();
            this.knvAnalogInputControl1 = new Knv.DAQ.Controls.KnvAnalogInputControl();
            this.knvAnalogInputControl2 = new Knv.DAQ.Controls.KnvAnalogInputControl();
            this.knvAnalogInputControl3 = new Knv.DAQ.Controls.KnvAnalogInputControl();
            this.knvAnalogInputControl4 = new Knv.DAQ.Controls.KnvAnalogInputControl();
            this.knvAnalogOutputControl1 = new Knv.DAQ.Controls.KnvAnalogOutputControl();
            this.knvAnalogOutputControl2 = new Knv.DAQ.Controls.KnvAnalogOutputControl();
            this.knvTracingControl1 = new Knv.DAQ.Controls.KnvTracingControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSPS)).BeginInit();
            this.knvStackPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1545, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 833);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1545, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.knvTracingControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1545, 809);
            this.splitContainer1.SplitterDistance = 597;
            this.splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 475F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.knvStackPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 597F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1545, 597);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 591);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(465, 453);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.knvAnalogOutputControl1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.knvAnalogOutputControl2, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(459, 399);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Controls.Add(this.numericUpDownSPS);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 408);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(459, 42);
            this.panel2.TabIndex = 1;
            // 
            // numericUpDownSPS
            // 
            this.numericUpDownSPS.Location = new System.Drawing.Point(3, 16);
            this.numericUpDownSPS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSPS.Name = "numericUpDownSPS";
            this.numericUpDownSPS.Size = new System.Drawing.Size(86, 20);
            this.numericUpDownSPS.TabIndex = 26;
            this.numericUpDownSPS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSPS.ValueChanged += new System.EventHandler(this.numericUpDownSPS_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Sample/s";
            // 
            // timerSampling
            // 
            this.timerSampling.Interval = 1000;
            this.timerSampling.Tick += new System.EventHandler(this.timerSampling_Tick);
            // 
            // knvStackPanel1
            // 
            this.knvStackPanel1.AutoScroll = true;
            this.knvStackPanel1.Controls.Add(this.knvAnalogInputControl1);
            this.knvStackPanel1.Controls.Add(this.knvAnalogInputControl2);
            this.knvStackPanel1.Controls.Add(this.knvAnalogInputControl3);
            this.knvStackPanel1.Controls.Add(this.knvAnalogInputControl4);
            this.knvStackPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knvStackPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.knvStackPanel1.Location = new System.Drawing.Point(478, 3);
            this.knvStackPanel1.Name = "knvStackPanel1";
            this.knvStackPanel1.Size = new System.Drawing.Size(1041, 591);
            this.knvStackPanel1.TabIndex = 0;
            // 
            // knvAnalogInputControl1
            // 
            this.knvAnalogInputControl1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.knvAnalogInputControl1.Location = new System.Drawing.Point(3, 3);
            this.knvAnalogInputControl1.MaxRawValue = 10D;
            this.knvAnalogInputControl1.Multiplier = double.NaN;
            this.knvAnalogInputControl1.Name = "knvAnalogInputControl1";
            this.knvAnalogInputControl1.Offset = double.NaN;
            this.knvAnalogInputControl1.Samples = 0;
            this.knvAnalogInputControl1.Size = new System.Drawing.Size(1018, 171);
            this.knvAnalogInputControl1.TabIndex = 0;
            this.knvAnalogInputControl1.Title = "Analog Input";
            this.knvAnalogInputControl1.Unit = "V";
            // 
            // knvAnalogInputControl2
            // 
            this.knvAnalogInputControl2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.knvAnalogInputControl2.Location = new System.Drawing.Point(3, 180);
            this.knvAnalogInputControl2.MaxRawValue = 10D;
            this.knvAnalogInputControl2.Multiplier = double.NaN;
            this.knvAnalogInputControl2.Name = "knvAnalogInputControl2";
            this.knvAnalogInputControl2.Offset = double.NaN;
            this.knvAnalogInputControl2.Samples = 0;
            this.knvAnalogInputControl2.Size = new System.Drawing.Size(1018, 171);
            this.knvAnalogInputControl2.TabIndex = 1;
            this.knvAnalogInputControl2.Title = "Analog Input";
            this.knvAnalogInputControl2.Unit = "V";
            // 
            // knvAnalogInputControl3
            // 
            this.knvAnalogInputControl3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.knvAnalogInputControl3.Location = new System.Drawing.Point(3, 357);
            this.knvAnalogInputControl3.MaxRawValue = 10D;
            this.knvAnalogInputControl3.Multiplier = double.NaN;
            this.knvAnalogInputControl3.Name = "knvAnalogInputControl3";
            this.knvAnalogInputControl3.Offset = double.NaN;
            this.knvAnalogInputControl3.Samples = 0;
            this.knvAnalogInputControl3.Size = new System.Drawing.Size(1018, 171);
            this.knvAnalogInputControl3.TabIndex = 2;
            this.knvAnalogInputControl3.Title = "Analog Input";
            this.knvAnalogInputControl3.Unit = "V";
            // 
            // knvAnalogInputControl4
            // 
            this.knvAnalogInputControl4.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.knvAnalogInputControl4.Location = new System.Drawing.Point(3, 534);
            this.knvAnalogInputControl4.MaxRawValue = 10D;
            this.knvAnalogInputControl4.Multiplier = double.NaN;
            this.knvAnalogInputControl4.Name = "knvAnalogInputControl4";
            this.knvAnalogInputControl4.Offset = double.NaN;
            this.knvAnalogInputControl4.Samples = 0;
            this.knvAnalogInputControl4.Size = new System.Drawing.Size(1018, 171);
            this.knvAnalogInputControl4.TabIndex = 3;
            this.knvAnalogInputControl4.Title = "Analog Input";
            this.knvAnalogInputControl4.Unit = "V";
            // 
            // knvAnalogOutputControl1
            // 
            this.knvAnalogOutputControl1.Divider = 0;
            this.knvAnalogOutputControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knvAnalogOutputControl1.Location = new System.Drawing.Point(3, 3);
            this.knvAnalogOutputControl1.Multiplier = double.NaN;
            this.knvAnalogOutputControl1.Name = "knvAnalogOutputControl1";
            this.knvAnalogOutputControl1.Offset = double.NaN;
            this.knvAnalogOutputControl1.SamplesCount = 0;
            this.knvAnalogOutputControl1.Size = new System.Drawing.Size(453, 193);
            this.knvAnalogOutputControl1.TabIndex = 0;
            this.knvAnalogOutputControl1.Title = "";
            this.knvAnalogOutputControl1.Unit = "V";
            this.knvAnalogOutputControl1.Value = 0D;
            this.knvAnalogOutputControl1.WaveAmplitude = 0D;
            this.knvAnalogOutputControl1.WaveDutyCycle = 0;
            this.knvAnalogOutputControl1.WaveOffset = 0D;
            this.knvAnalogOutputControl1.ValueChanged += new System.EventHandler<double>(this.knvAnalogOutputControl1_ValueChanged);
            this.knvAnalogOutputControl1.WaveChanged += new System.EventHandler<Knv.DAQ.IO.WaveForm>(this.knvAnalogOutputControl1_WaveChanged);
            this.knvAnalogOutputControl1.Start += new System.EventHandler(this.knvAnalogOutputControl1_Start);
            this.knvAnalogOutputControl1.Stop += new System.EventHandler(this.knvAnalogOutputControl1_Stop);
            // 
            // knvAnalogOutputControl2
            // 
            this.knvAnalogOutputControl2.Divider = 0;
            this.knvAnalogOutputControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knvAnalogOutputControl2.Location = new System.Drawing.Point(3, 202);
            this.knvAnalogOutputControl2.Multiplier = double.NaN;
            this.knvAnalogOutputControl2.Name = "knvAnalogOutputControl2";
            this.knvAnalogOutputControl2.Offset = double.NaN;
            this.knvAnalogOutputControl2.SamplesCount = 0;
            this.knvAnalogOutputControl2.Size = new System.Drawing.Size(453, 194);
            this.knvAnalogOutputControl2.TabIndex = 1;
            this.knvAnalogOutputControl2.Title = "";
            this.knvAnalogOutputControl2.Unit = "V";
            this.knvAnalogOutputControl2.Value = 0D;
            this.knvAnalogOutputControl2.WaveAmplitude = 0D;
            this.knvAnalogOutputControl2.WaveDutyCycle = 0;
            this.knvAnalogOutputControl2.WaveOffset = 0D;
            this.knvAnalogOutputControl2.ValueChanged += new System.EventHandler<double>(this.knvAnalogOutputControl2_ValueChanged);
            this.knvAnalogOutputControl2.WaveChanged += new System.EventHandler<Knv.DAQ.IO.WaveForm>(this.knvAnalogOutputControl2_WaveChanged);
            this.knvAnalogOutputControl2.Start += new System.EventHandler(this.knvAnalogOutputControl2_Start);
            this.knvAnalogOutputControl2.Stop += new System.EventHandler(this.knvAnalogOutputControl2_Stop);
            // 
            // knvTracingControl1
            // 
            this.knvTracingControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knvTracingControl1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knvTracingControl1.Location = new System.Drawing.Point(0, 0);
            this.knvTracingControl1.Name = "knvTracingControl1";
            this.knvTracingControl1.Size = new System.Drawing.Size(1545, 208);
            this.knvTracingControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1545, 855);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSPS)).EndInit();
            this.knvStackPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Timer timerSampling;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.KnvStackPanel knvStackPanel1;
        private Controls.KnvAnalogInputControl knvAnalogInputControl1;
        private Controls.KnvAnalogInputControl knvAnalogInputControl2;
        private Controls.KnvAnalogInputControl knvAnalogInputControl3;
        private Controls.KnvAnalogInputControl knvAnalogInputControl4;
        private Controls.KnvTracingControl knvTracingControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.NumericUpDown numericUpDownSPS;
        private System.Windows.Forms.Panel panel2;
        private Controls.KnvAnalogOutputControl knvAnalogOutputControl2;
        private Controls.KnvAnalogOutputControl knvAnalogOutputControl1;
    }
}

