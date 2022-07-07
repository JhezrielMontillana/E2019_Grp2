using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobApplicationSystem
{
    public partial class register : Form
    {
        private MySqlConnection conn;
        private string server;
        private string database;
        private string uid;
        private string password;


        public register()
        {
            server = "localhost";
            database = "jas";
            uid = "root";
            password = "";

            string connString;
            connString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            conn = new MySqlConnection(connString);
            InitializeComponent();
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
     

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void upload_resume_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();



                if (dialog.ShowDialog() == DialogResult.OK)
                {

                    txtResume.Text = System.IO.Path.GetFileName(dialog.FileName);

                    String path = Path.Combine(@"~\resume\");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    var fileName = System.IO.Path.GetFileName(dialog.FileName);
                    path = path + fileName;
                    File.Copy(dialog.FileName, path);


                }
            }
            catch (Exception ex)
            {

            }

        }

        private void upload_id_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();



                if (dialog.ShowDialog() == DialogResult.OK)
                {


                    txtId.Text = System.IO.Path.GetFileName(dialog.FileName);


                    String path = Path.Combine(@"~\valid_id\");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    var fileName = System.IO.Path.GetFileName(dialog.FileName);
                    path = path + fileName;
                    File.Copy(dialog.FileName, path);


                }
            }
            catch (Exception ex)
            {

            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void dataPrivacy_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            string cpass = txtConfirmPassword.Text;
            string fname = txtFirstname.Text;
            string mname = txtMiddleName.Text;
            string lname = txtLastName.Text;
            string dob = txtDoB.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            string street = txtStreet.Text;
            string city = txtCity.Text;
            string province = txtProvince.Text;
            string postal = txtPostal.Text;
            string education = txtEducation.Text;
            string experience = txtExperience.Text;
            string employer = txtEmployer.Text;
            string resume = txtResume.Text;
            string id = txtId.Text;


            Register(user, pass, fname, mname, lname, dob, phone, email, street, city, province,
                postal, education, experience, employer, resume, id);

            if(String.IsNullOrEmpty(user) && String.IsNullOrEmpty(pass) && String.IsNullOrEmpty(cpass)
             && String.IsNullOrEmpty(fname) && String.IsNullOrEmpty(lname) && String.IsNullOrEmpty(mname)
             && String.IsNullOrEmpty(dob) && String.IsNullOrEmpty(phone) && String.IsNullOrEmpty(email)
             && String.IsNullOrEmpty(street) && String.IsNullOrEmpty(city) && String.IsNullOrEmpty(province)
             && String.IsNullOrEmpty(postal) && String.IsNullOrEmpty(education) && String.IsNullOrEmpty(experience)
             && String.IsNullOrEmpty(employer) && String.IsNullOrEmpty(resume) && String.IsNullOrEmpty(id))
            {
                MessageBox.Show("All fields required!");

            }
            else { 
            if (!dataPrivacy.Checked)
            {
                MessageBox.Show("Before submission please confirm that you agree with our Privacy Policy");

            }
            else { 
            if (cpass != pass)
            {
                MessageBox.Show("Password not match");

            }
            else
            { 
            if (!Register(user, pass, fname, mname, lname, dob, phone, email, street, city, province,
                postal, education, experience, employer, resume, id))
            {
                MessageBox.Show($"User {user} has been created!");
                this.Hide();
                JobApplication frm = new JobApplicationSystem.JobApplication();
                frm.ShowDialog();
                this.Close();
                        }
            else
            {
                MessageBox.Show($"User {user} has not been created!");
            }
            }
        }
        }
        }
        public bool Register(string user, string pass, string fname, string mname, string lname, string dob, string phone, string email, string street, string city, string province,
                string postal, string education, string experience, string employer, string resume, string id)
                 
        {

            string query = $"INSERT INTO users (id, username, password, fname, mname, lname, dob, phone, email, street, city, province, postal, education, experience, last_employer, resume, valid_id) VALUES ('','{user}','{pass}','{fname}','{mname}', '{lname}', '{dob}','{phone}','{email}','{street}','{city}','{province}','{postal}','{education}','{experience}','{employer}','{resume}','{id}');";

            try
            {

                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
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






        private bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Connection to server failed!");
                        break;
                    case 1045:
                        MessageBox.Show("Server username or password is incorrect!");
                        break;
                }
                return false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            JobApplication frm = new JobApplicationSystem.JobApplication();
            frm.ShowDialog();
            this.Close();
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
    }
}

   
