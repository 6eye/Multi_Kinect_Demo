namespace Multi_Kinect_Sample
{
    partial class mainForm
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
            this.kinectPB1 = new System.Windows.Forms.PictureBox();
            this.kinectPB2 = new System.Windows.Forms.PictureBox();
            this.kinectPB4 = new System.Windows.Forms.PictureBox();
            this.kinectPB3 = new System.Windows.Forms.PictureBox();
            this.createdByLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.kinectPB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kinectPB2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kinectPB4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kinectPB3)).BeginInit();
            this.SuspendLayout();
            // 
            // kinectPB1
            // 
            this.kinectPB1.Location = new System.Drawing.Point(12, 12);
            this.kinectPB1.Name = "kinectPB1";
            this.kinectPB1.Size = new System.Drawing.Size(300, 200);
            this.kinectPB1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.kinectPB1.TabIndex = 0;
            this.kinectPB1.TabStop = false;
            // 
            // kinectPB2
            // 
            this.kinectPB2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kinectPB2.Location = new System.Drawing.Point(312, 12);
            this.kinectPB2.Name = "kinectPB2";
            this.kinectPB2.Size = new System.Drawing.Size(300, 200);
            this.kinectPB2.TabIndex = 1;
            this.kinectPB2.TabStop = false;
            // 
            // kinectPB4
            // 
            this.kinectPB4.Location = new System.Drawing.Point(312, 229);
            this.kinectPB4.Name = "kinectPB4";
            this.kinectPB4.Size = new System.Drawing.Size(300, 200);
            this.kinectPB4.TabIndex = 3;
            this.kinectPB4.TabStop = false;
            // 
            // kinectPB3
            // 
            this.kinectPB3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kinectPB3.Location = new System.Drawing.Point(12, 229);
            this.kinectPB3.Name = "kinectPB3";
            this.kinectPB3.Size = new System.Drawing.Size(300, 200);
            this.kinectPB3.TabIndex = 2;
            this.kinectPB3.TabStop = false;
            // 
            // createdByLabel
            // 
            this.createdByLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.createdByLabel.AutoSize = true;
            this.createdByLabel.Location = new System.Drawing.Point(242, 215);
            this.createdByLabel.Name = "createdByLabel";
            this.createdByLabel.Size = new System.Drawing.Size(141, 13);
            this.createdByLabel.TabIndex = 4;
            this.createdByLabel.Text = "Created by: Gerald McAlister";
            this.createdByLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.createdByLabel);
            this.Controls.Add(this.kinectPB4);
            this.Controls.Add(this.kinectPB3);
            this.Controls.Add(this.kinectPB2);
            this.Controls.Add(this.kinectPB1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "Multi Kinect Demo";
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kinectPB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kinectPB2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kinectPB4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kinectPB3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox kinectPB1;
        private System.Windows.Forms.PictureBox kinectPB2;
        private System.Windows.Forms.PictureBox kinectPB4;
        private System.Windows.Forms.PictureBox kinectPB3;
        private System.Windows.Forms.Label createdByLabel;
    }
}

