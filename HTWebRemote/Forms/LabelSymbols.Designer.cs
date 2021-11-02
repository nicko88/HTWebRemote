namespace HTWebRemote.Forms
{
    partial class LabelSymbols
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabelSymbols));
            this.lblSymbolsPage = new System.Windows.Forms.LinkLabel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSymbolsPage
            // 
            this.lblSymbolsPage.AutoSize = true;
            this.lblSymbolsPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSymbolsPage.Location = new System.Drawing.Point(12, 313);
            this.lblSymbolsPage.Name = "lblSymbolsPage";
            this.lblSymbolsPage.Size = new System.Drawing.Size(80, 16);
            this.lblSymbolsPage.TabIndex = 0;
            this.lblSymbolsPage.TabStop = true;
            this.lblSymbolsPage.Text = "Click Here";
            this.lblSymbolsPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSymbolsPage_LinkClicked);
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(12, 9);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(445, 335);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "Explanation";
            // 
            // LabelSymbols
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 351);
            this.Controls.Add(this.lblSymbolsPage);
            this.Controls.Add(this.lblMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LabelSymbols";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Label Symbols";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblSymbolsPage;
        private System.Windows.Forms.Label lblMsg;
    }
}