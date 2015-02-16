namespace ThapHanoi_Service
{
    partial class Form1
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
            this.btnServer = new System.Windows.Forms.Button();
            this.labelThongTin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnServer
            // 
            this.btnServer.Location = new System.Drawing.Point(327, 236);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(145, 44);
            this.btnServer.TabIndex = 0;
            this.btnServer.Text = "Start Server";
            this.btnServer.UseVisualStyleBackColor = true;
            this.btnServer.Click += new System.EventHandler(this.btnServer_Click);
            // 
            // labelThongTin
            // 
            this.labelThongTin.AutoSize = true;
            this.labelThongTin.Location = new System.Drawing.Point(354, 125);
            this.labelThongTin.Name = "labelThongTin";
            this.labelThongTin.Size = new System.Drawing.Size(35, 13);
            this.labelThongTin.TabIndex = 1;
            this.labelThongTin.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 351);
            this.Controls.Add(this.labelThongTin);
            this.Controls.Add(this.btnServer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnServer;
        private System.Windows.Forms.Label labelThongTin;
    }
}

