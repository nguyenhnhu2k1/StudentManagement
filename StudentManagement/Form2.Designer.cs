
namespace StudentManagement
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.chkMusic = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblcount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // pic2
            // 
            this.pic2.Image = ((System.Drawing.Image)(resources.GetObject("pic2.Image")));
            this.pic2.Location = new System.Drawing.Point(12, 54);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(425, 256);
            this.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic2.TabIndex = 0;
            this.pic2.TabStop = false;
            this.pic2.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pic1
            // 
            this.pic1.Image = ((System.Drawing.Image)(resources.GetObject("pic1.Image")));
            this.pic1.Location = new System.Drawing.Point(12, 54);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(425, 256);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 1;
            this.pic1.TabStop = false;
            this.pic1.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // chkMusic
            // 
            this.chkMusic.AutoSize = true;
            this.chkMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkMusic.Location = new System.Drawing.Point(12, 12);
            this.chkMusic.Name = "chkMusic";
            this.chkMusic.Size = new System.Drawing.Size(88, 30);
            this.chkMusic.TabIndex = 2;
            this.chkMusic.Text = "Music";
            this.chkMusic.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.Location = new System.Drawing.Point(106, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "Change Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblcount
            // 
            this.lblcount.BackColor = System.Drawing.Color.Salmon;
            this.lblcount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblcount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblcount.Location = new System.Drawing.Point(82, 337);
            this.lblcount.Name = "lblcount";
            this.lblcount.Size = new System.Drawing.Size(274, 41);
            this.lblcount.TabIndex = 4;
            this.lblcount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(456, 450);
            this.Controls.Add(this.lblcount);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkMusic);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.pic2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.CheckBox chkMusic;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblcount;
    }
}