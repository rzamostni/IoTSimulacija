namespace IoTPromet
{
    partial class LogForm
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
            this.clearButton = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.timerLogForme = new System.Windows.Forms.Timer(this.components);
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(27, 223);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(162, 29);
            this.clearButton.TabIndex = 11;
            this.clearButton.Text = "Očisti";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.button12_Click);
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(27, 23);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(406, 194);
            this.tbLog.TabIndex = 12;
            // 
            // timerLogForme
            // 
            this.timerLogForme.Tick += new System.EventHandler(this.timerLogForme_Tick);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(271, 223);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(162, 29);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Spremi u datoteku";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 464);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.clearButton);
            this.Name = "LogForm";
            this.Text = "LogForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Timer timerLogForme;
        private System.Windows.Forms.Button saveButton;
    }
}