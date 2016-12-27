namespace AVConnectorProject
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
            this.buttonStartSolid = new System.Windows.Forms.Button();
            this.buttonBuildDetail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStartSolid
            // 
            this.buttonStartSolid.Location = new System.Drawing.Point(44, 47);
            this.buttonStartSolid.Name = "buttonStartSolid";
            this.buttonStartSolid.Size = new System.Drawing.Size(75, 23);
            this.buttonStartSolid.TabIndex = 0;
            this.buttonStartSolid.Text = "start";
            this.buttonStartSolid.UseVisualStyleBackColor = true;
            this.buttonStartSolid.Click += new System.EventHandler(this.buttonStartSolid_Click);
            // 
            // buttonBuildDetail
            // 
            this.buttonBuildDetail.Location = new System.Drawing.Point(44, 128);
            this.buttonBuildDetail.Name = "buttonBuildDetail";
            this.buttonBuildDetail.Size = new System.Drawing.Size(75, 23);
            this.buttonBuildDetail.TabIndex = 1;
            this.buttonBuildDetail.Text = "model";
            this.buttonBuildDetail.UseVisualStyleBackColor = true;
            this.buttonBuildDetail.Click += new System.EventHandler(this.buttonBuildDetail_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonBuildDetail);
            this.Controls.Add(this.buttonStartSolid);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStartSolid;
        private System.Windows.Forms.Button buttonBuildDetail;
    }
}