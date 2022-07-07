using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobApplicationSystem
{
    public partial class staff : Form
    {
        public staff()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            staff frm = new JobApplicationSystem.staff();
            frm.ShowDialog();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            employers frm = new JobApplicationSystem.employers();
            frm.ShowDialog();
            this.Close();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            jobs frm = new JobApplicationSystem.jobs();
            frm.ShowDialog();
            this.Close();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            staff frm = new JobApplicationSystem.staff();
            frm.ShowDialog();
            this.Close();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Logout successfuly!");
            this.Hide();
            JobApplication frm = new JobApplicationSystem.JobApplication();
            frm.ShowDialog();
            this.Close();
        }
    }
}
