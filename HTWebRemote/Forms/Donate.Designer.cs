namespace HTWebRemote.Forms
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
            this.components = new System.ComponentModel.Container();
            this.lblMsg = new System.Windows.Forms.Label();
            this.linkEmail = new System.Windows.Forms.LinkLabel();
            this.pbDonateQR = new System.Windows.Forms.PictureBox();
            this.pbDonateLink = new System.Windows.Forms.PictureBox();
            this.toolTipEmail = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbDonateQR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDonateLink)).BeginInit();
            this.SuspendLayout();
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
            // pbDonateQR
            // 
            this.pbDonateQR.Image = global::HTWebRemote.Properties.Resources.QR_Code;
            this.pbDonateQR.Location = new System.Drawing.Point(337, 177);
            this.pbDonateQR.Name = "pbDonateQR";
            this.pbDonateQR.Size = new System.Drawing.Size(131, 133);
            this.pbDonateQR.TabIndex = 3;
            this.pbDonateQR.TabStop = false;
            // 
            // pbDonateLink
            // 
            this.pbDonateLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDonateLink.Image = global::HTWebRemote.Properties.Resources.button_PayPal_donate;
            this.pbDonateLink.Location = new System.Drawing.Point(0, 165);
            this.pbDonateLink.Name = "pbDonateLink";
            this.pbDonateLink.Size = new System.Drawing.Size(334, 155);
            this.pbDonateLink.TabIndex = 0;
            this.pbDonateLink.TabStop = false;
            this.pbDonateLink.Click += new System.EventHandler(this.pbDonateLink_Click);
            // 
            // Donate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 328);
            this.Controls.Add(this.pbDonateQR);
            this.Controls.Add(this.linkEmail);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.pbDonateLink);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Donate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Donate to HTWebRemote";
            ((System.ComponentModel.ISupportInitialize)(this.pbDonateQR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDonateLink)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbDonateLink;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.LinkLabel linkEmail;
        private System.Windows.Forms.PictureBox pbDonateQR;
        private System.Windows.Forms.ToolTip toolTipEmail;
    }
}