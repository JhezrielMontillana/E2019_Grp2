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
    public partial class employers : Form
    {
        view_employers form;
        public employers()
        {
            InitializeComponent();
            form = new view_employers(this);
        }

        public void Display()
        {
            dbConnect.DisplayAndSearchEmp("SELECT id,fname,mname,lname,username,password,dob,phone,email,companyname,position,datehired,address_primary,address_secondary,city,province,postal,company_id,created_at FROM employer", dataGridView);

        }
        public void employers_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dbConnect.DisplayAndSearchEmp("SELECT id,fname,mname,lname,username,password,email FROM employer WHERE fname LIKE '%" + txtSearch.Text + "%' or mname LIKE '%" + txtSearch.Text + "%' or lname LIKE '%" + txtSearch.Text + "%' or username LIKE '%" + txtSearch.Text + "%' ", dataGridView);

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
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
                form.companyname = dataGridView.Rows[e.RowIndex].Cells[11].Value.ToString();
                form.position = dataGridView.Rows[e.RowIndex].Cells[12].Value.ToString();
                form.datehired = dataGridView.Rows[e.RowIndex].Cells[13].Value.ToString();
                form.address_primary = dataGridView.Rows[e.RowIndex].Cells[14].Value.ToString();
                form.address_secondary = dataGridView.Rows[e.RowIndex].Cells[15].Value.ToString();
                form.city = dataGridView.Rows[e.RowIndex].Cells[16].Value.ToString();
                form.province = dataGridView.Rows[e.RowIndex].Cells[17].Value.ToString();
                form.postal = dataGridView.Rows[e.RowIndex].Cells[18].Value.ToString();
                form.company_id = dataGridView.Rows[e.RowIndex].Cells[19].Value.ToString();
                form.created_at = dataGridView.Rows[e.RowIndex].Cells[20].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)
            {
                //delete
                if (MessageBox.Show("Delete this employer?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    dbConnect.DeleteEmployer(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }

                return;
            }

        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            applicants frm = new JobApplicationSystem.applicants();
            frm.ShowDialog();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void employers_Load(object sender, EventArgs e)
        {

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
