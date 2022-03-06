namespace HTWebRemote
{
    partial class HTWebRemote
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
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblRemoteUI = new System.Windows.Forms.LinkLabel();
            this.cbxShowErrors = new System.Windows.Forms.CheckBox();
            this.lblOpenFileBrowser = new System.Windows.Forms.LinkLabel();
            this.lblDoc = new System.Windows.Forms.LinkLabel();
            this.btnEditRemoteUI = new System.Windows.Forms.Button();
            this.btnEditFileBrowser = new System.Windows.Forms.Button();
            this.cbStartAutomatically = new System.Windows.Forms.CheckBox();
            this.cbStartMinimized = new System.Windows.Forms.CheckBox();
            this.btnConfigureIPs = new System.Windows.Forms.Button();
            this.btnMinimizeToTray = new System.Windows.Forms.Button();
            this.pbDonate = new System.Windows.Forms.PictureBox();
            this.btnSyncRemotes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbDonate)).BeginInit();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipText = "Minimized";
            this.trayIcon.BalloonTipTitle = "HTWebRemote";
            this.trayIcon.Text = "HTWebRemote";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseClick);
            // 
            // lblRemoteUI
            // 
            this.lblRemoteUI.AutoSize = true;
            this.lblRemoteUI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemoteUI.Location = new System.Drawing.Point(164, 55);
            this.lblRemoteUI.Name = "lblRemoteUI";
            this.lblRemoteUI.Size = new System.Drawing.Size(111, 16);
            this.lblRemoteUI.TabIndex = 11;
            this.lblRemoteUI.TabStop = true;
            this.lblRemoteUI.Text = "Open Remotes";
            this.lblRemoteUI.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblRemoteUI_LinkClicked);
            // 
            // cbxShowErrors
            // 
            this.cbxShowErrors.AutoSize = true;
            this.cbxShowErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxShowErrors.Location = new System.Drawing.Point(459, 92);
            this.cbxShowErrors.Name = "cbxShowErrors";
            this.cbxShowErrors.Size = new System.Drawing.Size(110, 20);
            this.cbxShowErrors.TabIndex = 12;
            this.cbxShowErrors.Text = "Show Errors";
            this.cbxShowErrors.UseVisualStyleBackColor = true;
            this.cbxShowErrors.CheckedChanged += new System.EventHandler(this.cbxShowErrors_CheckedChanged);
            // 
            // lblOpenFileBrowser
            // 
            this.lblOpenFileBrowser.AutoSize = true;
            this.lblOpenFileBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpenFileBrowser.Location = new System.Drawing.Point(164, 91);
            this.lblOpenFileBrowser.Name = "lblOpenFileBrowser";
            this.lblOpenFileBrowser.Size = new System.Drawing.Size(135, 16);
            this.lblOpenFileBrowser.TabIndex = 14;
            this.lblOpenFileBrowser.TabStop = true;
            this.lblOpenFileBrowser.Text = "Open File Browser";
            this.lblOpenFileBrowser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblOpenFileBrowser_LinkClicked);
            // 
            // lblDoc
            // 
            this.lblDoc.AutoSize = true;
            this.lblDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoc.Location = new System.Drawing.Point(164, 19);
            this.lblDoc.Name = "lblDoc";
            this.lblDoc.Size = new System.Drawing.Size(257, 16);
            this.lblDoc.TabIndex = 15;
            this.lblDoc.TabStop = true;
            this.lblDoc.Text = "Documentation / Supported Devices";
            this.lblDoc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblDoc_LinkClicked);
            // 
            // btnEditRemoteUI
            // 
            this.btnEditRemoteUI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditRemoteUI.Location = new System.Drawing.Point(12, 48);
            this.btnEditRemoteUI.Name = "btnEditRemoteUI";
            this.btnEditRemoteUI.Size = new System.Drawing.Size(146, 30);
            this.btnEditRemoteUI.TabIndex = 21;
            this.btnEditRemoteUI.Text = "Edit Remotes";
            this.btnEditRemoteUI.UseVisualStyleBackColor = true;
            this.btnEditRemoteUI.Click += new System.EventHandler(this.btnEditRemoteUI_Click);
            // 
            // btnEditFileBrowser
            // 
            this.btnEditFileBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditFileBrowser.Location = new System.Drawing.Point(12, 84);
            this.btnEditFileBrowser.Name = "btnEditFileBrowser";
            this.btnEditFileBrowser.Size = new System.Drawing.Size(146, 30);
            this.btnEditFileBrowser.TabIndex = 22;
            this.btnEditFileBrowser.Text = "Edit File Browser";
            this.btnEditFileBrowser.UseVisualStyleBackColor = true;
            this.btnEditFileBrowser.Click += new System.EventHandler(this.btnEditFileBrowser_Click);
            // 
            // cbStartAutomatically
            // 
            this.cbStartAutomatically.AutoSize = true;
            this.cbStartAutomatically.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStartAutomatically.Location = new System.Drawing.Point(459, 48);
            this.cbStartAutomatically.Name = "cbStartAutomatically";
            this.cbStartAutomatically.Size = new System.Drawing.Size(156, 20);
            this.cbStartAutomatically.TabIndex = 24;
            this.cbStartAutomatically.Text = "Start Automatically";
            this.cbStartAutomatically.UseVisualStyleBackColor = true;
            this.cbStartAutomatically.CheckedChanged += new System.EventHandler(this.cbStartAutomatically_CheckedChanged);
            // 
            // cbStartMinimized
            // 
            this.cbStartMinimized.AutoSize = true;
            this.cbStartMinimized.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStartMinimized.Location = new System.Drawing.Point(459, 70);
            this.cbStartMinimized.Name = "cbStartMinimized";
            this.cbStartMinimized.Size = new System.Drawing.Size(132, 20);
            this.cbStartMinimized.TabIndex = 26;
            this.cbStartMinimized.Text = "Start Minimized";
            this.cbStartMinimized.UseVisualStyleBackColor = true;
            this.cbStartMinimized.CheckedChanged += new System.EventHandler(this.cbStartMinimized_CheckedChanged);
            // 
            // btnConfigureIPs
            // 
            this.btnConfigureIPs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigureIPs.Location = new System.Drawing.Point(12, 12);
            this.btnConfigureIPs.Name = "btnConfigureIPs";
            this.btnConfigureIPs.Size = new System.Drawing.Size(146, 30);
            this.btnConfigureIPs.TabIndex = 27;
            this.btnConfigureIPs.Text = "Configure Devices";
            this.btnConfigureIPs.UseVisualStyleBackColor = true;
            this.btnConfigureIPs.Click += new System.EventHandler(this.btnConfigureIPs_Click);
            // 
            // btnMinimizeToTray
            // 
            this.btnMinimizeToTray.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimizeToTray.Location = new System.Drawing.Point(477, 12);
            this.btnMinimizeToTray.Name = "btnMinimizeToTray";
            this.btnMinimizeToTray.Size = new System.Drawing.Size(138, 30);
            this.btnMinimizeToTray.TabIndex = 28;
            this.btnMinimizeToTray.Text = "Minimize To Tray";
            this.btnMinimizeToTray.UseVisualStyleBackColor = true;
            this.btnMinimizeToTray.Click += new System.EventHandler(this.btnMinimizeToTray_Click);
            // 
            // pbDonate
            // 
            this.pbDonate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDonate.Image = global::HTWebRemote.Properties.Resources.paypal;
            this.pbDonate.Location = new System.Drawing.Point(322, 80);
            this.pbDonate.Name = "pbDonate";
            this.pbDonate.Size = new System.Drawing.Size(85, 34);
            this.pbDonate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDonate.TabIndex = 29;
            this.pbDonate.TabStop = false;
            this.pbDonate.Click += new System.EventHandler(this.btnDonate_Click);
            // 
            // btnSyncRemotes
            // 
            this.btnSyncRemotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSyncRemotes.Location = new System.Drawing.Point(281, 44);
            this.btnSyncRemotes.Name = "btnSyncRemotes";
            this.btnSyncRemotes.Size = new System.Drawing.Size(166, 30);
            this.btnSyncRemotes.TabIndex = 30;
            this.btnSyncRemotes.Text = "Manage Remote Host";
            this.btnSyncRemotes.UseVisualStyleBackColor = true;
            this.btnSyncRemotes.Click += new System.EventHandler(this.btnSyncRemotes_Click);
            // 
            // HTWebRemote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(627, 121);
            this.Controls.Add(this.btnSyncRemotes);
            this.Controls.Add(this.pbDonate);
            this.Controls.Add(this.btnMinimizeToTray);
            this.Controls.Add(this.btnConfigureIPs);
            this.Controls.Add(this.cbStartMinimized);
            this.Controls.Add(this.cbStartAutomatically);
            this.Controls.Add(this.btnEditFileBrowser);
            this.Controls.Add(this.btnEditRemoteUI);
            this.Controls.Add(this.lblDoc);
            this.Controls.Add(this.lblOpenFileBrowser);
            this.Controls.Add(this.cbxShowErrors);
            this.Controls.Add(this.lblRemoteUI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "HTWebRemote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HTWebRemote";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HTWebRemote_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbDonate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.LinkLabel lblRemoteUI;
        private System.Windows.Forms.CheckBox cbxShowErrors;
        private System.Windows.Forms.LinkLabel lblOpenFileBrowser;
        private System.Windows.Forms.LinkLabel lblDoc;
        private System.Windows.Forms.Button btnEditRemoteUI;
        private System.Windows.Forms.Button btnEditFileBrowser;
        private System.Windows.Forms.CheckBox cbStartAutomatically;
        private System.Windows.Forms.CheckBox cbStartMinimized;
        private System.Windows.Forms.Button btnConfigureIPs;
        private System.Windows.Forms.Button btnMinimizeToTray;
        private System.Windows.Forms.PictureBox pbDonate;
        private System.Windows.Forms.Button btnSyncRemotes;
    }
}

