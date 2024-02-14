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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.knvStackPanel1 = new Knv.DAQ.Controls.KnvStackPanel();
            this.knvAnalogInputControl1 = new Knv.DAQ.Controls.KnvAnalogInputControl_v2();
            this.knvAnalogInputControl2 = new Knv.DAQ.Controls.KnvAnalogInputControl_v2();
            this.knvAnalogInputControl3 = new Knv.DAQ.Controls.KnvAnalogInputControl_v2();
            this.knvAnalogInputControl4 = new Knv.DAQ.Controls.KnvAnalogInputControl_v2();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.knvAnalogOutputControl1 = new Knv.DAQ.Controls.KnvAnalogOutputControl_v2();
            this.knvAnalogOutputControl2 = new Knv.DAQ.Controls.KnvAnalogOutputControl_v2();
            this.knvTracingControl1 = new Knv.DAQ.Controls.KnvTracingControl();
            this.timerSampling = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.knvStackPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1611, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 916);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1611, 22);
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
            this.splitContainer1.Size = new System.Drawing.Size(1611, 892);
            this.splitContainer1.SplitterDistance = 658;
            this.splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 389F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.knvStackPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 658F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1611, 658);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.knvStackPanel1.Location = new System.Drawing.Point(392, 3);
            this.knvStackPanel1.Name = "knvStackPanel1";
            this.knvStackPanel1.Size = new System.Drawing.Size(1216, 652);
            this.knvStackPanel1.TabIndex = 0;
            // 
            // knvAnalogInputControl1
            // 
            this.knvAnalogInputControl1.AutoSize = true;
            this.knvAnalogInputControl1.BackColor = System.Drawing.SystemColors.Control;
            this.knvAnalogInputControl1.Channel = System.Drawing.SystemColors.Control;
            this.knvAnalogInputControl1.Location = new System.Drawing.Point(3, 3);
            this.knvAnalogInputControl1.MaxRawValue = 10D;
            this.knvAnalogInputControl1.Multiplier = double.NaN;
            this.knvAnalogInputControl1.Name = "knvAnalogInputControl1";
            this.knvAnalogInputControl1.Offset = double.NaN;
            this.knvAnalogInputControl1.PhyName = "AIx";
            this.knvAnalogInputControl1.SelctedTab = "tabPageNumeric";
            this.knvAnalogInputControl1.Size = new System.Drawing.Size(686, 227);
            this.knvAnalogInputControl1.TabIndex = 4;
            this.knvAnalogInputControl1.Title = "Analog Input";
            this.knvAnalogInputControl1.Unit = "V";
            // 
            // knvAnalogInputControl2
            // 
            this.knvAnalogInputControl2.AutoSize = true;
            this.knvAnalogInputControl2.BackColor = System.Drawing.SystemColors.Control;
            this.knvAnalogInputControl2.Channel = System.Drawing.SystemColors.Control;
            this.knvAnalogInputControl2.Location = new System.Drawing.Point(3, 236);
            this.knvAnalogInputControl2.MaxRawValue = 10D;
            this.knvAnalogInputControl2.Multiplier = double.NaN;
            this.knvAnalogInputControl2.Name = "knvAnalogInputControl2";
            this.knvAnalogInputControl2.Offset = double.NaN;
            this.knvAnalogInputControl2.PhyName = "AIx";
            this.knvAnalogInputControl2.SelctedTab = "tabPageNumeric";
            this.knvAnalogInputControl2.Size = new System.Drawing.Size(686, 227);
            this.knvAnalogInputControl2.TabIndex = 5;
            this.knvAnalogInputControl2.Title = "Analog Input";
            this.knvAnalogInputControl2.Unit = "V";
            // 
            // knvAnalogInputControl3
            // 
            this.knvAnalogInputControl3.AutoSize = true;
            this.knvAnalogInputControl3.BackColor = System.Drawing.SystemColors.Control;
            this.knvAnalogInputControl3.Channel = System.Drawing.SystemColors.Control;
            this.knvAnalogInputControl3.Location = new System.Drawing.Point(3, 469);
            this.knvAnalogInputControl3.MaxRawValue = 10D;
            this.knvAnalogInputControl3.Multiplier = double.NaN;
            this.knvAnalogInputControl3.Name = "knvAnalogInputControl3";
            this.knvAnalogInputControl3.Offset = double.NaN;
            this.knvAnalogInputControl3.PhyName = "AIx";
            this.knvAnalogInputControl3.SelctedTab = "tabPageNumeric";
            this.knvAnalogInputControl3.Size = new System.Drawing.Size(686, 227);
            this.knvAnalogInputControl3.TabIndex = 6;
            this.knvAnalogInputControl3.Title = "Analog Input";
            this.knvAnalogInputControl3.Unit = "V";
            // 
            // knvAnalogInputControl4
            // 
            this.knvAnalogInputControl4.AutoSize = true;
            this.knvAnalogInputControl4.BackColor = System.Drawing.SystemColors.Control;
            this.knvAnalogInputControl4.Channel = System.Drawing.SystemColors.Control;
            this.knvAnalogInputControl4.Location = new System.Drawing.Point(3, 702);
            this.knvAnalogInputControl4.MaxRawValue = 10D;
            this.knvAnalogInputControl4.Multiplier = double.NaN;
            this.knvAnalogInputControl4.Name = "knvAnalogInputControl4";
            this.knvAnalogInputControl4.Offset = double.NaN;
            this.knvAnalogInputControl4.PhyName = "AIx";
            this.knvAnalogInputControl4.SelctedTab = "tabPageNumeric";
            this.knvAnalogInputControl4.Size = new System.Drawing.Size(1193, 227);
            this.knvAnalogInputControl4.TabIndex = 7;
            this.knvAnalogInputControl4.Title = "Analog Input";
            this.knvAnalogInputControl4.Unit = "V";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 652);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(383, 652);
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
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.47707F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.52293F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(377, 624);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // knvAnalogOutputControl1
            // 
            this.knvAnalogOutputControl1.Amplitude = 0D;
            this.knvAnalogOutputControl1.Channel = System.Drawing.Color.ForestGreen;
            this.knvAnalogOutputControl1.DutyCycle = 0;
            this.knvAnalogOutputControl1.Location = new System.Drawing.Point(3, 3);
            this.knvAnalogOutputControl1.Multiplier = double.NaN;
            this.knvAnalogOutputControl1.Name = "knvAnalogOutputControl1";
            this.knvAnalogOutputControl1.Offset = 0D;
            this.knvAnalogOutputControl1.PhyName = "AOx";
            this.knvAnalogOutputControl1.Prescaler = 0;
            this.knvAnalogOutputControl1.SamplesCount = 0;
            this.knvAnalogOutputControl1.SelctedTab = "tabPageDC";
            this.knvAnalogOutputControl1.Size = new System.Drawing.Size(371, 280);
            this.knvAnalogOutputControl1.TabIndex = 2;
            this.knvAnalogOutputControl1.Title = "Vin";
            this.knvAnalogOutputControl1.Unit = "V";
            this.knvAnalogOutputControl1.Value = 0D;
            this.knvAnalogOutputControl1.Wave = Knv.DAQ.IO.WaveForm.WAVE_CUSTOM;
            // 
            // knvAnalogOutputControl2
            // 
            this.knvAnalogOutputControl2.Amplitude = 0D;
            this.knvAnalogOutputControl2.Channel = System.Drawing.Color.Gold;
            this.knvAnalogOutputControl2.DutyCycle = 0;
            this.knvAnalogOutputControl2.Location = new System.Drawing.Point(3, 330);
            this.knvAnalogOutputControl2.Multiplier = double.NaN;
            this.knvAnalogOutputControl2.Name = "knvAnalogOutputControl2";
            this.knvAnalogOutputControl2.Offset = 0D;
            this.knvAnalogOutputControl2.PhyName = "AOx";
            this.knvAnalogOutputControl2.Prescaler = 0;
            this.knvAnalogOutputControl2.SamplesCount = 0;
            this.knvAnalogOutputControl2.SelctedTab = "tabPageDC";
            this.knvAnalogOutputControl2.Size = new System.Drawing.Size(371, 244);
            this.knvAnalogOutputControl2.TabIndex = 3;
            this.knvAnalogOutputControl2.Title = "Vin";
            this.knvAnalogOutputControl2.Unit = "V";
            this.knvAnalogOutputControl2.Value = 0D;
            this.knvAnalogOutputControl2.Wave = Knv.DAQ.IO.WaveForm.WAVE_CUSTOM;
            // 
            // knvTracingControl1
            // 
            this.knvTracingControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knvTracingControl1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knvTracingControl1.Location = new System.Drawing.Point(0, 0);
            this.knvTracingControl1.Name = "knvTracingControl1";
            this.knvTracingControl1.Size = new System.Drawing.Size(1611, 230);
            this.knvTracingControl1.TabIndex = 0;
            // 
            // timerSampling
            // 
            this.timerSampling.Interval = 1000;
            this.timerSampling.Tick += new System.EventHandler(this.timerSampling_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1611, 938);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
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
            this.knvStackPanel1.ResumeLayout(false);
            this.knvStackPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
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
        private Controls.KnvTracingControl knvTracingControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Controls.KnvAnalogOutputControl_v2 knvAnalogOutputControl1;
        private Controls.KnvAnalogOutputControl_v2 knvAnalogOutputControl2;
        private Controls.KnvAnalogInputControl_v2 knvAnalogInputControl1;
        private Controls.KnvAnalogInputControl_v2 knvAnalogInputControl2;
        private Controls.KnvAnalogInputControl_v2 knvAnalogInputControl3;
        private Controls.KnvAnalogInputControl_v2 knvAnalogInputControl4;
    }
}

