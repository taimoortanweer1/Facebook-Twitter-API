using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace api_usage
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void tsmiNewSearch_Click(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch();

            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Maximized;
            frm.Text = "Facebook";
            frm.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ultraTabbedMdiManager1.MdiParent = this;
        }

        private void tsmiNewTWSearch_Click(object sender, EventArgs e)
        {
            FrmGooglePlus frm = new FrmGooglePlus();

            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Maximized;
            frm.Text = "Twitter";
            frm.Show();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            FrmLinkedIn frm = new FrmLinkedIn();

            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Maximized;
            frm.Text = "LinkedIn";
            frm.Show();
        }


        

       
    }
}
