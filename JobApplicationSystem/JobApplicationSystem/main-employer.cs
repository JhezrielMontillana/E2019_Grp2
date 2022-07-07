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
    
    public partial class main_employer : Form
    {
        view_job frm;
        view_applications afrm;
        string user;
        public main_employer()
        {
            InitializeComponent();
            frm = new view_job(this);
            afrm = new view_applications(this);
        }

        public void Display()
        {
            dbConnect.DisplayAndSearchJob("SELECT ID,Title,Company_Name,Location,Job_Type,Salary,Start_Date,Employer,Description,Created_at FROM job WHERE Employer='"+ user + "'" , dataGridView);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dbConnect.DisplayAndSearchEmp("SELECT ID,Title,Company_Name,Location,Job_Type,Salary,Start_Date,Employer,Description,Created_at FROM job WHERE Employer='" + user + "' AND Title LIKE '%" + txtSearch.Text + "%' AND Company_Name LIKE '%" + txtSearch.Text + "%' AND Job_Type LIKE '%" + txtSearch.Text + "%' AND Location LIKE '%" + txtSearch.Text + "%' ", dataGridView);

        }

        public void ab(string user_session)
        {
            user = user_session.ToString();
            //txtUser.Text = user.ToString();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Logout successfuly!");
            this.Hide();
            JobApplication frm = new JobApplicationSystem.JobApplication();
            frm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //view_job frm = new view_job(this);
            frm.Clear();
            frm.ab(user.ToString());
            frm.ShowDialog();
        }

        private void main_employer_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.ColumnIndex == 1)
            {
                afrm.Clear();
                afrm.id = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                afrm.ViewApplicants();
                afrm.ShowDialog();

            }


            if (e.ColumnIndex == 2)
            {
                frm.Clear();
                frm.id = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                frm.job_category = dataGridView.Rows[e.RowIndex].Cells[12].Value.ToString();
                frm.title = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                frm.company_name = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                frm.location = dataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                frm.job_type = dataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
                frm.salary = dataGridView.Rows[e.RowIndex].Cells[9].Value.ToString();
                frm.start_date = dataGridView.Rows[e.RowIndex].Cells[10].Value.ToString();
                frm.description = dataGridView.Rows[e.RowIndex].Cells[12].Value.ToString();

                frm.UpdateInfo();
                frm.ShowDialog();



            }
            if (e.ColumnIndex == 3)
            {
                if( MessageBox.Show("Once you delete your job post it will no longer be restored!","Delete Job", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)== DialogResult.Yes)
                {
                    dbConnect.DeleteJob(dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString());
                    Display();
                }
                return;


            }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            AllJobs frm = new JobApplicationSystem.AllJobs();
            frm.ab(user.ToString());
            frm.ShowDialog();
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void main_employer_Load(object sender, EventArgs e)
        {

        }
    }
}
