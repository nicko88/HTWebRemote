namespace HTWebRemote.Forms
{
    partial class RemoteEditor
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
            this.lbRemoteItems = new System.Windows.Forms.ListBox();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnLabelTricks = new System.Windows.Forms.LinkLabel();
            this.btnSizeHelp = new System.Windows.Forms.LinkLabel();
            this.btnSaveButton = new System.Windows.Forms.Button();
            this.btnDeleteButton = new System.Windows.Forms.Button();
            this.btnAddButton = new System.Windows.Forms.Button();
            this.tbButtonSize = new System.Windows.Forms.TextBox();
            this.tbButtonLabel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbButtonColor = new System.Windows.Forms.ComboBox();
            this.cbButtonConfirm = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblButtonColor = new System.Windows.Forms.Label();
            this.cmbRemoteID = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnDeleteRemote = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbAddItem = new System.Windows.Forms.ComboBox();
            this.panelGroup = new System.Windows.Forms.Panel();
            this.btnSaveGroup = new System.Windows.Forms.Button();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.tbGroupLabel = new System.Windows.Forms.TextBox();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panelBlank = new System.Windows.Forms.Panel();
            this.btnSaveBlank = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteBlank = new System.Windows.Forms.Button();
            this.btnAddBlank = new System.Windows.Forms.Button();
            this.tbBlankSize = new System.Windows.Forms.TextBox();
            this.panelNewRow = new System.Windows.Forms.Panel();
            this.btnDeleteNewRow = new System.Windows.Forms.Button();
            this.btnAddNewRow = new System.Windows.Forms.Button();
            this.btnRemoteSave = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.tbButtonHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRemoteName = new System.Windows.Forms.TextBox();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlBackColor = new System.Windows.Forms.Panel();
            this.pnlTextColor = new System.Windows.Forms.Panel();
            this.btnCopy = new System.Windows.Forms.Button();
            this.cbHideRemote = new System.Windows.Forms.CheckBox();
            this.panelButton.SuspendLayout();
            this.panelGroup.SuspendLayout();
            this.panelBlank.SuspendLayout();
            this.panelNewRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbRemoteItems
            // 
            this.lbRemoteItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRemoteItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRemoteItems.FormattingEnabled = true;
            this.lbRemoteItems.ItemHeight = 20;
            this.lbRemoteItems.Location = new System.Drawing.Point(12, 151);
            this.lbRemoteItems.Name = "lbRemoteItems";
            this.lbRemoteItems.Size = new System.Drawing.Size(446, 684);
            this.lbRemoteItems.TabIndex = 0;
            this.lbRemoteItems.SelectedIndexChanged += new System.EventHandler(this.lbRemoteItems_SelectedIndexChanged);
            this.lbRemoteItems.DoubleClick += new System.EventHandler(this.lbRemoteItems_DoubleClick);
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(500, 131);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(400, 704);
            this.webBrowser.TabIndex = 1;
            // 
            // panelButton
            // 
            this.panelButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButton.Controls.Add(this.btnLabelTricks);
            this.panelButton.Controls.Add(this.btnSizeHelp);
            this.panelButton.Controls.Add(this.btnSaveButton);
            this.panelButton.Controls.Add(this.btnDeleteButton);
            this.panelButton.Controls.Add(this.btnAddButton);
            this.panelButton.Controls.Add(this.tbButtonSize);
            this.panelButton.Controls.Add(this.tbButtonLabel);
            this.panelButton.Controls.Add(this.label10);
            this.panelButton.Controls.Add(this.cmbButtonColor);
            this.panelButton.Controls.Add(this.cbButtonConfirm);
            this.panelButton.Controls.Add(this.label4);
            this.panelButton.Controls.Add(this.lblButtonColor);
            this.panelButton.Location = new System.Drawing.Point(159, 40);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(741, 65);
            this.panelButton.TabIndex = 2;
            this.panelButton.Visible = false;
            // 
            // btnLabelTricks
            // 
            this.btnLabelTricks.AutoSize = true;
            this.btnLabelTricks.Location = new System.Drawing.Point(120, 11);
            this.btnLabelTricks.Name = "btnLabelTricks";
            this.btnLabelTricks.Size = new System.Drawing.Size(44, 13);
            this.btnLabelTricks.TabIndex = 55;
            this.btnLabelTricks.TabStop = true;
            this.btnLabelTricks.Text = "symbols";
            this.btnLabelTricks.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnLabelTricks_LinkClicked);
            // 
            // btnSizeHelp
            // 
            this.btnSizeHelp.AutoSize = true;
            this.btnSizeHelp.Location = new System.Drawing.Point(375, 41);
            this.btnSizeHelp.Name = "btnSizeHelp";
            this.btnSizeHelp.Size = new System.Drawing.Size(33, 13);
            this.btnSizeHelp.TabIndex = 54;
            this.btnSizeHelp.TabStop = true;
            this.btnSizeHelp.Text = "help?";
            this.btnSizeHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSizeHelp_LinkClicked);
            // 
            // btnSaveButton
            // 
            this.btnSaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveButton.Location = new System.Drawing.Point(587, 25);
            this.btnSaveButton.Name = "btnSaveButton";
            this.btnSaveButton.Size = new System.Drawing.Size(66, 28);
            this.btnSaveButton.TabIndex = 53;
            this.btnSaveButton.Text = "Save";
            this.btnSaveButton.UseVisualStyleBackColor = true;
            this.btnSaveButton.Visible = false;
            this.btnSaveButton.Click += new System.EventHandler(this.btnSaveButton_Click);
            // 
            // btnDeleteButton
            // 
            this.btnDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteButton.Location = new System.Drawing.Point(659, 25);
            this.btnDeleteButton.Name = "btnDeleteButton";
            this.btnDeleteButton.Size = new System.Drawing.Size(72, 28);
            this.btnDeleteButton.TabIndex = 52;
            this.btnDeleteButton.Text = "Delete";
            this.btnDeleteButton.UseVisualStyleBackColor = true;
            this.btnDeleteButton.Visible = false;
            this.btnDeleteButton.Click += new System.EventHandler(this.btnDeleteButton_Click);
            // 
            // btnAddButton
            // 
            this.btnAddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddButton.Location = new System.Drawing.Point(587, 25);
            this.btnAddButton.Name = "btnAddButton";
            this.btnAddButton.Size = new System.Drawing.Size(66, 28);
            this.btnAddButton.TabIndex = 45;
            this.btnAddButton.Text = "Add";
            this.btnAddButton.UseVisualStyleBackColor = true;
            this.btnAddButton.Visible = false;
            this.btnAddButton.Click += new System.EventHandler(this.btnAddButton_Click);
            // 
            // tbButtonSize
            // 
            this.tbButtonSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbButtonSize.Location = new System.Drawing.Point(276, 28);
            this.tbButtonSize.Name = "tbButtonSize";
            this.tbButtonSize.Size = new System.Drawing.Size(99, 26);
            this.tbButtonSize.TabIndex = 47;
            this.tbButtonSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbButtonSize_KeyPress);
            // 
            // tbButtonLabel
            // 
            this.tbButtonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbButtonLabel.Location = new System.Drawing.Point(7, 28);
            this.tbButtonLabel.Name = "tbButtonLabel";
            this.tbButtonLabel.Size = new System.Drawing.Size(167, 26);
            this.tbButtonLabel.TabIndex = 46;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(272, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 20);
            this.label10.TabIndex = 51;
            this.label10.Text = "Button Size";
            // 
            // cmbButtonColor
            // 
            this.cmbButtonColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbButtonColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbButtonColor.FormattingEnabled = true;
            this.cmbButtonColor.Items.AddRange(new object[] {
            "Blue",
            "Green",
            "Red",
            "Orange",
            "Teal",
            "Gray",
            "White",
            "Black"});
            this.cmbButtonColor.Location = new System.Drawing.Point(180, 27);
            this.cmbButtonColor.MaxDropDownItems = 10;
            this.cmbButtonColor.Name = "cmbButtonColor";
            this.cmbButtonColor.Size = new System.Drawing.Size(90, 28);
            this.cmbButtonColor.TabIndex = 45;
            // 
            // cbButtonConfirm
            // 
            this.cbButtonConfirm.AutoSize = true;
            this.cbButtonConfirm.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbButtonConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbButtonConfirm.Location = new System.Drawing.Point(381, 11);
            this.cbButtonConfirm.Name = "cbButtonConfirm";
            this.cbButtonConfirm.Size = new System.Drawing.Size(200, 38);
            this.cbButtonConfirm.TabIndex = 48;
            this.cbButtonConfirm.Text = "Button Confirm Popup?";
            this.cbButtonConfirm.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbButtonConfirm.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 20);
            this.label4.TabIndex = 49;
            this.label4.Text = "Button Label";
            // 
            // lblButtonColor
            // 
            this.lblButtonColor.AutoSize = true;
            this.lblButtonColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblButtonColor.Location = new System.Drawing.Point(176, 3);
            this.lblButtonColor.Name = "lblButtonColor";
            this.lblButtonColor.Size = new System.Drawing.Size(51, 20);
            this.lblButtonColor.TabIndex = 50;
            this.lblButtonColor.Text = "Color";
            // 
            // cmbRemoteID
            // 
            this.cmbRemoteID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRemoteID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRemoteID.FormattingEnabled = true;
            this.cmbRemoteID.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cmbRemoteID.Location = new System.Drawing.Point(110, 6);
            this.cmbRemoteID.Name = "cmbRemoteID";
            this.cmbRemoteID.Size = new System.Drawing.Size(42, 28);
            this.cmbRemoteID.TabIndex = 3;
            this.cmbRemoteID.SelectedIndexChanged += new System.EventHandler(this.cmbRemoteID_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 20);
            this.label13.TabIndex = 38;
            this.label13.Text = "Remote #:";
            // 
            // btnDeleteRemote
            // 
            this.btnDeleteRemote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRemote.Location = new System.Drawing.Point(158, 6);
            this.btnDeleteRemote.Name = "btnDeleteRemote";
            this.btnDeleteRemote.Size = new System.Drawing.Size(70, 28);
            this.btnDeleteRemote.TabIndex = 39;
            this.btnDeleteRemote.Text = "Delete";
            this.btnDeleteRemote.UseVisualStyleBackColor = true;
            this.btnDeleteRemote.Click += new System.EventHandler(this.btnDeleteRemote_Click);
            // 
            // btnDown
            // 
            this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.Location = new System.Drawing.Point(464, 402);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(30, 30);
            this.btnDown.TabIndex = 43;
            this.btnDown.Text = "V";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.Location = new System.Drawing.Point(464, 366);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(30, 30);
            this.btnUp.TabIndex = 42;
            this.btnUp.Text = "Λ";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Add Item:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbAddItem
            // 
            this.cmbAddItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAddItem.FormattingEnabled = true;
            this.cmbAddItem.Items.AddRange(new object[] {
            "Group",
            "Button",
            "Blank Space",
            "New Line"});
            this.cmbAddItem.Location = new System.Drawing.Point(12, 62);
            this.cmbAddItem.Name = "cmbAddItem";
            this.cmbAddItem.Size = new System.Drawing.Size(140, 28);
            this.cmbAddItem.TabIndex = 44;
            this.cmbAddItem.SelectedIndexChanged += new System.EventHandler(this.cmbAddItem_SelectedIndexChanged);
            // 
            // panelGroup
            // 
            this.panelGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGroup.Controls.Add(this.btnSaveGroup);
            this.panelGroup.Controls.Add(this.btnDeleteGroup);
            this.panelGroup.Controls.Add(this.tbGroupLabel);
            this.panelGroup.Controls.Add(this.btnAddGroup);
            this.panelGroup.Controls.Add(this.label6);
            this.panelGroup.Location = new System.Drawing.Point(159, 40);
            this.panelGroup.Name = "panelGroup";
            this.panelGroup.Size = new System.Drawing.Size(333, 65);
            this.panelGroup.TabIndex = 45;
            this.panelGroup.Visible = false;
            // 
            // btnSaveGroup
            // 
            this.btnSaveGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveGroup.Location = new System.Drawing.Point(182, 27);
            this.btnSaveGroup.Name = "btnSaveGroup";
            this.btnSaveGroup.Size = new System.Drawing.Size(66, 28);
            this.btnSaveGroup.TabIndex = 56;
            this.btnSaveGroup.Text = "Save";
            this.btnSaveGroup.UseVisualStyleBackColor = true;
            this.btnSaveGroup.Visible = false;
            this.btnSaveGroup.Click += new System.EventHandler(this.btnSaveGroup_Click);
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteGroup.Location = new System.Drawing.Point(254, 27);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(72, 28);
            this.btnDeleteGroup.TabIndex = 55;
            this.btnDeleteGroup.Text = "Delete";
            this.btnDeleteGroup.UseVisualStyleBackColor = true;
            this.btnDeleteGroup.Visible = false;
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
            // 
            // tbGroupLabel
            // 
            this.tbGroupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGroupLabel.Location = new System.Drawing.Point(7, 28);
            this.tbGroupLabel.Name = "tbGroupLabel";
            this.tbGroupLabel.Size = new System.Drawing.Size(169, 26);
            this.tbGroupLabel.TabIndex = 54;
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddGroup.Location = new System.Drawing.Point(182, 27);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(66, 28);
            this.btnAddGroup.TabIndex = 54;
            this.btnAddGroup.Text = "Add";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Visible = false;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 20);
            this.label6.TabIndex = 55;
            this.label6.Text = "Group Label";
            // 
            // panelBlank
            // 
            this.panelBlank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBlank.Controls.Add(this.btnSaveBlank);
            this.panelBlank.Controls.Add(this.label1);
            this.panelBlank.Controls.Add(this.btnDeleteBlank);
            this.panelBlank.Controls.Add(this.btnAddBlank);
            this.panelBlank.Controls.Add(this.tbBlankSize);
            this.panelBlank.Location = new System.Drawing.Point(159, 40);
            this.panelBlank.Name = "panelBlank";
            this.panelBlank.Size = new System.Drawing.Size(339, 65);
            this.panelBlank.TabIndex = 46;
            this.panelBlank.Visible = false;
            // 
            // btnSaveBlank
            // 
            this.btnSaveBlank.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveBlank.Location = new System.Drawing.Point(187, 27);
            this.btnSaveBlank.Name = "btnSaveBlank";
            this.btnSaveBlank.Size = new System.Drawing.Size(66, 28);
            this.btnSaveBlank.TabIndex = 61;
            this.btnSaveBlank.Text = "Save";
            this.btnSaveBlank.UseVisualStyleBackColor = true;
            this.btnSaveBlank.Visible = false;
            this.btnSaveBlank.Click += new System.EventHandler(this.btnSaveBlank_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 60;
            this.label1.Text = "Blank Size";
            // 
            // btnDeleteBlank
            // 
            this.btnDeleteBlank.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteBlank.Location = new System.Drawing.Point(259, 27);
            this.btnDeleteBlank.Name = "btnDeleteBlank";
            this.btnDeleteBlank.Size = new System.Drawing.Size(72, 28);
            this.btnDeleteBlank.TabIndex = 59;
            this.btnDeleteBlank.Text = "Delete";
            this.btnDeleteBlank.UseVisualStyleBackColor = true;
            this.btnDeleteBlank.Visible = false;
            this.btnDeleteBlank.Click += new System.EventHandler(this.btnDeleteBlank_Click);
            // 
            // btnAddBlank
            // 
            this.btnAddBlank.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBlank.Location = new System.Drawing.Point(187, 27);
            this.btnAddBlank.Name = "btnAddBlank";
            this.btnAddBlank.Size = new System.Drawing.Size(66, 28);
            this.btnAddBlank.TabIndex = 58;
            this.btnAddBlank.Text = "Add";
            this.btnAddBlank.UseVisualStyleBackColor = true;
            this.btnAddBlank.Visible = false;
            this.btnAddBlank.Click += new System.EventHandler(this.btnAddBlank_Click);
            // 
            // tbBlankSize
            // 
            this.tbBlankSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBlankSize.Location = new System.Drawing.Point(7, 28);
            this.tbBlankSize.Name = "tbBlankSize";
            this.tbBlankSize.Size = new System.Drawing.Size(174, 26);
            this.tbBlankSize.TabIndex = 57;
            this.tbBlankSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBlankSize_KeyPress);
            // 
            // panelNewRow
            // 
            this.panelNewRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNewRow.Controls.Add(this.btnDeleteNewRow);
            this.panelNewRow.Controls.Add(this.btnAddNewRow);
            this.panelNewRow.Location = new System.Drawing.Point(159, 40);
            this.panelNewRow.Name = "panelNewRow";
            this.panelNewRow.Size = new System.Drawing.Size(164, 65);
            this.panelNewRow.TabIndex = 47;
            this.panelNewRow.Visible = false;
            // 
            // btnDeleteNewRow
            // 
            this.btnDeleteNewRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteNewRow.Location = new System.Drawing.Point(6, 27);
            this.btnDeleteNewRow.Name = "btnDeleteNewRow";
            this.btnDeleteNewRow.Size = new System.Drawing.Size(150, 28);
            this.btnDeleteNewRow.TabIndex = 49;
            this.btnDeleteNewRow.Text = "Delete New Row";
            this.btnDeleteNewRow.UseVisualStyleBackColor = true;
            this.btnDeleteNewRow.Click += new System.EventHandler(this.btnDeleteNewRow_Click);
            // 
            // btnAddNewRow
            // 
            this.btnAddNewRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewRow.Location = new System.Drawing.Point(6, 27);
            this.btnAddNewRow.Name = "btnAddNewRow";
            this.btnAddNewRow.Size = new System.Drawing.Size(150, 28);
            this.btnAddNewRow.TabIndex = 48;
            this.btnAddNewRow.Text = "Start New Row";
            this.btnAddNewRow.UseVisualStyleBackColor = true;
            this.btnAddNewRow.Click += new System.EventHandler(this.btnAddNewRow_Click);
            // 
            // btnRemoteSave
            // 
            this.btnRemoteSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoteSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoteSave.Location = new System.Drawing.Point(840, 6);
            this.btnRemoteSave.Name = "btnRemoteSave";
            this.btnRemoteSave.Size = new System.Drawing.Size(60, 28);
            this.btnRemoteSave.TabIndex = 50;
            this.btnRemoteSave.Text = "Save";
            this.btnRemoteSave.UseVisualStyleBackColor = true;
            this.btnRemoteSave.Click += new System.EventHandler(this.btnRemoteSave_Click);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(723, -2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 40);
            this.label15.TabIndex = 49;
            this.label15.Text = "Button Height";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbButtonHeight
            // 
            this.tbButtonHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbButtonHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbButtonHeight.Location = new System.Drawing.Point(794, 7);
            this.tbButtonHeight.Name = "tbButtonHeight";
            this.tbButtonHeight.Size = new System.Drawing.Size(40, 26);
            this.tbButtonHeight.TabIndex = 48;
            this.tbButtonHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbButtonHeight_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(498, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(393, 15);
            this.label2.TabIndex = 51;
            this.label2.Text = "Buttons are just for show and wont actually send commands.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(404, 16);
            this.label3.TabIndex = 52;
            this.label3.Text = "Double-click a button row to add / edit remote commands,";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(311, -1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 40);
            this.label5.TabIndex = 54;
            this.label5.Text = "Remote Name";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbRemoteName
            // 
            this.tbRemoteName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRemoteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRemoteName.Location = new System.Drawing.Point(384, 7);
            this.tbRemoteName.Name = "tbRemoteName";
            this.tbRemoteName.Size = new System.Drawing.Size(122, 26);
            this.tbRemoteName.TabIndex = 53;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(507, -1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 40);
            this.label8.TabIndex = 55;
            this.label8.Text = "Background Color";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(640, -1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 40);
            this.label9.TabIndex = 56;
            this.label9.Text = "Text Color";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlBackColor
            // 
            this.pnlBackColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBackColor.Location = new System.Drawing.Point(613, 9);
            this.pnlBackColor.Name = "pnlBackColor";
            this.pnlBackColor.Size = new System.Drawing.Size(24, 24);
            this.pnlBackColor.TabIndex = 57;
            this.pnlBackColor.Click += new System.EventHandler(this.pnlBackColor_Click);
            // 
            // pnlTextColor
            // 
            this.pnlTextColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTextColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTextColor.Location = new System.Drawing.Point(697, 9);
            this.pnlTextColor.Name = "pnlTextColor";
            this.pnlTextColor.Size = new System.Drawing.Size(24, 24);
            this.pnlTextColor.TabIndex = 58;
            this.pnlTextColor.Click += new System.EventHandler(this.pnlTextColor_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Location = new System.Drawing.Point(12, 98);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(140, 30);
            this.btnCopy.TabIndex = 60;
            this.btnCopy.Text = "Copy Selected";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // cbHideRemote
            // 
            this.cbHideRemote.AutoSize = true;
            this.cbHideRemote.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbHideRemote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHideRemote.Location = new System.Drawing.Point(246, 0);
            this.cbHideRemote.Name = "cbHideRemote";
            this.cbHideRemote.Size = new System.Drawing.Size(50, 38);
            this.cbHideRemote.TabIndex = 56;
            this.cbHideRemote.Text = "Hide";
            this.cbHideRemote.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbHideRemote.UseVisualStyleBackColor = true;
            // 
            // RemoteEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 844);
            this.Controls.Add(this.cbHideRemote);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.pnlTextColor);
            this.Controls.Add(this.pnlBackColor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbRemoteName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRemoteSave);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbButtonHeight);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.panelNewRow);
            this.Controls.Add(this.panelBlank);
            this.Controls.Add(this.panelGroup);
            this.Controls.Add(this.cmbAddItem);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDeleteRemote);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbRemoteID);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.lbRemoteItems);
            this.Name = "RemoteEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remote Editor";
            this.panelButton.ResumeLayout(false);
            this.panelButton.PerformLayout();
            this.panelGroup.ResumeLayout(false);
            this.panelGroup.PerformLayout();
            this.panelBlank.ResumeLayout(false);
            this.panelBlank.PerformLayout();
            this.panelNewRow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbRemoteItems;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.ComboBox cmbRemoteID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnDeleteRemote;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbAddItem;
        private System.Windows.Forms.TextBox tbButtonSize;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbButtonConfirm;
        private System.Windows.Forms.Label lblButtonColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbButtonColor;
        private System.Windows.Forms.Button btnAddButton;
        private System.Windows.Forms.Button btnSaveButton;
        private System.Windows.Forms.Button btnDeleteButton;
        private System.Windows.Forms.TextBox tbButtonLabel;
        private System.Windows.Forms.Panel panelGroup;
        private System.Windows.Forms.Panel panelBlank;
        private System.Windows.Forms.TextBox tbGroupLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelNewRow;
        private System.Windows.Forms.Button btnSaveGroup;
        private System.Windows.Forms.Button btnDeleteGroup;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Button btnSaveBlank;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteBlank;
        private System.Windows.Forms.Button btnAddBlank;
        private System.Windows.Forms.TextBox tbBlankSize;
        private System.Windows.Forms.Button btnAddNewRow;
        private System.Windows.Forms.Button btnDeleteNewRow;
        private System.Windows.Forms.Button btnRemoteSave;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbButtonHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbRemoteName;
        private System.Windows.Forms.LinkLabel btnSizeHelp;
        private System.Windows.Forms.LinkLabel btnLabelTricks;
        private System.Windows.Forms.ColorDialog colorPicker;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlBackColor;
        private System.Windows.Forms.Panel pnlTextColor;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.CheckBox cbHideRemote;
    }
}