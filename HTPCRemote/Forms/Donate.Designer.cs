namespace HTPCRemote.Forms
{
    partial class Donate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Donate));
            this.pbDonateLink = new System.Windows.Forms.PictureBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.linkEmail = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbDonateLink)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDonateLink
            // 
            this.pbDonateLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDonateLink.Image = global::HTPCRemote.Properties.Resources.button_PayPal_donate;
            this.pbDonateLink.Location = new System.Drawing.Point(64, 165);
            this.pbDonateLink.Name = "pbDonateLink";
            this.pbDonateLink.Size = new System.Drawing.Size(334, 155);
            this.pbDonateLink.TabIndex = 0;
            this.pbDonateLink.TabStop = false;
            this.pbDonateLink.Click += new System.EventHandler(this.pbDonateLink_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(15, 9);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(440, 153);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "Thank You";
            // 
            // linkEmail
            // 
            this.linkEmail.AutoSize = true;
            this.linkEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkEmail.Location = new System.Drawing.Point(399, 137);
            this.linkEmail.Name = "linkEmail";
            this.linkEmail.Size = new System.Drawing.Size(52, 16);
            this.linkEmail.TabIndex = 2;
            this.linkEmail.TabStop = true;
            this.linkEmail.Text = "E-mail";
            this.linkEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEmail_LinkClicked);
            // 
            // Donate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 332);
            this.Controls.Add(this.linkEmail);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.pbDonateLink);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Donate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Donate to HTPCRemote";
            ((System.ComponentModel.ISupportInitialize)(this.pbDonateLink)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbDonateLink;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.LinkLabel linkEmail;
    }
}