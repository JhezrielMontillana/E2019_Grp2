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
    public partial class myapplication : Form
    {
        public string user, users;
        public myapplication()
        {
            InitializeComponent();
        }
        public void Display()
        {
            dbConnect.DisplayAndSearchApplications("SELECT applications.Id, Job_Id,job.Title,Company_Name,Job_Category,Location,Phone,Email,applications.Status,applications.Created_at FROM applications LEFT JOIN job ON job.ID = applications.Job_Id", dataGridView);
        }

        private void myapplication_Load(object sender, EventArgs e)
        {

        }

        private void myapplication_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Logout successfuly!");
            this.Hide();
            JobApplication frm = new JobApplicationSystem.JobApplication();
            frm.ShowDialog();
            this.Close();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            main frm = new JobApplicationSystem.main();
            frm.ShowDialog();
            this.Close();
        }
        public void ab(string user)
        {
            user = user.ToString();
            txtUsers.Text = user.ToString();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dbConnect.DisplayAndSearchApplications("SELECT applications.Id, Job_Id,job.Title,Company_Name,Job_Category,Location,Phone,Email,applications.Status,applications.Created_at FROM applications LEFT JOIN job ON job.ID = applications.Job_Id WHERE applications.User='" + user + "' AND job.Title LIKE '%" + txtSearch.Text + "%' AND job.Company_Name LIKE '%" + txtSearch.Text + "%' AND job.Job_Category LIKE '%" + txtSearch.Text + "%' AND job.Location LIKE '%" + txtSearch.Text + "%' ", dataGridView);

        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].HeaderText.Equals("Application Status"))
            {
        
                if (e.Value.Equals("Applied"))
                    e.CellStyle.BackColor = Color.RoyalBlue;
                else if (e.Value.Equals("Received"))
                    e.CellStyle.BackColor = Color.MediumTurquoise;
                else if (e.Value.Equals("Under Review"))
                    e.CellStyle.BackColor = Color.Gold;
                else if (e.Value.Equals("Shortlisted"))
                    e.CellStyle.BackColor = Color.Orange;
                else if (e.Value.Equals("Initial Interview"))
                    e.CellStyle.BackColor = Color.Orange;
                else if (e.Value.Equals("Technical Interview"))
                    e.CellStyle.BackColor = Color.Orange;
                else if (e.Value.Equals("Final Interview"))
                    e.CellStyle.BackColor = Color.Orange;
                else if (e.Value.Equals("Selected"))
                    e.CellStyle.BackColor = Color.PowderBlue;
                else if (e.Value.Equals("On-Hold"))
                    e.CellStyle.BackColor = Color.PowderBlue;
                else if (e.Value.Equals("Rejected"))
                    e.CellStyle.BackColor = Color.Red;
                else if (e.Value.Equals("Job Offered"))
                    e.CellStyle.BackColor = Color.Green;
                else
                    e.CellStyle.BackColor = this.dataGridView.DefaultCellStyle.BackColor;
            }
        }

    }
}
