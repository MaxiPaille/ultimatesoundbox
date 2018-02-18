namespace Soundboard
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.youtubeURL = new System.Windows.Forms.TextBox();
            this.downloadButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.masterVolume = new System.Windows.Forms.TrackBar();
            this.localVolume = new System.Windows.Forms.TrackBar();
            this.remoteVolume = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.soundList = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remoteVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // youtubeURL
            // 
            this.youtubeURL.Location = new System.Drawing.Point(12, 35);
            this.youtubeURL.Name = "youtubeURL";
            this.youtubeURL.Size = new System.Drawing.Size(358, 20);
            this.youtubeURL.TabIndex = 0;
            this.youtubeURL.Text = "https://www.youtube.com/watch?v=vrdk3IGcau8";
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(377, 34);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(78, 23);
            this.downloadButton.TabIndex = 1;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(855, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.masterVolume);
            this.groupBox1.Controls.Add(this.localVolume);
            this.groupBox1.Controls.Add(this.remoteVolume);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(654, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 252);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ouput";
            // 
            // masterVolume
            // 
            this.masterVolume.Location = new System.Drawing.Point(130, 19);
            this.masterVolume.Maximum = 100;
            this.masterVolume.Name = "masterVolume";
            this.masterVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.masterVolume.Size = new System.Drawing.Size(45, 201);
            this.masterVolume.TabIndex = 5;
            this.masterVolume.TickFrequency = 10;
            this.masterVolume.ValueChanged += new System.EventHandler(this.OnVolumeChanged);
            // 
            // localVolume
            // 
            this.localVolume.Location = new System.Drawing.Point(80, 19);
            this.localVolume.Maximum = 100;
            this.localVolume.Name = "localVolume";
            this.localVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.localVolume.Size = new System.Drawing.Size(45, 201);
            this.localVolume.TabIndex = 4;
            this.localVolume.TickFrequency = 10;
            this.localVolume.ValueChanged += new System.EventHandler(this.OnVolumeChanged);
            // 
            // remoteVolume
            // 
            this.remoteVolume.Location = new System.Drawing.Point(29, 19);
            this.remoteVolume.Maximum = 100;
            this.remoteVolume.Name = "remoteVolume";
            this.remoteVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.remoteVolume.Size = new System.Drawing.Size(45, 201);
            this.remoteVolume.TabIndex = 3;
            this.remoteVolume.TickFrequency = 10;
            this.remoteVolume.ValueChanged += new System.EventHandler(this.OnVolumeChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Master";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Remote";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local";
            // 
            // soundList
            // 
            this.soundList.FormattingEnabled = true;
            this.soundList.Location = new System.Drawing.Point(12, 61);
            this.soundList.Name = "soundList";
            this.soundList.Size = new System.Drawing.Size(358, 225);
            this.soundList.TabIndex = 5;
            this.soundList.SelectedIndexChanged += new System.EventHandler(this.OnSoundSelected);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 299);
            this.Controls.Add(this.soundList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.youtubeURL);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Ultimate soundbox";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remoteVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox youtubeURL;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar masterVolume;
        private System.Windows.Forms.TrackBar localVolume;
        private System.Windows.Forms.TrackBar remoteVolume;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox soundList;
    }
}

