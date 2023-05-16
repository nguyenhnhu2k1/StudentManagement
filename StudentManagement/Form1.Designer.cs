namespace StudentManagement
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
            this.lblInput = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.grbColor = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.txtThoat = new System.Windows.Forms.Button();
            this.txtHienThi = new System.Windows.Forms.Label();
            this.radRed = new System.Windows.Forms.RadioButton();
            this.radGreen = new System.Windows.Forms.RadioButton();
            this.radBlack = new System.Windows.Forms.RadioButton();
            this.chkdam = new System.Windows.Forms.CheckBox();
            this.chkNghien = new System.Windows.Forms.CheckBox();
            this.chkGach = new System.Windows.Forms.CheckBox();
            this.grbColor.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInput
            // 
            this.lblInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblInput.Location = new System.Drawing.Point(49, 26);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(80, 20);
            this.lblInput.TabIndex = 0;
            this.lblInput.Text = "Input:";
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtInput.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtInput.Location = new System.Drawing.Point(186, 26);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(257, 27);
            this.txtInput.TabIndex = 1;
            this.txtInput.Text = "như";
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // grbColor
            // 
            this.grbColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grbColor.Controls.Add(this.radBlack);
            this.grbColor.Controls.Add(this.radGreen);
            this.grbColor.Controls.Add(this.radRed);
            this.grbColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grbColor.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.grbColor.Location = new System.Drawing.Point(35, 78);
            this.grbColor.Name = "grbColor";
            this.grbColor.Size = new System.Drawing.Size(155, 164);
            this.grbColor.TabIndex = 2;
            this.grbColor.TabStop = false;
            this.grbColor.Text = "Color";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.chkGach);
            this.groupBox2.Controls.Add(this.chkNghien);
            this.groupBox2.Controls.Add(this.chkdam);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(288, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(155, 164);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Font";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lblOutput
            // 
            this.lblOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.ForeColor = System.Drawing.Color.Blue;
            this.lblOutput.Location = new System.Drawing.Point(123, 274);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(203, 32);
            this.lblOutput.TabIndex = 5;
            this.lblOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOutput.Click += new System.EventHandler(this.lblOutput_Click);
            // 
            // txtThoat
            // 
            this.txtThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThoat.Location = new System.Drawing.Point(360, 274);
            this.txtThoat.Name = "txtThoat";
            this.txtThoat.Size = new System.Drawing.Size(105, 32);
            this.txtThoat.TabIndex = 4;
            this.txtThoat.Text = "Thoát";
            this.txtThoat.UseVisualStyleBackColor = true;
            // 
            // txtHienThi
            // 
            this.txtHienThi.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHienThi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtHienThi.Location = new System.Drawing.Point(49, 281);
            this.txtHienThi.Name = "txtHienThi";
            this.txtHienThi.Size = new System.Drawing.Size(80, 20);
            this.txtHienThi.TabIndex = 0;
            this.txtHienThi.Text = "Hiển Thị:";
            // 
            // radRed
            // 
            this.radRed.AutoSize = true;
            this.radRed.ForeColor = System.Drawing.Color.Red;
            this.radRed.Location = new System.Drawing.Point(10, 36);
            this.radRed.Name = "radRed";
            this.radRed.Size = new System.Drawing.Size(96, 29);
            this.radRed.TabIndex = 0;
            this.radRed.TabStop = true;
            this.radRed.Text = "Màu đỏ";
            this.radRed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radRed.UseVisualStyleBackColor = true;
            this.radRed.CheckedChanged += new System.EventHandler(this.radRed_CheckedChanged);
            // 
            // radGreen
            // 
            this.radGreen.AutoSize = true;
            this.radGreen.ForeColor = System.Drawing.Color.Lime;
            this.radGreen.Location = new System.Drawing.Point(9, 71);
            this.radGreen.Name = "radGreen";
            this.radGreen.Size = new System.Drawing.Size(137, 29);
            this.radGreen.TabIndex = 0;
            this.radGreen.TabStop = true;
            this.radGreen.Text = "Màu xanh lá";
            this.radGreen.UseVisualStyleBackColor = true;
            this.radGreen.CheckedChanged += new System.EventHandler(this.radGreen_CheckedChanged);
            // 
            // radBlack
            // 
            this.radBlack.AutoSize = true;
            this.radBlack.ForeColor = System.Drawing.Color.Black;
            this.radBlack.Location = new System.Drawing.Point(9, 106);
            this.radBlack.Name = "radBlack";
            this.radBlack.Size = new System.Drawing.Size(107, 29);
            this.radBlack.TabIndex = 0;
            this.radBlack.TabStop = true;
            this.radBlack.Text = "Màu đen";
            this.radBlack.UseVisualStyleBackColor = true;
            this.radBlack.CheckedChanged += new System.EventHandler(this.radBlack_CheckedChanged);
            // 
            // chkdam
            // 
            this.chkdam.AutoSize = true;
            this.chkdam.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkdam.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkdam.Location = new System.Drawing.Point(12, 37);
            this.chkdam.Name = "chkdam";
            this.chkdam.Size = new System.Drawing.Size(96, 29);
            this.chkdam.TabIndex = 0;
            this.chkdam.Text = "In đậm";
            this.chkdam.UseVisualStyleBackColor = true;
            this.chkdam.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkNghien
            // 
            this.chkNghien.AutoSize = true;
            this.chkNghien.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkNghien.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkNghien.Location = new System.Drawing.Point(12, 71);
            this.chkNghien.Name = "chkNghien";
            this.chkNghien.Size = new System.Drawing.Size(122, 29);
            this.chkNghien.TabIndex = 0;
            this.chkNghien.Text = "In nghiêng";
            this.chkNghien.UseVisualStyleBackColor = true;
            this.chkNghien.CheckedChanged += new System.EventHandler(this.chkNghien_CheckedChanged);
            // 
            // chkGach
            // 
            this.chkGach.AutoSize = true;
            this.chkGach.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkGach.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkGach.Location = new System.Drawing.Point(12, 106);
            this.chkGach.Name = "chkGach";
            this.chkGach.Size = new System.Drawing.Size(126, 29);
            this.chkGach.TabIndex = 0;
            this.chkGach.Text = "Gạch chân";
            this.chkGach.UseVisualStyleBackColor = true;
            this.chkGach.CheckedChanged += new System.EventHandler(this.chkGach_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 339);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.txtThoat);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbColor);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtHienThi);
            this.Controls.Add(this.lblInput);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.grbColor.ResumeLayout(false);
            this.grbColor.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.GroupBox grbColor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Button txtThoat;
        private System.Windows.Forms.Label txtHienThi;
        private System.Windows.Forms.RadioButton radBlack;
        private System.Windows.Forms.RadioButton radGreen;
        private System.Windows.Forms.RadioButton radRed;
        private System.Windows.Forms.CheckBox chkGach;
        private System.Windows.Forms.CheckBox chkNghien;
        private System.Windows.Forms.CheckBox chkdam;
    }
}

