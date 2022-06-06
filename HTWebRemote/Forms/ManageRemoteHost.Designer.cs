
namespace HTWebRemote.Forms
{
    partial class ManageRemoteHost
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
            this.tbIP = new System.Windows.Forms.TextBox();
            this.btnSync = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblHostVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLatestVersion = new System.Windows.Forms.Label();
            this.btnErrorlog = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblRemoteUI = new System.Windows.Forms.LinkLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferNVShieldAuthorizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebootRasPiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbIP
            // 
            this.tbIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIP.Location = new System.Drawing.Point(12, 76);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(152, 26);
            this.tbIP.TabIndex = 0;
            // 
            // btnSync
            // 
            this.btnSync.Enabled = false;
            this.btnSync.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSync.Location = new System.Drawing.Point(12, 108);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(133, 32);
            this.btnSync.TabIndex = 1;
            this.btnSync.Text = "Sync Remotes";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 43);
            this.label1.TabIndex = 2;
            this.label1.Text = "RasPi / Linux Host IP Address:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(290, 76);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(83, 70);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update Remote Host";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblHostVersion
            // 
            this.lblHostVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHostVersion.AutoSize = true;
            this.lblHostVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHostVersion.Location = new System.Drawing.Point(310, 30);
            this.lblHostVersion.Name = "lblHostVersion";
            this.lblHostVersion.Size = new System.Drawing.Size(63, 20);
            this.lblHostVersion.TabIndex = 4;
            this.lblHostVersion.Text = "vX.X.X";
            this.lblHostVersion.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(186, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Host Version:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(173, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Latest Version:";
            // 
            // lblLatestVersion
            // 
            this.lblLatestVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLatestVersion.AutoSize = true;
            this.lblLatestVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatestVersion.Location = new System.Drawing.Point(310, 53);
            this.lblLatestVersion.Name = "lblLatestVersion";
            this.lblLatestVersion.Size = new System.Drawing.Size(63, 20);
            this.lblLatestVersion.TabIndex = 7;
            this.lblLatestVersion.Text = "vX.X.X";
            this.lblLatestVersion.Visible = false;
            // 
            // btnErrorlog
            // 
            this.btnErrorlog.Enabled = false;
            this.btnErrorlog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnErrorlog.Location = new System.Drawing.Point(12, 146);
            this.btnErrorlog.Name = "btnErrorlog";
            this.btnErrorlog.Size = new System.Drawing.Size(203, 32);
            this.btnErrorlog.TabIndex = 8;
            this.btnErrorlog.Text = "Remote Host Error Log";
            this.btnErrorlog.UseVisualStyleBackColor = true;
            this.btnErrorlog.Click += new System.EventHandler(this.btnErrorlog_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(216, 158);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(157, 20);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "NOT CONNECTED";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(170, 75);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(84, 30);
            this.btnConnect.TabIndex = 10;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblRemoteUI
            // 
            this.lblRemoteUI.AutoSize = true;
            this.lblRemoteUI.Enabled = false;
            this.lblRemoteUI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemoteUI.Location = new System.Drawing.Point(151, 117);
            this.lblRemoteUI.Name = "lblRemoteUI";
            this.lblRemoteUI.Size = new System.Drawing.Size(111, 16);
            this.lblRemoteUI.TabIndex = 12;
            this.lblRemoteUI.TabStop = true;
            this.lblRemoteUI.Text = "Open Remotes";
            this.lblRemoteUI.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRemoteUI_LinkClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(385, 25);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transferNVShieldAuthorizationToolStripMenuItem,
            this.rebootRasPiToolStripMenuItem});
            this.toolsToolStripMenuItem.Enabled = false;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(51, 21);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // transferNVShieldAuthorizationToolStripMenuItem
            // 
            this.transferNVShieldAuthorizationToolStripMenuItem.Name = "transferNVShieldAuthorizationToolStripMenuItem";
            this.transferNVShieldAuthorizationToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.transferNVShieldAuthorizationToolStripMenuItem.Text = "Transfer NVShield Authorization";
            this.transferNVShieldAuthorizationToolStripMenuItem.Click += new System.EventHandler(this.transferNVShieldAuthorizationToolStripMenuItem_Click);
            // 
            // rebootRasPiToolStripMenuItem
            // 
            this.rebootRasPiToolStripMenuItem.Name = "rebootRasPiToolStripMenuItem";
            this.rebootRasPiToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.rebootRasPiToolStripMenuItem.Text = "Reboot Remote Host PC";
            this.rebootRasPiToolStripMenuItem.Click += new System.EventHandler(this.rebootRasPiToolStripMenuItem_Click);
            // 
            // ManageRemoteHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(385, 187);
            this.Controls.Add(this.lblRemoteUI);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnErrorlog);
            this.Controls.Add(this.lblLatestVersion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblHostVersion);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageRemoteHost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Remote Host";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SyncRemotes_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblHostVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLatestVersion;
        private System.Windows.Forms.Button btnErrorlog;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.LinkLabel lblRemoteUI;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferNVShieldAuthorizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rebootRasPiToolStripMenuItem;
    }
}