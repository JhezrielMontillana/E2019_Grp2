using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace JobApplicationSystem
{
    class dbConnect
    {
        public static string total;
        public static string totaljob;

        admin frm;
        

        public static MySqlConnection GetConnection()
        {

            string sql = "datasource=localhost;port=3306;username=root;password=;database=jas";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch(MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("MySql Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }

       public void dbCon()
        {

        }

        public static void AddJob(Job std)
        {
            string sql = "INSERT INTO job VALUES (NULL, @Job_Category, @Job_Type, @Title, @Location, @Salary, @Description, @Start_Date,@Company_Name,@Employer,NULL,'Open')";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Job_Category", MySqlDbType.VarChar).Value = std.Job_Category;
            cmd.Parameters.Add("@Job_Type", MySqlDbType.VarChar).Value = std.Job_Type;
            cmd.Parameters.Add("@Title", MySqlDbType.VarChar).Value = std.Title;
            cmd.Parameters.Add("@Location", MySqlDbType.VarChar).Value = std.Location;
            cmd.Parameters.Add("@Salary", MySqlDbType.VarChar).Value = std.Salary;
            cmd.Parameters.Add("@Description", MySqlDbType.VarChar).Value = std.Description;
            cmd.Parameters.Add("@Start_Date", MySqlDbType.VarChar).Value = std.Start_Date;
            cmd.Parameters.Add("@Company_Name", MySqlDbType.VarChar).Value = std.Company_Name;
            cmd.Parameters.Add("@Employer", MySqlDbType.VarChar).Value = std.Employer;

            try
            {
                cmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Added Successfuly", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Job Not Inserted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();
        }


        public static void AddApplication(Applications std)
        {
            string sql = "INSERT INTO applications VALUES (NULL, @Id, @User,'Applied', @Phone, @Email, NULL)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Id", MySqlDbType.VarChar).Value = std.Id;
            cmd.Parameters.Add("@User", MySqlDbType.VarChar).Value = std.User;
            cmd.Parameters.Add("@Phone", MySqlDbType.VarChar).Value = std.Phone;
            cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = std.Email;

            //cmd.Parameters.Add("@User", MySqlDbType.VarChar).Value = std.User;

            try
            {
                cmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Added Successfuly", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Application Not Inserted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();
        }


        public static void UpdateStatus(AppStatus std, string id)
        {
            string sql = "UPDATE applications SET Status=@Status WHERE Id = @Id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@Status", MySqlDbType.VarChar).Value = std.Status;


            try
            {
                
                cmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Application Status Updated Successfuly", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Application Status Not Updated. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();
        }



        public static void UpdateJob(Job std, string id)
        {
            string sql = "UPDATE job SET Job_Category = @Job_Category, Job_Type = @Job_Type, Title = @Title, Location= @Location, Salary=@Salary, Description=@Description,Start_Date=@Start_Date, Company_Name=@Company_Name WHERE ID = @Id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@Job_Category", MySqlDbType.VarChar).Value = std.Job_Category;
            cmd.Parameters.Add("@Job_Type", MySqlDbType.VarChar).Value = std.Job_Type;
            cmd.Parameters.Add("@Title", MySqlDbType.VarChar).Value = std.Title;
            cmd.Parameters.Add("@Location", MySqlDbType.VarChar).Value = std.Location;
            cmd.Parameters.Add("@Salary", MySqlDbType.VarChar).Value = std.Salary;
            cmd.Parameters.Add("@Description", MySqlDbType.VarChar).Value = std.Description;
            cmd.Parameters.Add("@Start_Date", MySqlDbType.VarChar).Value = std.Start_Date;
            cmd.Parameters.Add("@Company_Name", MySqlDbType.VarChar).Value = std.Company_Name;

            try
            {
                cmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Job Updated Successfuly", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Job Not Updated. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();
        }


        public static void DeleteJob(string id)
        {
            string sql = "DELETE FROM job WHERE ID = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Job Deleted Successfuly", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Job Not Deleted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();

        }

        public static void DeleteApplicant(string id)
        {
            string sql = "DELETE FROM users WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Deleted Successfuly", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Applicant Not Deleted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();

        }


        public static void DeleteEmployer(string id)
        {
            string sql = "UPDATE job SET employer = @Employer WHERE id = @Id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Deleted Successfuly", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Employer Not Deleted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();

        }


        public static void DisplayAndSearchJob(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();

            totaljob = tbl.Rows.Count.ToString();
            admin frm = new admin();
        }

        public static void DisplayAndSearchApplicants(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();
        }


        public static void DisplayAndSearchApplications(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();
        }

        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();

            total = tbl.Rows.Count.ToString();
            admin frm = new admin();

        }

        public static void DisplayAndSearchEmp(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();

        }

        public static void ViewApplicant(Holder std, string id)
        {
            string sql = "UPDATE users SET fname = @fname WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@fname", MySqlDbType.VarChar).Value = std.Fname;
            cmd.Parameters.Add("@mname", MySqlDbType.VarChar).Value = std.Mname;
            cmd.Parameters.Add("@lname", MySqlDbType.VarChar).Value = std.Lname;
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = std.Username;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = std.Password;
            try
            {
                cmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Updated Successfuly", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Applicant Not Updated. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();
        }



        public static void ViewEmployer(HolderEmp std, string id)
        {
            string sql = "UPDATE employer SET fname = @fname WHERE id = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@fname", MySqlDbType.VarChar).Value = std.Fname;
            cmd.Parameters.Add("@mname", MySqlDbType.VarChar).Value = std.Mname;
            cmd.Parameters.Add("@lname", MySqlDbType.VarChar).Value = std.Lname;
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = std.Username;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = std.Password;
            try
            {
                cmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Updated Successfuly", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Employer Not Updated. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();
        }


    }
}
