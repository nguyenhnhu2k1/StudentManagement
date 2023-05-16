using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult re = MessageBox.Show("Ban co muon thoat khong",
                                               "Exit",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Warning);
            if (re == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else e.Cancel = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
                lblOutput.Font = new Font(lblOutput.Font, lblOutput.Font.Style ^ FontStyle.Bold);
        }

        private void lblOutput_Click(object sender, EventArgs e)
        {
            

        }

        private void radRed_CheckedChanged(object sender, EventArgs e)
        {
            if (radRed.Checked)
            {
                lblOutput.ForeColor = radRed.ForeColor;
            }
        }

        private void radGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (radGreen.Checked)
            {
                lblOutput.ForeColor = radGreen.ForeColor;
            }
        }

        private void radBlack_CheckedChanged(object sender, EventArgs e)
        {
            if (radBlack.Checked)
            {
                lblOutput.ForeColor = radBlack.ForeColor;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            lblOutput.Text = txtInput.Text;
        }

        private void chkNghien_CheckedChanged(object sender, EventArgs e)
        {
                lblOutput.Font = new Font(lblOutput.Font, lblOutput.Font.Style ^ FontStyle.Italic);
        }

        private void chkGach_CheckedChanged(object sender, EventArgs e)
        {
                lblOutput.Font = new Font(lblOutput.Font, lblOutput.Font.Style ^ FontStyle.Underline);
        }
    }
}
