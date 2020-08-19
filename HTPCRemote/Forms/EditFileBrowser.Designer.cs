namespace HTPCRemote.Forms
{
    partial class EditFileBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditFileBrowser));
            this.lbPaths = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.cmbFileBrowserRemote = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbShowFileBrowser = new System.Windows.Forms.CheckBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChooseFBMediaPlayer = new System.Windows.Forms.Button();
            this.lblFBMediaPlayerPath = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnChooseYTMediaPlayer = new System.Windows.Forms.Button();
            this.cbYoutubeUseWebBrowser = new System.Windows.Forms.CheckBox();
            this.lblYTMediaPlayerPath = new System.Windows.Forms.Label();
            this.cbEnableYoutube = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbPaths
            // 
            this.lbPaths.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPaths.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaths.FormattingEnabled = true;
            this.lbPaths.ItemHeight = 20;
            this.lbPaths.Location = new System.Drawing.Point(13, 32);
            this.lbPaths.Name = "lbPaths";
            this.lbPaths.Size = new System.Drawing.Size(695, 224);
            this.lbPaths.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Paths To Browse:";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(466, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 28);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add Path";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(566, 19);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(124, 28);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove Path";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // cmbFileBrowserRemote
            // 
            this.cmbFileBrowserRemote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFileBrowserRemote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFileBrowserRemote.FormattingEnabled = true;
            this.cmbFileBrowserRemote.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbFileBrowserRemote.Location = new System.Drawing.Point(408, 19);
            this.cmbFileBrowserRemote.Name = "cmbFileBrowserRemote";
            this.cmbFileBrowserRemote.Size = new System.Drawing.Size(52, 28);
            this.cmbFileBrowserRemote.TabIndex = 4;
            this.cmbFileBrowserRemote.SelectedIndexChanged += new System.EventHandler(this.cmbFileBrowserRemote_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(223, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "File Browser Remote:";
            // 
            // cbShowFileBrowser
            // 
            this.cbShowFileBrowser.AutoSize = true;
            this.cbShowFileBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShowFileBrowser.Location = new System.Drawing.Point(6, 22);
            this.cbShowFileBrowser.Name = "cbShowFileBrowser";
            this.cbShowFileBrowser.Size = new System.Drawing.Size(211, 24);
            this.cbShowFileBrowser.TabIndex = 6;
            this.cbShowFileBrowser.Text = "Show File Browser Tab";
            this.cbShowFileBrowser.UseVisualStyleBackColor = true;
            this.cbShowFileBrowser.CheckedChanged += new System.EventHandler(this.cbShowFileBrowser_CheckedChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "exe";
            this.openFileDialog.Filter = "Media Player|*.exe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "File Browser Media Player:";
            // 
            // btnChooseFBMediaPlayer
            // 
            this.btnChooseFBMediaPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseFBMediaPlayer.Location = new System.Drawing.Point(227, 52);
            this.btnChooseFBMediaPlayer.Name = "btnChooseFBMediaPlayer";
            this.btnChooseFBMediaPlayer.Size = new System.Drawing.Size(81, 28);
            this.btnChooseFBMediaPlayer.TabIndex = 8;
            this.btnChooseFBMediaPlayer.Text = "Choose";
            this.btnChooseFBMediaPlayer.UseVisualStyleBackColor = true;
            this.btnChooseFBMediaPlayer.Click += new System.EventHandler(this.btnChooseFBMediaPlayer_Click);
            // 
            // lblFBMediaPlayerPath
            // 
            this.lblFBMediaPlayerPath.AutoSize = true;
            this.lblFBMediaPlayerPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFBMediaPlayerPath.Location = new System.Drawing.Point(310, 56);
            this.lblFBMediaPlayerPath.Name = "lblFBMediaPlayerPath";
            this.lblFBMediaPlayerPath.Size = new System.Drawing.Size(155, 20);
            this.lblFBMediaPlayerPath.TabIndex = 9;
            this.lblFBMediaPlayerPath.Text = "Default Media Player";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChooseFBMediaPlayer);
            this.groupBox1.Controls.Add(this.cbShowFileBrowser);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.lblFBMediaPlayerPath);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbFileBrowserRemote);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 262);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(696, 88);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Browser Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnChooseYTMediaPlayer);
            this.groupBox2.Controls.Add(this.cbYoutubeUseWebBrowser);
            this.groupBox2.Controls.Add(this.lblYTMediaPlayerPath);
            this.groupBox2.Controls.Add(this.cbEnableYoutube);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(13, 356);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(696, 86);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "YouTube Settings";
            // 
            // btnChooseYTMediaPlayer
            // 
            this.btnChooseYTMediaPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseYTMediaPlayer.Location = new System.Drawing.Point(200, 49);
            this.btnChooseYTMediaPlayer.Name = "btnChooseYTMediaPlayer";
            this.btnChooseYTMediaPlayer.Size = new System.Drawing.Size(81, 28);
            this.btnChooseYTMediaPlayer.TabIndex = 11;
            this.btnChooseYTMediaPlayer.Text = "Choose";
            this.btnChooseYTMediaPlayer.UseVisualStyleBackColor = true;
            this.btnChooseYTMediaPlayer.Click += new System.EventHandler(this.btnChooseYTMediaPlayer_Click);
            // 
            // cbYoutubeUseWebBrowser
            // 
            this.cbYoutubeUseWebBrowser.AutoSize = true;
            this.cbYoutubeUseWebBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbYoutubeUseWebBrowser.Location = new System.Drawing.Point(173, 19);
            this.cbYoutubeUseWebBrowser.Name = "cbYoutubeUseWebBrowser";
            this.cbYoutubeUseWebBrowser.Size = new System.Drawing.Size(354, 24);
            this.cbYoutubeUseWebBrowser.TabIndex = 11;
            this.cbYoutubeUseWebBrowser.Text = "Play YouTube With Default Web Browser";
            this.cbYoutubeUseWebBrowser.UseVisualStyleBackColor = true;
            this.cbYoutubeUseWebBrowser.CheckedChanged += new System.EventHandler(this.cbYoutubeUseWebBrowser_CheckedChanged);
            // 
            // lblYTMediaPlayerPath
            // 
            this.lblYTMediaPlayerPath.AutoSize = true;
            this.lblYTMediaPlayerPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYTMediaPlayerPath.Location = new System.Drawing.Point(283, 53);
            this.lblYTMediaPlayerPath.Name = "lblYTMediaPlayerPath";
            this.lblYTMediaPlayerPath.Size = new System.Drawing.Size(160, 20);
            this.lblYTMediaPlayerPath.TabIndex = 12;
            this.lblYTMediaPlayerPath.Text = "Default Web Browser";
            // 
            // cbEnableYoutube
            // 
            this.cbEnableYoutube.AutoSize = true;
            this.cbEnableYoutube.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEnableYoutube.Location = new System.Drawing.Point(6, 19);
            this.cbEnableYoutube.Name = "cbEnableYoutube";
            this.cbEnableYoutube.Size = new System.Drawing.Size(161, 24);
            this.cbEnableYoutube.TabIndex = 10;
            this.cbEnableYoutube.Text = "Enable YouTube";
            this.cbEnableYoutube.UseVisualStyleBackColor = true;
            this.cbEnableYoutube.CheckedChanged += new System.EventHandler(this.cbEnableYoutube_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "YouTube Media Player:";
            // 
            // EditFileBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 449);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbPaths);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditFileBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Browser Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbPaths;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ComboBox cmbFileBrowserRemote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbShowFileBrowser;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChooseFBMediaPlayer;
        private System.Windows.Forms.Label lblFBMediaPlayerPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnChooseYTMediaPlayer;
        private System.Windows.Forms.CheckBox cbYoutubeUseWebBrowser;
        private System.Windows.Forms.Label lblYTMediaPlayerPath;
        private System.Windows.Forms.CheckBox cbEnableYoutube;
        private System.Windows.Forms.Label label5;
    }
}