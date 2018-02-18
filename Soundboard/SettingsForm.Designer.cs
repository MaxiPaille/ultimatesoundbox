namespace Soundboard
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
            this.remoteDeviceCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.localDeviceCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // remoteDeviceCombo
            // 
            this.remoteDeviceCombo.FormattingEnabled = true;
            this.remoteDeviceCombo.Location = new System.Drawing.Point(132, 10);
            this.remoteDeviceCombo.Name = "remoteDeviceCombo";
            this.remoteDeviceCombo.Size = new System.Drawing.Size(318, 21);
            this.remoteDeviceCombo.TabIndex = 0;
            this.remoteDeviceCombo.SelectedIndexChanged += new System.EventHandler(this.mainDeviceCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Remote Ouput Device";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Local Output Device";
            // 
            // localDeviceCombo
            // 
            this.localDeviceCombo.FormattingEnabled = true;
            this.localDeviceCombo.Location = new System.Drawing.Point(132, 37);
            this.localDeviceCombo.Name = "localDeviceCombo";
            this.localDeviceCombo.Size = new System.Drawing.Size(318, 21);
            this.localDeviceCombo.TabIndex = 3;
            this.localDeviceCombo.SelectedIndexChanged += new System.EventHandler(this.localDeviceCombo_SelectedIndexChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 72);
            this.Controls.Add(this.localDeviceCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.remoteDeviceCombo);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox remoteDeviceCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox localDeviceCombo;
    }
}