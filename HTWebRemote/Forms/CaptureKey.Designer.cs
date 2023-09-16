namespace HTWebRemote.Forms
{
    partial class CaptureKey
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
            this.lblKey = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblKey
            // 
            this.lblKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey.Location = new System.Drawing.Point(12, 14);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(229, 27);
            this.lblKey.TabIndex = 0;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(82, 54);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnAccept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CaptureKey_KeyDown);
            this.btnAccept.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CaptureKey_KeyUp);
            // 
            // CaptureKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 89);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CaptureKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Press Key Combo...";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CaptureKey_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CaptureKey_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Button btnAccept;
    }
}