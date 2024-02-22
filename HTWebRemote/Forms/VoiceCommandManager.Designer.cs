
namespace HTWebRemote.Forms
{
    partial class VoiceCommandManager
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbVoiceCommands = new System.Windows.Forms.ListBox();
            this.tbPhrase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbConfidence = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.cbxTestMode = new System.Windows.Forms.CheckBox();
            this.recognizerBrokeTimer = new System.Windows.Forms.Timer(this.components);
            this.cbxLogMatches = new System.Windows.Forms.CheckBox();
            this.cbxAutoReload = new System.Windows.Forms.CheckBox();
            this.autoReloadTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(317, 16);
            this.label3.TabIndex = 56;
            this.label3.Text = "Double-click an item to Add / Edit commands";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(332, 44);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(77, 47);
            this.btnAdd.TabIndex = 55;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbVoiceCommands
            // 
            this.lbVoiceCommands.AllowDrop = true;
            this.lbVoiceCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVoiceCommands.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVoiceCommands.FormattingEnabled = true;
            this.lbVoiceCommands.ItemHeight = 20;
            this.lbVoiceCommands.Location = new System.Drawing.Point(12, 97);
            this.lbVoiceCommands.Name = "lbVoiceCommands";
            this.lbVoiceCommands.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbVoiceCommands.Size = new System.Drawing.Size(484, 304);
            this.lbVoiceCommands.TabIndex = 57;
            this.lbVoiceCommands.SelectedIndexChanged += new System.EventHandler(this.lbVoiceCommands_SelectedIndexChanged);
            this.lbVoiceCommands.DoubleClick += new System.EventHandler(this.lbVoiceCommands_DoubleClick);
            // 
            // tbPhrase
            // 
            this.tbPhrase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPhrase.Location = new System.Drawing.Point(105, 12);
            this.tbPhrase.Name = "tbPhrase";
            this.tbPhrase.Size = new System.Drawing.Size(392, 26);
            this.tbPhrase.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 59;
            this.label1.Text = "Phrase:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 60;
            this.label2.Text = "Confidence:";
            // 
            // tbConfidence
            // 
            this.tbConfidence.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConfidence.Location = new System.Drawing.Point(105, 44);
            this.tbConfidence.Name = "tbConfidence";
            this.tbConfidence.Size = new System.Drawing.Size(31, 26);
            this.tbConfidence.TabIndex = 61;
            this.tbConfidence.Text = "80";
            this.tbConfidence.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbConfidence_KeyPress);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(415, 44);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(82, 47);
            this.btnRemove.TabIndex = 62;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // cbxTestMode
            // 
            this.cbxTestMode.AutoSize = true;
            this.cbxTestMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTestMode.Location = new System.Drawing.Point(12, 407);
            this.cbxTestMode.Name = "cbxTestMode";
            this.cbxTestMode.Size = new System.Drawing.Size(112, 24);
            this.cbxTestMode.TabIndex = 63;
            this.cbxTestMode.Text = "Test Mode";
            this.cbxTestMode.UseVisualStyleBackColor = true;
            this.cbxTestMode.CheckedChanged += new System.EventHandler(this.cbxTestMode_CheckedChanged);
            // 
            // recognizerBrokeTimer
            // 
            this.recognizerBrokeTimer.Interval = 60000;
            this.recognizerBrokeTimer.Tick += new System.EventHandler(this.recognizerBrokeTimer_Tick);
            // 
            // cbxLogMatches
            // 
            this.cbxLogMatches.AutoSize = true;
            this.cbxLogMatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxLogMatches.Location = new System.Drawing.Point(365, 407);
            this.cbxLogMatches.Name = "cbxLogMatches";
            this.cbxLogMatches.Size = new System.Drawing.Size(131, 24);
            this.cbxLogMatches.TabIndex = 64;
            this.cbxLogMatches.Text = "Log Matches";
            this.cbxLogMatches.UseVisualStyleBackColor = true;
            this.cbxLogMatches.CheckedChanged += new System.EventHandler(this.cbxLogMatches_CheckedChanged);
            // 
            // cbxAutoReload
            // 
            this.cbxAutoReload.AutoSize = true;
            this.cbxAutoReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxAutoReload.Location = new System.Drawing.Point(177, 407);
            this.cbxAutoReload.Name = "cbxAutoReload";
            this.cbxAutoReload.Size = new System.Drawing.Size(133, 24);
            this.cbxAutoReload.TabIndex = 65;
            this.cbxAutoReload.Text = "Auto Reload ";
            this.cbxAutoReload.UseVisualStyleBackColor = true;
            this.cbxAutoReload.Click += new System.EventHandler(this.cbxAutoReload_Click);
            // 
            // autoReloadTimer
            // 
            this.autoReloadTimer.Interval = 300000;
            this.autoReloadTimer.Tick += new System.EventHandler(this.autoReloadTimer_Tick);
            // 
            // VoiceCommandManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 439);
            this.Controls.Add(this.cbxAutoReload);
            this.Controls.Add(this.cbxLogMatches);
            this.Controls.Add(this.cbxTestMode);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.tbConfidence);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPhrase);
            this.Controls.Add(this.lbVoiceCommands);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VoiceCommandManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voice Command Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VoiceCommandManager_FormClosing);
            this.Shown += new System.EventHandler(this.VoiceCommandManager_Shown);
            this.Click += new System.EventHandler(this.VoiceCommandManager_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lbVoiceCommands;
        private System.Windows.Forms.TextBox tbPhrase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbConfidence;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.CheckBox cbxTestMode;
        private System.Windows.Forms.Timer recognizerBrokeTimer;
        private System.Windows.Forms.CheckBox cbxLogMatches;
        private System.Windows.Forms.CheckBox cbxAutoReload;
        private System.Windows.Forms.Timer autoReloadTimer;
    }
}