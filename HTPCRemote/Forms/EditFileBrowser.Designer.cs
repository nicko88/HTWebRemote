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
            this.btnAdd.Location = new System.Drawing.Point(484, 261);
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
            this.btnRemove.Location = new System.Drawing.Point(584, 261);
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
            this.cmbFileBrowserRemote.Location = new System.Drawing.Point(193, 262);
            this.cmbFileBrowserRemote.Name = "cmbFileBrowserRemote";
            this.cmbFileBrowserRemote.Size = new System.Drawing.Size(52, 28);
            this.cmbFileBrowserRemote.TabIndex = 4;
            this.cmbFileBrowserRemote.SelectedIndexChanged += new System.EventHandler(this.cmbFileBrowserRemote_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "File Browser Remote:";
            // 
            // cbShowFileBrowser
            // 
            this.cbShowFileBrowser.AutoSize = true;
            this.cbShowFileBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShowFileBrowser.Location = new System.Drawing.Point(262, 265);
            this.cbShowFileBrowser.Name = "cbShowFileBrowser";
            this.cbShowFileBrowser.Size = new System.Drawing.Size(211, 24);
            this.cbShowFileBrowser.TabIndex = 6;
            this.cbShowFileBrowser.Text = "Show File Browser Tab";
            this.cbShowFileBrowser.UseVisualStyleBackColor = true;
            this.cbShowFileBrowser.CheckedChanged += new System.EventHandler(this.cbShowFileBrowser_CheckedChanged);
            // 
            // EditFileBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 296);
            this.Controls.Add(this.lbPaths);
            this.Controls.Add(this.cbShowFileBrowser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFileBrowserRemote);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditFileBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Browser Settings";
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
    }
}