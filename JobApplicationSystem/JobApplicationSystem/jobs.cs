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
    public partial class jobs : Form
    {
        public jobs()
        {
            InitializeComponent();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Logout successfuly!");
            this.Hide();
            JobApplication frm = new JobApplicationSystem.JobApplication();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            applicants frm = new JobApplicationSystem.applicants();
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

      
        public void Display()
        {
            dbConnect.DisplayAndSearchJob("SELECT ID,Title,Company_Name,Location,Job_Type,Salary,Start_Date,Employer,Description,Created_at FROM job", dataGridView);
        }
        private void jobs_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Are you sure you want to delete this job post?", "Delete Job", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    dbConnect.DeleteJob(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }
                return;


            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dbConnect.DisplayAndSearchJob("SELECT ID,Title,Company_Name,Location,Job_Type,Salary,Start_Date,Employer,Description,Created_at FROM job WHERE Title LIKE '%" + txtSearch.Text + "%' or Company_Name LIKE '%" + txtSearch.Text + "%' or Job_Type LIKE '%" + txtSearch.Text + "%' or Location LIKE '%" + txtSearch.Text + "%' ", dataGridView);
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            admin frm = new JobApplicationSystem.admin();
            frm.ShowDialog();
            this.Close();
        }
    }
}
