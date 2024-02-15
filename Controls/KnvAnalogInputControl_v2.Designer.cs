namespace Knv.DAQ.Controls
{
    partial class KnvAnalogInputControl_v2
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
            this.textBoxCustomValue = new System.Windows.Forms.TextBox();
            this.textBoxUnit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRawValue = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxOffset = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMulti = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelPhyName = new System.Windows.Forms.Label();
            this.labelSettings = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageNumeric = new System.Windows.Forms.TabPage();
            this.tabPageChart = new System.Windows.Forms.TabPage();
            this.knvMovingChart1 = new Knv.DAQ.Controls.KnvMovingChart();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageNumeric.SuspendLayout();
            this.tabPageChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.knvMovingChart1)).BeginInit();
            this.tabPageSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCustomValue
            // 
            this.textBoxCustomValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxCustomValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCustomValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxCustomValue.Location = new System.Drawing.Point(3, 3);
            this.textBoxCustomValue.Name = "textBoxCustomValue";
            this.textBoxCustomValue.ReadOnly = true;
            this.textBoxCustomValue.Size = new System.Drawing.Size(974, 44);
            this.textBoxCustomValue.TabIndex = 41;
            this.textBoxCustomValue.Text = "0.00";
            this.textBoxCustomValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxUnit
            // 
            this.textBoxUnit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxUnit.Location = new System.Drawing.Point(98, 97);
            this.textBoxUnit.Name = "textBoxUnit";
            this.textBoxUnit.Size = new System.Drawing.Size(101, 20);
            this.textBoxUnit.TabIndex = 40;
            this.textBoxUnit.Text = "V";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Unit:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(98, 19);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(100, 20);
            this.textBoxTitle.TabIndex = 38;
            this.textBoxTitle.Text = "Analog Input";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Title:";
            // 
            // textBoxRawValue
            // 
            this.textBoxRawValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxRawValue.Location = new System.Drawing.Point(915, 209);
            this.textBoxRawValue.Name = "textBoxRawValue";
            this.textBoxRawValue.ReadOnly = true;
            this.textBoxRawValue.Size = new System.Drawing.Size(59, 20);
            this.textBoxRawValue.TabIndex = 29;
            this.textBoxRawValue.Text = "0.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(877, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Raw:";
            // 
            // textBoxOffset
            // 
            this.textBoxOffset.Location = new System.Drawing.Point(98, 71);
            this.textBoxOffset.Name = "textBoxOffset";
            this.textBoxOffset.Size = new System.Drawing.Size(101, 20);
            this.textBoxOffset.TabIndex = 33;
            this.textBoxOffset.TextChanged += new System.EventHandler(this.textBoxOffset_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Offset:";
            // 
            // textBoxMulti
            // 
            this.textBoxMulti.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxMulti.Location = new System.Drawing.Point(98, 45);
            this.textBoxMulti.Name = "textBoxMulti";
            this.textBoxMulti.Size = new System.Drawing.Size(100, 20);
            this.textBoxMulti.TabIndex = 35;
            this.textBoxMulti.TextChanged += new System.EventHandler(this.textBoxMultipler_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Multiplier:";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(994, 300);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.30496F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.69504F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel4.Controls.Add(this.labelPhyName, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelSettings, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelTitle, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(988, 27);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // labelPhyName
            // 
            this.labelPhyName.BackColor = System.Drawing.SystemColors.Control;
            this.labelPhyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPhyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhyName.Location = new System.Drawing.Point(3, 0);
            this.labelPhyName.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.labelPhyName.Name = "labelPhyName";
            this.labelPhyName.Size = new System.Drawing.Size(241, 27);
            this.labelPhyName.TabIndex = 5;
            this.labelPhyName.Text = "AIx";
            this.labelPhyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSettings
            // 
            this.labelSettings.BackColor = System.Drawing.SystemColors.Control;
            this.labelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettings.Location = new System.Drawing.Point(894, 0);
            this.labelSettings.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(91, 27);
            this.labelSettings.TabIndex = 3;
            this.labelSettings.Text = "labelSettings";
            this.labelSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.SystemColors.Control;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(244, 0);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(650, 27);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "labelTitle";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageNumeric);
            this.tabControl1.Controls.Add(this.tabPageChart);
            this.tabControl1.Controls.Add(this.tabPageSettings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(988, 261);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPageNumeric
            // 
            this.tabPageNumeric.Controls.Add(this.textBoxCustomValue);
            this.tabPageNumeric.Controls.Add(this.label9);
            this.tabPageNumeric.Controls.Add(this.textBoxRawValue);
            this.tabPageNumeric.Location = new System.Drawing.Point(4, 22);
            this.tabPageNumeric.Name = "tabPageNumeric";
            this.tabPageNumeric.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNumeric.Size = new System.Drawing.Size(980, 235);
            this.tabPageNumeric.TabIndex = 0;
            this.tabPageNumeric.Text = "Numeric";
            this.tabPageNumeric.UseVisualStyleBackColor = true;
            // 
            // tabPageChart
            // 
            this.tabPageChart.Controls.Add(this.knvMovingChart1);
            this.tabPageChart.Location = new System.Drawing.Point(4, 22);
            this.tabPageChart.Name = "tabPageChart";
            this.tabPageChart.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChart.Size = new System.Drawing.Size(927, 213);
            this.tabPageChart.TabIndex = 1;
            this.tabPageChart.Text = "Chart";
            this.tabPageChart.UseVisualStyleBackColor = true;
            // 
            // knvMovingChart1
            // 
            this.knvMovingChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knvMovingChart1.Location = new System.Drawing.Point(3, 3);
            this.knvMovingChart1.Margin = new System.Windows.Forms.Padding(0);
            this.knvMovingChart1.Name = "knvMovingChart1";
            this.knvMovingChart1.SampleIndex = 0;
            this.knvMovingChart1.Samples = 0;
            this.knvMovingChart1.Size = new System.Drawing.Size(921, 207);
            this.knvMovingChart1.TabIndex = 0;
            this.knvMovingChart1.Text = "knvMovingChart1";
            this.knvMovingChart1.VerticalMaximum = 10D;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.textBoxTitle);
            this.tabPageSettings.Controls.Add(this.label1);
            this.tabPageSettings.Controls.Add(this.label2);
            this.tabPageSettings.Controls.Add(this.textBoxUnit);
            this.tabPageSettings.Controls.Add(this.textBoxMulti);
            this.tabPageSettings.Controls.Add(this.label8);
            this.tabPageSettings.Controls.Add(this.textBoxOffset);
            this.tabPageSettings.Controls.Add(this.label3);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Size = new System.Drawing.Size(927, 213);
            this.tabPageSettings.TabIndex = 2;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // KnvAnalogInputControl_v2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "KnvAnalogInputControl_v2";
            this.Size = new System.Drawing.Size(994, 300);
            this.Load += new System.EventHandler(this.KnvAnalogInputControl_v2_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageNumeric.ResumeLayout(false);
            this.tabPageNumeric.PerformLayout();
            this.tabPageChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.knvMovingChart1)).EndInit();
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private KnvMovingChart knvMovingChart1;
        private System.Windows.Forms.TextBox textBoxRawValue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxOffset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMulti;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUnit;
        private System.Windows.Forms.TextBox textBoxCustomValue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label labelPhyName;
        private System.Windows.Forms.Label labelSettings;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageNumeric;
        private System.Windows.Forms.TabPage tabPageChart;
        private System.Windows.Forms.TabPage tabPageSettings;
    }
}
