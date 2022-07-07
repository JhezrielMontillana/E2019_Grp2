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
    public partial class JobApplication : Form
    {
        private MySqlConnection conn;
        private string server;
        private string database;
        private string uid;
        private string password;
        string user_session;
    
        public JobApplication()
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
        private void main()
        {
            user_session = txtUsername.Text;
            this.Hide();
            main frm = new JobApplicationSystem.main();
            frm.abc(user_session.ToString());
            frm.Show();
            frm.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            if (Login(user, pass))
            {
                MessageBox.Show($"Welcome {user}!");
                main();
            }
            else
            {
                MessageBox.Show($"{user} does not exist or password is incorrect!");

            }
        }
            public bool Login(string user, string pass)
        {
         
            string query = $"SELECT * FROM users WHERE username='{user}' AND password='{pass}';";

            try
            {
                if (OpenConnection())
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
        private bool OpenConnection()
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


        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }

      
        private void mainemployer()
        {
            user_session = txtUsernameEmp.Text;
            this.Hide();
            main_employer frm = new JobApplicationSystem.main_employer();
            frm.ab(user_session.ToString());
            frm.Show();
            frm.BringToFront();
        }

        private void mainadmin()
        {
            this.Hide();
            admin frm = new JobApplicationSystem.admin();
            frm.Show();
            frm.BringToFront();
        
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            register frm = new JobApplicationSystem.register();
            frm.ShowDialog();
            this.Close();
        }

        private void JobApplication_Load(object sender, EventArgs e)
        {
            

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string user = txtUsernameEmp.Text;
            string pass = txtPasswordEmp.Text;
            if (LoginEmployer(user, pass))
            {
                MessageBox.Show($"Welcome {user}!");
                mainemployer();
            }
            else
            {
                MessageBox.Show($"{user} does not exist or password is incorrect!");

            }
        }
        public bool LoginEmployer(string user, string pass)
        {

            string query = $"SELECT * FROM employer WHERE username='{user}' AND password='{pass}';";

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

        private void button2_Click(object sender, EventArgs e)
        {
            string user = txtUsernameAdmin.Text;
            string pass = txtPasswordAdmin.Text;
            if (LoginAdmin(user, pass))
            {
                MessageBox.Show($"Welcome {user}!");
                mainadmin();
            }
            else
            {
                MessageBox.Show($"{user} does not exist or password is incorrect!");

            }
        }
        public bool LoginAdmin(string user, string pass)
        {

            string query = $"SELECT * FROM admin WHERE username='{user}' AND password='{pass}';";

            try
            {
                if (OpenConnectionAdmin())
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
        private bool OpenConnectionAdmin()
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            registeremp frm = new JobApplicationSystem.registeremp();
            frm.Show();
            frm.BringToFront();
        }

        private void txtUsernameEmp_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
