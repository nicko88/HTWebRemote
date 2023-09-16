namespace HTWebRemote.Forms
{
    partial class CommandEditor
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
            this.lbCommands = new System.Windows.Forms.ListBox();
            this.cmbAddCommand = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panelCommand = new System.Windows.Forms.Panel();
            this.btnDeleteCmd = new System.Windows.Forms.Button();
            this.btnAddCmd = new System.Windows.Forms.Button();
            this.tbParam = new System.Windows.Forms.TextBox();
            this.btnSaveCmd = new System.Windows.Forms.Button();
            this.lblParam = new System.Windows.Forms.Label();
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.lblDevice = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbDevices = new System.Windows.Forms.ComboBox();
            this.panelWaitTime = new System.Windows.Forms.Panel();
            this.btnDeleteWait = new System.Windows.Forms.Button();
            this.btnSaveWait = new System.Windows.Forms.Button();
            this.btnAddWait = new System.Windows.Forms.Button();
            this.tbWaitTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDoc = new System.Windows.Forms.LinkLabel();
            this.btnTestCmds = new System.Windows.Forms.Button();
            this.panelCommand.SuspendLayout();
            this.panelWaitTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCommands
            // 
            this.lbCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCommands.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCommands.FormattingEnabled = true;
            this.lbCommands.ItemHeight = 20;
            this.lbCommands.Location = new System.Drawing.Point(10, 124);
            this.lbCommands.Name = "lbCommands";
            this.lbCommands.Size = new System.Drawing.Size(598, 144);
            this.lbCommands.TabIndex = 0;
            this.lbCommands.SelectedIndexChanged += new System.EventHandler(this.lbCommands_SelectedIndexChanged);
            // 
            // cmbAddCommand
            // 
            this.cmbAddCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAddCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAddCommand.FormattingEnabled = true;
            this.cmbAddCommand.Items.AddRange(new object[] {
            "Command",
            "Wait Time"});
            this.cmbAddCommand.Location = new System.Drawing.Point(12, 39);
            this.cmbAddCommand.Name = "cmbAddCommand";
            this.cmbAddCommand.Size = new System.Drawing.Size(112, 28);
            this.cmbAddCommand.TabIndex = 46;
            this.cmbAddCommand.SelectedIndexChanged += new System.EventHandler(this.cmbAddCommand_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 20);
            this.label7.TabIndex = 45;
            this.label7.Text = "or Wait Time:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelCommand
            // 
            this.panelCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCommand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCommand.Controls.Add(this.btnDeleteCmd);
            this.panelCommand.Controls.Add(this.btnAddCmd);
            this.panelCommand.Controls.Add(this.tbParam);
            this.panelCommand.Controls.Add(this.btnSaveCmd);
            this.panelCommand.Controls.Add(this.lblParam);
            this.panelCommand.Controls.Add(this.tbCommand);
            this.panelCommand.Controls.Add(this.lblDevice);
            this.panelCommand.Controls.Add(this.label10);
            this.panelCommand.Controls.Add(this.cmbDevices);
            this.panelCommand.Location = new System.Drawing.Point(130, 5);
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Size = new System.Drawing.Size(542, 109);
            this.panelCommand.TabIndex = 47;
            this.panelCommand.Visible = false;
            // 
            // btnDeleteCmd
            // 
            this.btnDeleteCmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCmd.Location = new System.Drawing.Point(246, 3);
            this.btnDeleteCmd.Name = "btnDeleteCmd";
            this.btnDeleteCmd.Size = new System.Drawing.Size(70, 28);
            this.btnDeleteCmd.TabIndex = 59;
            this.btnDeleteCmd.Text = "Delete";
            this.btnDeleteCmd.UseVisualStyleBackColor = true;
            this.btnDeleteCmd.Click += new System.EventHandler(this.btnDeleteCmd_Click);
            // 
            // btnAddCmd
            // 
            this.btnAddCmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCmd.Location = new System.Drawing.Point(165, 3);
            this.btnAddCmd.Name = "btnAddCmd";
            this.btnAddCmd.Size = new System.Drawing.Size(75, 28);
            this.btnAddCmd.TabIndex = 57;
            this.btnAddCmd.Text = "Add";
            this.btnAddCmd.UseVisualStyleBackColor = true;
            this.btnAddCmd.Click += new System.EventHandler(this.btnAddCmd_Click);
            // 
            // tbParam
            // 
            this.tbParam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbParam.Location = new System.Drawing.Point(165, 72);
            this.tbParam.Name = "tbParam";
            this.tbParam.Size = new System.Drawing.Size(368, 26);
            this.tbParam.TabIndex = 54;
            // 
            // btnSaveCmd
            // 
            this.btnSaveCmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveCmd.Location = new System.Drawing.Point(165, 3);
            this.btnSaveCmd.Name = "btnSaveCmd";
            this.btnSaveCmd.Size = new System.Drawing.Size(75, 28);
            this.btnSaveCmd.TabIndex = 58;
            this.btnSaveCmd.Text = "Save";
            this.btnSaveCmd.UseVisualStyleBackColor = true;
            this.btnSaveCmd.Click += new System.EventHandler(this.btnSaveCmd_Click);
            // 
            // lblParam
            // 
            this.lblParam.AutoSize = true;
            this.lblParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParam.Location = new System.Drawing.Point(94, 75);
            this.lblParam.Name = "lblParam";
            this.lblParam.Size = new System.Drawing.Size(65, 20);
            this.lblParam.TabIndex = 55;
            this.lblParam.Text = "Param:";
            // 
            // tbCommand
            // 
            this.tbCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCommand.Location = new System.Drawing.Point(165, 40);
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(368, 26);
            this.tbCommand.TabIndex = 52;
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevice.Location = new System.Drawing.Point(3, 34);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(63, 20);
            this.lblDevice.TabIndex = 48;
            this.lblDevice.Text = "Device";
            this.lblDevice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(109, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 20);
            this.label10.TabIndex = 53;
            this.label10.Text = "Cmd:";
            // 
            // cmbDevices
            // 
            this.cmbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDevices.FormattingEnabled = true;
            this.cmbDevices.Location = new System.Drawing.Point(3, 3);
            this.cmbDevices.Name = "cmbDevices";
            this.cmbDevices.Size = new System.Drawing.Size(156, 28);
            this.cmbDevices.TabIndex = 48;
            // 
            // panelWaitTime
            // 
            this.panelWaitTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWaitTime.Controls.Add(this.btnDeleteWait);
            this.panelWaitTime.Controls.Add(this.btnSaveWait);
            this.panelWaitTime.Controls.Add(this.btnAddWait);
            this.panelWaitTime.Controls.Add(this.tbWaitTime);
            this.panelWaitTime.Controls.Add(this.label2);
            this.panelWaitTime.Location = new System.Drawing.Point(130, 5);
            this.panelWaitTime.Name = "panelWaitTime";
            this.panelWaitTime.Size = new System.Drawing.Size(200, 109);
            this.panelWaitTime.TabIndex = 48;
            this.panelWaitTime.Visible = false;
            // 
            // btnDeleteWait
            // 
            this.btnDeleteWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteWait.Location = new System.Drawing.Point(84, 72);
            this.btnDeleteWait.Name = "btnDeleteWait";
            this.btnDeleteWait.Size = new System.Drawing.Size(75, 28);
            this.btnDeleteWait.TabIndex = 63;
            this.btnDeleteWait.Text = "Delete";
            this.btnDeleteWait.UseVisualStyleBackColor = true;
            this.btnDeleteWait.Click += new System.EventHandler(this.btnDeleteWait_Click);
            // 
            // btnSaveWait
            // 
            this.btnSaveWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveWait.Location = new System.Drawing.Point(5, 72);
            this.btnSaveWait.Name = "btnSaveWait";
            this.btnSaveWait.Size = new System.Drawing.Size(75, 28);
            this.btnSaveWait.TabIndex = 62;
            this.btnSaveWait.Text = "Save";
            this.btnSaveWait.UseVisualStyleBackColor = true;
            this.btnSaveWait.Click += new System.EventHandler(this.btnSaveWait_Click);
            // 
            // btnAddWait
            // 
            this.btnAddWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddWait.Location = new System.Drawing.Point(5, 71);
            this.btnAddWait.Name = "btnAddWait";
            this.btnAddWait.Size = new System.Drawing.Size(75, 28);
            this.btnAddWait.TabIndex = 60;
            this.btnAddWait.Text = "Add";
            this.btnAddWait.UseVisualStyleBackColor = true;
            this.btnAddWait.Click += new System.EventHandler(this.btnAddWait_Click);
            // 
            // tbWaitTime
            // 
            this.tbWaitTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWaitTime.Location = new System.Drawing.Point(6, 33);
            this.tbWaitTime.Name = "tbWaitTime";
            this.tbWaitTime.Size = new System.Drawing.Size(124, 26);
            this.tbWaitTime.TabIndex = 60;
            this.tbWaitTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbWaitTime_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 61;
            this.label2.Text = "Wait Time (ms)";
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.Location = new System.Drawing.Point(634, 160);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(30, 30);
            this.btnDown.TabIndex = 50;
            this.btnDown.Text = "V";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.Location = new System.Drawing.Point(634, 124);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(30, 30);
            this.btnUp.TabIndex = 49;
            this.btnUp.Text = "Λ";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveClose.Location = new System.Drawing.Point(10, 87);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(114, 28);
            this.btnSaveClose.TabIndex = 64;
            this.btnSaveClose.Text = "Save/Close";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 65;
            this.label1.Text = "Add a Cmd";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnDoc
            // 
            this.btnDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoc.AutoSize = true;
            this.btnDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoc.Location = new System.Drawing.Point(626, 249);
            this.btnDoc.Name = "btnDoc";
            this.btnDoc.Size = new System.Drawing.Size(41, 20);
            this.btnDoc.TabIndex = 67;
            this.btnDoc.TabStop = true;
            this.btnDoc.Text = "Doc";
            this.btnDoc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDoc_LinkClicked);
            // 
            // btnTestCmds
            // 
            this.btnTestCmds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestCmds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestCmds.Location = new System.Drawing.Point(614, 196);
            this.btnTestCmds.Name = "btnTestCmds";
            this.btnTestCmds.Size = new System.Drawing.Size(65, 48);
            this.btnTestCmds.TabIndex = 68;
            this.btnTestCmds.Text = "Test CMDs";
            this.btnTestCmds.UseVisualStyleBackColor = true;
            this.btnTestCmds.Click += new System.EventHandler(this.btnTestCmds_Click);
            // 
            // CommandEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 276);
            this.Controls.Add(this.btnTestCmds);
            this.Controls.Add(this.btnDoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.panelWaitTime);
            this.Controls.Add(this.panelCommand);
            this.Controls.Add(this.cmbAddCommand);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbCommands);
            this.KeyPreview = true;
            this.Name = "CommandEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Command Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommandEditor_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommandEditor_KeyDown);
            this.panelCommand.ResumeLayout(false);
            this.panelCommand.PerformLayout();
            this.panelWaitTime.ResumeLayout(false);
            this.panelWaitTime.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbCommands;
        private System.Windows.Forms.ComboBox cmbAddCommand;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelCommand;
        private System.Windows.Forms.ComboBox cmbDevices;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.TextBox tbParam;
        private System.Windows.Forms.Label lblParam;
        private System.Windows.Forms.TextBox tbCommand;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panelWaitTime;
        private System.Windows.Forms.Button btnAddCmd;
        private System.Windows.Forms.Button btnDeleteCmd;
        private System.Windows.Forms.Button btnSaveCmd;
        private System.Windows.Forms.TextBox tbWaitTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteWait;
        private System.Windows.Forms.Button btnSaveWait;
        private System.Windows.Forms.Button btnAddWait;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel btnDoc;
        private System.Windows.Forms.Button btnTestCmds;
    }
}