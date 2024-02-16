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
            this.cbHoldable = new System.Windows.Forms.CheckBox();
            this.tbButtonHeight = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.pnlButtonColor = new System.Windows.Forms.Panel();
            this.btnLabelTricks = new System.Windows.Forms.LinkLabel();
            this.btnSizeHelp = new System.Windows.Forms.LinkLabel();
            this.btnSaveButton = new System.Windows.Forms.Button();
            this.btnDeleteButton = new System.Windows.Forms.Button();
            this.btnAddButton = new System.Windows.Forms.Button();
            this.tbButtonSize = new System.Windows.Forms.TextBox();
            this.tbButtonLabel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
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
            this.pnlGroupColor = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
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
            this.btnSaveRemote = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.tbGlobalButtonHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRemoteName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlBackColor = new System.Windows.Forms.Panel();
            this.btnCopy = new System.Windows.Forms.Button();
            this.cbHideRemote = new System.Windows.Forms.CheckBox();
            this.tbShadingStrength = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblClearCopy = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnReorderRemotes = new System.Windows.Forms.Button();
            this.btnDeleteItems = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.tbRemoteGroup = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.panelButton.SuspendLayout();
            this.panelGroup.SuspendLayout();
            this.panelBlank.SuspendLayout();
            this.panelNewRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbRemoteItems
            // 
            this.lbRemoteItems.AllowDrop = true;
            this.lbRemoteItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRemoteItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRemoteItems.FormattingEnabled = true;
            this.lbRemoteItems.ItemHeight = 20;
            this.lbRemoteItems.Location = new System.Drawing.Point(12, 171);
            this.lbRemoteItems.Name = "lbRemoteItems";
            this.lbRemoteItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbRemoteItems.Size = new System.Drawing.Size(446, 644);
            this.lbRemoteItems.TabIndex = 0;
            this.lbRemoteItems.SelectedIndexChanged += new System.EventHandler(this.lbRemoteItems_SelectedIndexChanged);
            this.lbRemoteItems.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbRemoteItems_DragDrop);
            this.lbRemoteItems.DragOver += new System.Windows.Forms.DragEventHandler(this.lbRemoteItems_DragOver);
            this.lbRemoteItems.DoubleClick += new System.EventHandler(this.lbRemoteItems_DoubleClick);
            this.lbRemoteItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbRemoteItems_KeyDown);
            this.lbRemoteItems.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbRemoteItems_MouseDown);
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(500, 154);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(417, 681);
            this.webBrowser.TabIndex = 1;
            // 
            // panelButton
            // 
            this.panelButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButton.Controls.Add(this.cbHoldable);
            this.panelButton.Controls.Add(this.tbButtonHeight);
            this.panelButton.Controls.Add(this.label14);
            this.panelButton.Controls.Add(this.pnlButtonColor);
            this.panelButton.Controls.Add(this.btnLabelTricks);
            this.panelButton.Controls.Add(this.btnSizeHelp);
            this.panelButton.Controls.Add(this.btnSaveButton);
            this.panelButton.Controls.Add(this.btnDeleteButton);
            this.panelButton.Controls.Add(this.btnAddButton);
            this.panelButton.Controls.Add(this.tbButtonSize);
            this.panelButton.Controls.Add(this.tbButtonLabel);
            this.panelButton.Controls.Add(this.label10);
            this.panelButton.Controls.Add(this.cbButtonConfirm);
            this.panelButton.Controls.Add(this.label4);
            this.panelButton.Controls.Add(this.lblButtonColor);
            this.panelButton.Location = new System.Drawing.Point(175, 65);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(741, 65);
            this.panelButton.TabIndex = 2;
            this.panelButton.Visible = false;
            // 
            // cbHoldable
            // 
            this.cbHoldable.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbHoldable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHoldable.Location = new System.Drawing.Point(527, 1);
            this.cbHoldable.Name = "cbHoldable";
            this.cbHoldable.Size = new System.Drawing.Size(50, 58);
            this.cbHoldable.TabIndex = 61;
            this.cbHoldable.Text = "Can Hold";
            this.cbHoldable.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cbHoldable.UseVisualStyleBackColor = true;
            // 
            // tbButtonHeight
            // 
            this.tbButtonHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbButtonHeight.Location = new System.Drawing.Point(374, 28);
            this.tbButtonHeight.Name = "tbButtonHeight";
            this.tbButtonHeight.Size = new System.Drawing.Size(60, 26);
            this.tbButtonHeight.TabIndex = 60;
            this.tbButtonHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumOnly_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(370, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 20);
            this.label14.TabIndex = 59;
            this.label14.Text = "Height";
            // 
            // pnlButtonColor
            // 
            this.pnlButtonColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlButtonColor.Location = new System.Drawing.Point(213, 28);
            this.pnlButtonColor.Name = "pnlButtonColor";
            this.pnlButtonColor.Size = new System.Drawing.Size(57, 27);
            this.pnlButtonColor.TabIndex = 58;
            this.pnlButtonColor.Click += new System.EventHandler(this.pnlButtonColor_Click);
            // 
            // btnLabelTricks
            // 
            this.btnLabelTricks.AutoSize = true;
            this.btnLabelTricks.Location = new System.Drawing.Point(137, 11);
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
            this.btnSizeHelp.Location = new System.Drawing.Point(328, 10);
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
            this.tbButtonSize.Size = new System.Drawing.Size(79, 26);
            this.tbButtonSize.TabIndex = 47;
            this.tbButtonSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumOnly_KeyPress);
            // 
            // tbButtonLabel
            // 
            this.tbButtonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbButtonLabel.Location = new System.Drawing.Point(7, 28);
            this.tbButtonLabel.Name = "tbButtonLabel";
            this.tbButtonLabel.Size = new System.Drawing.Size(200, 26);
            this.tbButtonLabel.TabIndex = 46;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(272, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 20);
            this.label10.TabIndex = 51;
            this.label10.Text = "Width";
            // 
            // cbButtonConfirm
            // 
            this.cbButtonConfirm.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbButtonConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbButtonConfirm.Location = new System.Drawing.Point(447, 1);
            this.cbButtonConfirm.Name = "cbButtonConfirm";
            this.cbButtonConfirm.Size = new System.Drawing.Size(75, 58);
            this.cbButtonConfirm.TabIndex = 48;
            this.cbButtonConfirm.Text = "Confirm Popup";
            this.cbButtonConfirm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.lblButtonColor.Location = new System.Drawing.Point(209, 5);
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
            this.cmbRemoteID.Location = new System.Drawing.Point(110, 6);
            this.cmbRemoteID.Name = "cmbRemoteID";
            this.cmbRemoteID.Size = new System.Drawing.Size(147, 28);
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
            this.btnDeleteRemote.Location = new System.Drawing.Point(100, 40);
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
            this.label7.Location = new System.Drawing.Point(12, 81);
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
            this.cmbAddItem.Location = new System.Drawing.Point(12, 104);
            this.cmbAddItem.Name = "cmbAddItem";
            this.cmbAddItem.Size = new System.Drawing.Size(140, 28);
            this.cmbAddItem.TabIndex = 44;
            this.cmbAddItem.SelectedIndexChanged += new System.EventHandler(this.cmbAddItem_SelectedIndexChanged);
            // 
            // panelGroup
            // 
            this.panelGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGroup.Controls.Add(this.pnlGroupColor);
            this.panelGroup.Controls.Add(this.label11);
            this.panelGroup.Controls.Add(this.btnSaveGroup);
            this.panelGroup.Controls.Add(this.btnDeleteGroup);
            this.panelGroup.Controls.Add(this.tbGroupLabel);
            this.panelGroup.Controls.Add(this.btnAddGroup);
            this.panelGroup.Controls.Add(this.label6);
            this.panelGroup.Location = new System.Drawing.Point(175, 65);
            this.panelGroup.Name = "panelGroup";
            this.panelGroup.Size = new System.Drawing.Size(428, 65);
            this.panelGroup.TabIndex = 45;
            this.panelGroup.Visible = false;
            // 
            // pnlGroupColor
            // 
            this.pnlGroupColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlGroupColor.Location = new System.Drawing.Point(213, 28);
            this.pnlGroupColor.Name = "pnlGroupColor";
            this.pnlGroupColor.Size = new System.Drawing.Size(57, 27);
            this.pnlGroupColor.TabIndex = 60;
            this.pnlGroupColor.Click += new System.EventHandler(this.pnlGroupColor_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(209, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 20);
            this.label11.TabIndex = 59;
            this.label11.Text = "Color";
            // 
            // btnSaveGroup
            // 
            this.btnSaveGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveGroup.Location = new System.Drawing.Point(276, 27);
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
            this.btnDeleteGroup.Location = new System.Drawing.Point(348, 27);
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
            this.tbGroupLabel.Size = new System.Drawing.Size(200, 26);
            this.tbGroupLabel.TabIndex = 54;
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddGroup.Location = new System.Drawing.Point(276, 27);
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
            this.panelBlank.Location = new System.Drawing.Point(175, 65);
            this.panelBlank.Name = "panelBlank";
            this.panelBlank.Size = new System.Drawing.Size(365, 65);
            this.panelBlank.TabIndex = 46;
            this.panelBlank.Visible = false;
            // 
            // btnSaveBlank
            // 
            this.btnSaveBlank.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveBlank.Location = new System.Drawing.Point(213, 27);
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
            this.btnDeleteBlank.Location = new System.Drawing.Point(285, 27);
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
            this.btnAddBlank.Location = new System.Drawing.Point(213, 27);
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
            this.tbBlankSize.Size = new System.Drawing.Size(200, 26);
            this.tbBlankSize.TabIndex = 57;
            this.tbBlankSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumOnly_KeyPress);
            // 
            // panelNewRow
            // 
            this.panelNewRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNewRow.Controls.Add(this.btnDeleteNewRow);
            this.panelNewRow.Controls.Add(this.btnAddNewRow);
            this.panelNewRow.Location = new System.Drawing.Point(175, 65);
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
            // btnSaveRemote
            // 
            this.btnSaveRemote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveRemote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveRemote.Location = new System.Drawing.Point(857, 17);
            this.btnSaveRemote.Name = "btnSaveRemote";
            this.btnSaveRemote.Size = new System.Drawing.Size(60, 28);
            this.btnSaveRemote.TabIndex = 50;
            this.btnSaveRemote.Text = "Save";
            this.btnSaveRemote.UseVisualStyleBackColor = true;
            this.btnSaveRemote.Click += new System.EventHandler(this.btnRemoteSave_Click);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(738, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 40);
            this.label15.TabIndex = 49;
            this.label15.Text = "Button Height";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbGlobalButtonHeight
            // 
            this.tbGlobalButtonHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGlobalButtonHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGlobalButtonHeight.Location = new System.Drawing.Point(809, 18);
            this.tbGlobalButtonHeight.Name = "tbGlobalButtonHeight";
            this.tbGlobalButtonHeight.Size = new System.Drawing.Size(40, 26);
            this.tbGlobalButtonHeight.TabIndex = 48;
            this.tbGlobalButtonHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumOnly_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(504, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 15);
            this.label2.TabIndex = 51;
            this.label2.Text = "Buttons are just for show and wont actually send commands";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(350, 16);
            this.label3.TabIndex = 52;
            this.label3.Text = "Double-click a button row to Add / Edit commands";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(312, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 30);
            this.label5.TabIndex = 54;
            this.label5.Text = "Name:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbRemoteName
            // 
            this.tbRemoteName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRemoteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRemoteName.Location = new System.Drawing.Point(387, 3);
            this.tbRemoteName.Name = "tbRemoteName";
            this.tbRemoteName.Size = new System.Drawing.Size(122, 26);
            this.tbRemoteName.TabIndex = 53;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(516, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 40);
            this.label8.TabIndex = 55;
            this.label8.Text = "Back Color";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(608, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 40);
            this.label9.TabIndex = 56;
            this.label9.Text = "Shading Strength";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlBackColor
            // 
            this.pnlBackColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBackColor.Location = new System.Drawing.Point(574, 20);
            this.pnlBackColor.Name = "pnlBackColor";
            this.pnlBackColor.Size = new System.Drawing.Size(24, 24);
            this.pnlBackColor.TabIndex = 57;
            this.pnlBackColor.Click += new System.EventHandler(this.pnlBackColor_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Location = new System.Drawing.Point(369, 136);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(89, 29);
            this.btnCopy.TabIndex = 60;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // cbHideRemote
            // 
            this.cbHideRemote.AutoSize = true;
            this.cbHideRemote.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbHideRemote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHideRemote.Location = new System.Drawing.Point(263, 10);
            this.cbHideRemote.Name = "cbHideRemote";
            this.cbHideRemote.Size = new System.Drawing.Size(50, 38);
            this.cbHideRemote.TabIndex = 56;
            this.cbHideRemote.Text = "Hide";
            this.cbHideRemote.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbHideRemote.UseVisualStyleBackColor = true;
            // 
            // tbShadingStrength
            // 
            this.tbShadingStrength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbShadingStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbShadingStrength.Location = new System.Drawing.Point(694, 19);
            this.tbShadingStrength.Name = "tbShadingStrength";
            this.tbShadingStrength.Size = new System.Drawing.Size(40, 26);
            this.tbShadingStrength.TabIndex = 61;
            this.tbShadingStrength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumOnly_KeyPress);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(9, 819);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(272, 16);
            this.label12.TabIndex = 62;
            this.label12.Text = "Ctrl / Shift click to select multiple items";
            // 
            // lblClearCopy
            // 
            this.lblClearCopy.AutoSize = true;
            this.lblClearCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearCopy.ForeColor = System.Drawing.Color.Red;
            this.lblClearCopy.Location = new System.Drawing.Point(270, 133);
            this.lblClearCopy.Name = "lblClearCopy";
            this.lblClearCopy.Size = new System.Drawing.Size(95, 16);
            this.lblClearCopy.TabIndex = 63;
            this.lblClearCopy.Text = "[Clear Copy]";
            this.lblClearCopy.Visible = false;
            this.lblClearCopy.Click += new System.EventHandler(this.lblClearCopy_Click);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(458, 346);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 17);
            this.label17.TabIndex = 65;
            this.label17.Text = "PgUp";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(458, 435);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 17);
            this.label18.TabIndex = 66;
            this.label18.Text = "PgDn";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnReorderRemotes
            // 
            this.btnReorderRemotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReorderRemotes.Location = new System.Drawing.Point(12, 40);
            this.btnReorderRemotes.Name = "btnReorderRemotes";
            this.btnReorderRemotes.Size = new System.Drawing.Size(82, 28);
            this.btnReorderRemotes.TabIndex = 67;
            this.btnReorderRemotes.Text = "Reorder";
            this.btnReorderRemotes.UseVisualStyleBackColor = true;
            this.btnReorderRemotes.Click += new System.EventHandler(this.btnReorderRemotes_Click);
            // 
            // btnDeleteItems
            // 
            this.btnDeleteItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteItems.Location = new System.Drawing.Point(291, 817);
            this.btnDeleteItems.Name = "btnDeleteItems";
            this.btnDeleteItems.Size = new System.Drawing.Size(70, 25);
            this.btnDeleteItems.TabIndex = 68;
            this.btnDeleteItems.Text = "Delete";
            this.btnDeleteItems.UseVisualStyleBackColor = true;
            this.btnDeleteItems.Click += new System.EventHandler(this.btnDeleteItems_Click);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(366, 819);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 16);
            this.label16.TabIndex = 69;
            this.label16.Text = "(Delete Key)";
            // 
            // tbRemoteGroup
            // 
            this.tbRemoteGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRemoteGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRemoteGroup.Location = new System.Drawing.Point(387, 33);
            this.tbRemoteGroup.Name = "tbRemoteGroup";
            this.tbRemoteGroup.Size = new System.Drawing.Size(122, 26);
            this.tbRemoteGroup.TabIndex = 70;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(312, 31);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 28);
            this.label19.TabIndex = 71;
            this.label19.Text = "Group:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RemoteEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 844);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.tbRemoteGroup);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnDeleteItems);
            this.Controls.Add(this.btnReorderRemotes);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblClearCopy);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbShadingStrength);
            this.Controls.Add(this.cbHideRemote);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.pnlBackColor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbRemoteName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSaveRemote);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbGlobalButtonHeight);
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
            this.KeyPreview = true;
            this.Name = "RemoteEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remote Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RemoteEditor_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RemoteEditor_KeyDown);
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
        private System.Windows.Forms.Button btnSaveRemote;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbGlobalButtonHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbRemoteName;
        private System.Windows.Forms.LinkLabel btnSizeHelp;
        private System.Windows.Forms.LinkLabel btnLabelTricks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlBackColor;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.CheckBox cbHideRemote;
        private System.Windows.Forms.Panel pnlButtonColor;
        private System.Windows.Forms.Panel pnlGroupColor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbShadingStrength;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbButtonHeight;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox cbHoldable;
        private System.Windows.Forms.Label lblClearCopy;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnReorderRemotes;
        private System.Windows.Forms.Button btnDeleteItems;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbRemoteGroup;
        private System.Windows.Forms.Label label19;
    }
}