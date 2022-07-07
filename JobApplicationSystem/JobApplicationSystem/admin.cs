using MySql.Data.MySqlClient;
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

    public partial class admin : Form
    {
        private MySqlConnection conn;
        private string server;
        private string database;
        private string uid;
        private string password;


        public admin()
        {
            server = "localhost";
            database = "jas";
            uid = "root";
            password = "";

            string connString;
            connString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            conn = new MySqlConnection(connString);
            InitializeComponent();
            string user = txtApplicants.Text;

        }

        public bool TotalApplicant(string user)
        {

            string query = "SELECT COUNT(id) FROM employer;";

            try
            {
                if (OpenConnectionEmp())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        reader.Close();
                        conn.Close();
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        conn.Close();
                        return false;
                    }
                }
                else
                {

                    conn.Close();
                    return false;
                }
            }

            catch (Exception ex)
            {
                conn.Close();
                return false;
            }
        }
        private bool OpenConnectionEmp()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MysqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Connection to server failed!");
                        break;
                    case 1045:
                        MessageBox.Show("Server username or password is incorrect");
                        break;
                }
                return false;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            applicants frm = new JobApplicationSystem.applicants();
            frm.Show();
            frm.BringToFront();

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            employers frm = new JobApplicationSystem.employers();
            frm.Show();
            frm.BringToFront();

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            jobs frm = new JobApplicationSystem.jobs();
            frm.Show();
            frm.BringToFront();

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            staff frm = new JobApplicationSystem.staff();
            frm.Show();
            frm.BringToFront();

        }
        public void Display()
        {
            dbConnect.DisplayAndSearch("SELECT id,fname,mname,lname,username,password,dob,phone,email,street,city,province,postal,education,experience,last_employer,resume,valid_id,created_at FROM users", dataGridView);
          
            dbConnect.DisplayAndSearchJob("SELECT ID,Title,Company_Name,Location,Job_Type,Salary,Start_Date,Employer,Description,Created_at FROM job", dataGridView);
        
            Double totalJob = Double.Parse(dbConnect.totaljob);
            Double totalApplicants = Double.Parse(dbConnect.total);

            Double percentJob = Math.Round((totalJob/(totalJob + totalApplicants))*100,1);
            Double percentApplicants = Math.Round((totalApplicants / (totalJob + totalApplicants)) * 100,1);


            lblApplicants.Text = percentJob.ToString()+'%';
            lblJobs.Text = percentApplicants.ToString() +'%';

            pieChart.Series["Salary"].Points.AddXY("Applicants", percentJob);
            pieChart.Series["Salary"].Points.AddXY("Job Availability", percentApplicants);

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Logout successfuly!");
            this.Hide();
            JobApplication frm = new JobApplicationSystem.JobApplication();
            frm.Show();
            frm.BringToFront();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtApplicants_Click(object sender, EventArgs e)
        {

        }

        private void admin_Load(object sender, EventArgs e)
        {
            

        }

        private void admin_Shown(object sender, EventArgs e)
        {
        }

        private void lblApplicants_Click(object sender, EventArgs e)
        {

        }

        private void admin_Shown_1(object sender, EventArgs e)
        {
            Display();

        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
