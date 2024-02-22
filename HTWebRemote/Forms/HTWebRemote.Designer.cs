﻿namespace HTWebRemote
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
            this.lblNewVersion = new System.Windows.Forms.Label();
            this.lnkNewVersion = new System.Windows.Forms.LinkLabel();
            this.cbxBottomTabs = new System.Windows.Forms.CheckBox();
            this.btnEditHotkeys = new System.Windows.Forms.Button();
            this.btnEditVoiceCommands = new System.Windows.Forms.Button();
            this.cbxVoiceControl = new System.Windows.Forms.CheckBox();
            this.cbxHotkeys = new System.Windows.Forms.CheckBox();
            this.cbxGroupListButton = new System.Windows.Forms.CheckBox();
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
            this.cbxShowErrors.Location = new System.Drawing.Point(432, 169);
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
            this.lblOpenFileBrowser.Location = new System.Drawing.Point(164, 163);
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
            this.lblDoc.Size = new System.Drawing.Size(111, 16);
            this.lblDoc.TabIndex = 15;
            this.lblDoc.TabStop = true;
            this.lblDoc.Text = "Documentation";
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
            this.btnEditFileBrowser.Location = new System.Drawing.Point(12, 156);
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
            this.cbStartAutomatically.Location = new System.Drawing.Point(432, 125);
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
            this.cbStartMinimized.Location = new System.Drawing.Point(432, 147);
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
            this.btnMinimizeToTray.Location = new System.Drawing.Point(437, 12);
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
            this.pbDonate.Location = new System.Drawing.Point(318, 152);
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
            this.btnSyncRemotes.Location = new System.Drawing.Point(469, 62);
            this.btnSyncRemotes.Name = "btnSyncRemotes";
            this.btnSyncRemotes.Size = new System.Drawing.Size(106, 44);
            this.btnSyncRemotes.TabIndex = 30;
            this.btnSyncRemotes.Text = "Manage Remote Host";
            this.btnSyncRemotes.UseVisualStyleBackColor = true;
            this.btnSyncRemotes.Click += new System.EventHandler(this.btnSyncRemotes_Click);
            // 
            // lblNewVersion
            // 
            this.lblNewVersion.AutoSize = true;
            this.lblNewVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewVersion.ForeColor = System.Drawing.Color.Green;
            this.lblNewVersion.Location = new System.Drawing.Point(278, 19);
            this.lblNewVersion.Name = "lblNewVersion";
            this.lblNewVersion.Size = new System.Drawing.Size(99, 16);
            this.lblNewVersion.TabIndex = 31;
            this.lblNewVersion.Text = "New Version:";
            this.lblNewVersion.Visible = false;
            // 
            // lnkNewVersion
            // 
            this.lnkNewVersion.AutoSize = true;
            this.lnkNewVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkNewVersion.Location = new System.Drawing.Point(373, 19);
            this.lnkNewVersion.Name = "lnkNewVersion";
            this.lnkNewVersion.Size = new System.Drawing.Size(60, 16);
            this.lnkNewVersion.TabIndex = 32;
            this.lnkNewVersion.TabStop = true;
            this.lnkNewVersion.Text = "vX.XX.X";
            this.lnkNewVersion.Visible = false;
            this.lnkNewVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNewVersion_LinkClicked);
            // 
            // cbxBottomTabs
            // 
            this.cbxBottomTabs.AutoSize = true;
            this.cbxBottomTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBottomTabs.Location = new System.Drawing.Point(281, 45);
            this.cbxBottomTabs.Name = "cbxBottomTabs";
            this.cbxBottomTabs.Size = new System.Drawing.Size(115, 20);
            this.cbxBottomTabs.TabIndex = 33;
            this.cbxBottomTabs.Text = "Bottom Tabs";
            this.cbxBottomTabs.UseVisualStyleBackColor = true;
            this.cbxBottomTabs.CheckedChanged += new System.EventHandler(this.cbxBottomTabs_CheckedChanged);
            // 
            // btnEditHotkeys
            // 
            this.btnEditHotkeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditHotkeys.Location = new System.Drawing.Point(12, 84);
            this.btnEditHotkeys.Name = "btnEditHotkeys";
            this.btnEditHotkeys.Size = new System.Drawing.Size(146, 30);
            this.btnEditHotkeys.TabIndex = 34;
            this.btnEditHotkeys.Text = "Global Hotkeys";
            this.btnEditHotkeys.UseVisualStyleBackColor = true;
            this.btnEditHotkeys.Click += new System.EventHandler(this.btnEditHotkeys_Click);
            // 
            // btnEditVoiceCommands
            // 
            this.btnEditVoiceCommands.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditVoiceCommands.Location = new System.Drawing.Point(12, 120);
            this.btnEditVoiceCommands.Name = "btnEditVoiceCommands";
            this.btnEditVoiceCommands.Size = new System.Drawing.Size(146, 30);
            this.btnEditVoiceCommands.TabIndex = 35;
            this.btnEditVoiceCommands.Text = "Voice Commands";
            this.btnEditVoiceCommands.UseVisualStyleBackColor = true;
            this.btnEditVoiceCommands.Click += new System.EventHandler(this.btnEditVoiceCommands_Click);
            // 
            // cbxVoiceControl
            // 
            this.cbxVoiceControl.AutoSize = true;
            this.cbxVoiceControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxVoiceControl.Location = new System.Drawing.Point(167, 125);
            this.cbxVoiceControl.Name = "cbxVoiceControl";
            this.cbxVoiceControl.Size = new System.Drawing.Size(173, 20);
            this.cbxVoiceControl.TabIndex = 36;
            this.cbxVoiceControl.Text = "Enable Voice Control";
            this.cbxVoiceControl.UseVisualStyleBackColor = true;
            this.cbxVoiceControl.Click += new System.EventHandler(this.cbxVoiceControl_Click);
            // 
            // cbxHotkeys
            // 
            this.cbxHotkeys.AutoSize = true;
            this.cbxHotkeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxHotkeys.Location = new System.Drawing.Point(167, 90);
            this.cbxHotkeys.Name = "cbxHotkeys";
            this.cbxHotkeys.Size = new System.Drawing.Size(137, 20);
            this.cbxHotkeys.TabIndex = 37;
            this.cbxHotkeys.Text = "Enable Hotkeys";
            this.cbxHotkeys.UseVisualStyleBackColor = true;
            this.cbxHotkeys.CheckedChanged += new System.EventHandler(this.cbxHotkeys_CheckedChanged);
            // 
            // cbxGroupListButton
            // 
            this.cbxGroupListButton.AutoSize = true;
            this.cbxGroupListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxGroupListButton.Location = new System.Drawing.Point(281, 65);
            this.cbxGroupListButton.Name = "cbxGroupListButton";
            this.cbxGroupListButton.Size = new System.Drawing.Size(144, 20);
            this.cbxGroupListButton.TabIndex = 38;
            this.cbxGroupListButton.Text = "Group List Button";
            this.cbxGroupListButton.UseVisualStyleBackColor = true;
            this.cbxGroupListButton.CheckedChanged += new System.EventHandler(this.cbxGroupListButton_CheckedChanged);
            // 
            // HTWebRemote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(584, 191);
            this.Controls.Add(this.cbxGroupListButton);
            this.Controls.Add(this.cbxHotkeys);
            this.Controls.Add(this.cbxVoiceControl);
            this.Controls.Add(this.btnEditVoiceCommands);
            this.Controls.Add(this.btnEditHotkeys);
            this.Controls.Add(this.cbxBottomTabs);
            this.Controls.Add(this.lnkNewVersion);
            this.Controls.Add(this.lblNewVersion);
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
        private System.Windows.Forms.Label lblNewVersion;
        private System.Windows.Forms.LinkLabel lnkNewVersion;
        private System.Windows.Forms.CheckBox cbxBottomTabs;
        private System.Windows.Forms.Button btnEditHotkeys;
        private System.Windows.Forms.Button btnEditVoiceCommands;
        public System.Windows.Forms.CheckBox cbxVoiceControl;
        public System.Windows.Forms.CheckBox cbxHotkeys;
        private System.Windows.Forms.CheckBox cbxGroupListButton;
    }
}

