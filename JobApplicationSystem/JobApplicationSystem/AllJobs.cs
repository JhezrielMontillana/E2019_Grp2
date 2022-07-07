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
    public partial class AllJobs : Form
    {
        string user;
        public AllJobs()
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

        private void AllJobs_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            main_employer frm = new JobApplicationSystem.main_employer();
            frm.ab(user.ToString());
            frm.ShowDialog();
            this.Close();
        }
        public void Display()
        {
            dbConnect.DisplayAndSearchJob("SELECT ID,Title,Company_Name,Location,Job_Type,Salary,Start_Date,Employer,Description,Created_at FROM job", dataGridView);
        }
        public void ab(string user_session)
        {
            user = user_session.ToString();
         
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dbConnect.DisplayAndSearchEmp("SELECT ID,Title,Company_Name,Location,Job_Type,Salary,Start_Date,Employer,Description,Created_at FROM job WHERE  Title LIKE '%" + txtSearch.Text + "%' AND Company_Name LIKE '%" + txtSearch.Text + "%' AND Job_Type LIKE '%" + txtSearch.Text + "%' AND Location LIKE '%" + txtSearch.Text + "%' ", dataGridView);

        }
        private void AllJobs_Shown(object sender, EventArgs e)
        {
            Display();
        }
    }
}
