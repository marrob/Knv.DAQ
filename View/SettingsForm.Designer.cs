namespace Knv.DAQ.View
{
    partial class SettingsForm
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxAnalogInputPolling = new System.Windows.Forms.CheckBox();
            this.checkBoxUpTimeCounterPolling = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(252, 110);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(333, 110);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // checkBoxAnalogInputPolling
            // 
            this.checkBoxAnalogInputPolling.AutoSize = true;
            this.checkBoxAnalogInputPolling.Location = new System.Drawing.Point(12, 12);
            this.checkBoxAnalogInputPolling.Name = "checkBoxAnalogInputPolling";
            this.checkBoxAnalogInputPolling.Size = new System.Drawing.Size(125, 17);
            this.checkBoxAnalogInputPolling.TabIndex = 2;
            this.checkBoxAnalogInputPolling.Text = "Analog Inputs Polling";
            this.checkBoxAnalogInputPolling.UseVisualStyleBackColor = true;
            // 
            // checkBoxUpTimeCounterPolling
            // 
            this.checkBoxUpTimeCounterPolling.AutoSize = true;
            this.checkBoxUpTimeCounterPolling.Location = new System.Drawing.Point(12, 35);
            this.checkBoxUpTimeCounterPolling.Name = "checkBoxUpTimeCounterPolling";
            this.checkBoxUpTimeCounterPolling.Size = new System.Drawing.Size(137, 17);
            this.checkBoxUpTimeCounterPolling.TabIndex = 3;
            this.checkBoxUpTimeCounterPolling.Text = "UpTime Counter Polling";
            this.checkBoxUpTimeCounterPolling.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(410, 142);
            this.Controls.Add(this.checkBoxUpTimeCounterPolling);
            this.Controls.Add(this.checkBoxAnalogInputPolling);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxAnalogInputPolling;
        private System.Windows.Forms.CheckBox checkBoxUpTimeCounterPolling;
    }
}