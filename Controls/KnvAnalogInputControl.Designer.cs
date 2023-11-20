namespace Knv.DAQ.Controls
{
    partial class KnvAnalogInputControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.knvMovingChart1 = new Knv.DAQ.Controls.KnvMovingChart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxCustomValue = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.knvMovingChart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.Controls.Add(this.knvMovingChart1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(930, 147);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // knvMovingChart1
            // 
            this.knvMovingChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knvMovingChart1.Location = new System.Drawing.Point(0, 0);
            this.knvMovingChart1.Margin = new System.Windows.Forms.Padding(0);
            this.knvMovingChart1.Name = "knvMovingChart1";
            this.knvMovingChart1.SampleIndex = 0;
            this.knvMovingChart1.Size = new System.Drawing.Size(763, 147);
            this.knvMovingChart1.TabIndex = 0;
            this.knvMovingChart1.Text = "knvMovingChart1";
            this.knvMovingChart1.VerticalMaximum = 10D;
            this.knvMovingChart1.VisibleSamples = 10D;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxCustomValue);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(763, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(167, 147);
            this.panel1.TabIndex = 1;
            // 
            // textBoxCustomValue
            // 
            this.textBoxCustomValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCustomValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxCustomValue.Location = new System.Drawing.Point(0, 0);
            this.textBoxCustomValue.Name = "textBoxCustomValue";
            this.textBoxCustomValue.ReadOnly = true;
            this.textBoxCustomValue.Size = new System.Drawing.Size(166, 44);
            this.textBoxCustomValue.TabIndex = 41;
            this.textBoxCustomValue.Text = "0.00";
            this.textBoxCustomValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.96491F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.03509F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(930, 171);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxUnit);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBoxTitle);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBoxRawValue);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.textBoxOffset);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBoxMulti);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 147);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(930, 24);
            this.panel2.TabIndex = 1;
            // 
            // textBoxUnit
            // 
            this.textBoxUnit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxUnit.Location = new System.Drawing.Point(409, 2);
            this.textBoxUnit.Name = "textBoxUnit";
            this.textBoxUnit.Size = new System.Drawing.Size(59, 20);
            this.textBoxUnit.TabIndex = 40;
            this.textBoxUnit.Text = "V";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Unit:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(35, 2);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(100, 20);
            this.textBoxTitle.TabIndex = 38;
            this.textBoxTitle.Text = "Analog Input";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Title:";
            // 
            // textBoxRawValue
            // 
            this.textBoxRawValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxRawValue.Location = new System.Drawing.Point(542, 2);
            this.textBoxRawValue.Name = "textBoxRawValue";
            this.textBoxRawValue.ReadOnly = true;
            this.textBoxRawValue.Size = new System.Drawing.Size(59, 20);
            this.textBoxRawValue.TabIndex = 29;
            this.textBoxRawValue.Text = "0.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(474, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Raw:";
            // 
            // textBoxOffset
            // 
            this.textBoxOffset.Location = new System.Drawing.Point(303, 2);
            this.textBoxOffset.Name = "textBoxOffset";
            this.textBoxOffset.Size = new System.Drawing.Size(60, 20);
            this.textBoxOffset.TabIndex = 33;
            this.textBoxOffset.TextChanged += new System.EventHandler(this.textBoxOffset_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Offset:";
            // 
            // textBoxMultipler
            // 
            this.textBoxMulti.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxMulti.Location = new System.Drawing.Point(195, 2);
            this.textBoxMulti.Name = "textBoxMultipler";
            this.textBoxMulti.Size = new System.Drawing.Size(60, 20);
            this.textBoxMulti.TabIndex = 35;
            this.textBoxMulti.TextChanged += new System.EventHandler(this.textBoxMultipler_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(141, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Multiplier:";
            // 
            // KnvAnalogInputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "KnvAnalogInputControl";
            this.Size = new System.Drawing.Size(930, 171);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.knvMovingChart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private KnvMovingChart knvMovingChart1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBoxRawValue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxOffset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMulti;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUnit;
        private System.Windows.Forms.TextBox textBoxCustomValue;
    }
}
