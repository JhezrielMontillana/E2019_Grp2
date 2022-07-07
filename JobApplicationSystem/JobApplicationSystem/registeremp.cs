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
    public partial class registeremp : Form
    {
        private MySqlConnection conn;
        private string server;
        private string database;
        private string uid;
        private string password;


        public registeremp()
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

     
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void upload_id_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();



                if (dialog.ShowDialog() == DialogResult.OK)
                {


                    txtCid.Text = System.IO.Path.GetFileName(dialog.FileName);


                    String path = Path.Combine(@"~\company_id\");
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
        private void txtPostal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtPrimaryAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSecondaryAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDateHired_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtCid_Click(object sender, EventArgs e)
        {

        }
        private void btnRegister_Click(object sender, EventArgs e)
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
            string company = txtCompanyName.Text;
            string position = txtPosition.Text;
            string datehired = txtDateHired.Text;
            string address1 = txtPrimaryAddress.Text;
            string address2 = txtSecondaryAddress.Text;
            string city = txtCity.Text;
            string province = txtProvince.Text;
            string postal = txtPostal.Text;

            string id = txtCid.Text;


            Register(user, pass, fname, mname, lname, dob, phone, email, company, position, datehired, address1, address2, city, province, postal, id);

            if (String.IsNullOrEmpty(user) && String.IsNullOrEmpty(pass) && String.IsNullOrEmpty(cpass)
             && String.IsNullOrEmpty(fname) && String.IsNullOrEmpty(lname) && String.IsNullOrEmpty(mname)
             && String.IsNullOrEmpty(dob) && String.IsNullOrEmpty(phone) && String.IsNullOrEmpty(email)
             && String.IsNullOrEmpty(address1) && String.IsNullOrEmpty(city) && String.IsNullOrEmpty(province)
             && String.IsNullOrEmpty(postal) && String.IsNullOrEmpty(datehired) && String.IsNullOrEmpty(datehired)
             && String.IsNullOrEmpty(address2) && String.IsNullOrEmpty(position) && String.IsNullOrEmpty(id))
            {
                MessageBox.Show("All fields required!");

            }
            else
            {
                if (!dataPrivacy.Checked)
                {
                    MessageBox.Show("Before submission please confirm that you agree with our Privacy Policy");

                }
                else
                {
                    if (cpass != pass)
                    {
                        MessageBox.Show("Password not match");

                    }
                    else
                    {
                        if (!Register(user, pass, fname, mname, lname, dob, phone, email, company, position, datehired, address1, address2, city, province, postal, id))
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
        public bool Register(string user, string pass, string fname, string mname, string lname, string dob, string phone, string email, string company, string position, string datehired, string address1, string address2, string city, string province, string postal, string id)

        {

            string query = $"INSERT INTO employer (id, username, password, fname, mname, lname, dob, phone, email, companyname, position, datehired, address_primary, address_secondary, city, province, postal, company_id) VALUES ('','{user}','{pass}','{fname}','{mname}', '{lname}', '{dob}','{phone}','{email}','{company}','{position}','{datehired}','{address1}','{address2}','{city}','{province}','{postal}','{id}');";

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

        private void registeremp_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void dataPrivacy_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtPosition_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtProvince_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtDoB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtMiddleName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
