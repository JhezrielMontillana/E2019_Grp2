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
    public partial class applicants : Form
    {
        view_applicants form;
   
        public applicants()
        {
            InitializeComponent();
            form = new view_applicants(this);
          
        }



        public void Display()
        {
            dbConnect.DisplayAndSearch("SELECT id,fname,mname,lname,username,password,dob,phone,email,street,city,province,postal,education,experience,last_employer,resume,valid_id,created_at FROM users", dataGridView);
         
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            applicants frm = new JobApplicationSystem.applicants();
            frm.ShowDialog();
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

        public void applicants_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dbConnect.DisplayAndSearch("SELECT id,fname,mname,lname,username,password,email FROM users WHERE fname LIKE '%"+ txtSearch.Text + "%' or mname LIKE '%" + txtSearch.Text + "%' or lname LIKE '%" + txtSearch.Text + "%' or username LIKE '%" + txtSearch.Text + "%' ", dataGridView);

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==0)
            {

                //update
                form.Clear();
                form.id = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.fname = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.mname = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.lname = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.username = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.password = dataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                form.dob = dataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
                form.phone = dataGridView.Rows[e.RowIndex].Cells[9].Value.ToString();
                form.email = dataGridView.Rows[e.RowIndex].Cells[10].Value.ToString();
                form.street = dataGridView.Rows[e.RowIndex].Cells[11].Value.ToString();
                form.city = dataGridView.Rows[e.RowIndex].Cells[12].Value.ToString();
                form.province = dataGridView.Rows[e.RowIndex].Cells[13].Value.ToString();
                form.postal = dataGridView.Rows[e.RowIndex].Cells[14].Value.ToString();
                form.education = dataGridView.Rows[e.RowIndex].Cells[15].Value.ToString();
                form.experience = dataGridView.Rows[e.RowIndex].Cells[16].Value.ToString();
                form.last_employer = dataGridView.Rows[e.RowIndex].Cells[17].Value.ToString();
                form.resume = dataGridView.Rows[e.RowIndex].Cells[18].Value.ToString();
                form.valid_id = dataGridView.Rows[e.RowIndex].Cells[19].Value.ToString();
                form.created_at = dataGridView.Rows[e.RowIndex].Cells[20].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                return;
            }
            if(e.ColumnIndex==1)
            {
                //delete
               if( MessageBox.Show("Delete this applicant?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    dbConnect.DeleteApplicant(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }

                return;
            }

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            admin frm = new JobApplicationSystem.admin();
            frm.ShowDialog();
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void applicants_Load(object sender, EventArgs e)
        {
           
        }
    }
}
