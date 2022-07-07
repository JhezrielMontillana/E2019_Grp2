using JobApplicationSystem;
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
    public partial class view_job : Form
    {
        public string user;
        public string id, job_category, job_type, title, location, salary, description, start_date, company_name;
        
        private readonly main_employer _parent;

        public object collections { get; private set; }

        public view_job(main_employer parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateInfo()
        {
   
            groupBox1.Text = "Update Job";
            btnSave.Text = "Update";
            txtCategory.Text = job_category;
            txtJobType.Text = job_type;
            txtLocation.Text = location;
            txtCompanyName.Text = company_name;
            txtDescription.Text = description;
            txtJobTitle.Text = title;
            txtStartDate.Text = start_date;
            txtSalary.Text = salary;
            txtUser.Text = user;

        }

        public void ab(string user_session)
        {
            user = user_session.ToString();
            txtUser.Text = user.ToString();
        }
        public void Clear()
        {
            txtCategory.Text = txtJobType.Text = txtJobTitle.Text = txtDescription.Text = txtLocation.Text = txtSalary.Text = txtStartDate.Text = string.Empty;
        }

        private void txtStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void view_job_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtCategory.Text.Trim().Length < 3)
            {
                MessageBox.Show("Category is Empty (<3)");
                return;
            }
            if (txtJobType.Text.Trim().Length < 3)
            {
                MessageBox.Show("Job Type is Empty (<3)");
                return;
            }
            if (txtJobTitle.Text.Trim().Length < 3)
            {
                MessageBox.Show("Job Title is Empty (<3)");
                return;
            }
            if (txtDescription.Text.Trim().Length < 3)
            {
                MessageBox.Show("Description is Empty (<3)");
                return;
            }
            if (txtLocation.Text.Trim().Length < 3)
            {
                MessageBox.Show("Location is Empty (<3)");
                return;
            }
            if (txtSalary.Text.Trim().Length < 3)
            {
                MessageBox.Show("Salary is Empty (<1)");
                return;
            }
            if (txtStartDate.Text.Trim().Length < 3)
            {
                MessageBox.Show("Start Date is Empty (<3)");
                return;
            }
            if (txtCompanyName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Company Name is Empty (<3)");
                return;
            }

            if (btnSave.Text == "Save")
            {
                Job std = new Job(txtCategory.Text.Trim(), txtJobType.Text.Trim(), txtJobTitle.Text.Trim(), txtDescription.Text.Trim(), txtLocation.Text.Trim(), txtSalary.Text.Trim(), txtStartDate.Text.Trim(), txtCompanyName.Text.Trim(), txtUser.Text.Trim());
                dbConnect.AddJob(std);
                Clear();
            }
            if(btnSave.Text == "Update")
            {
                Job std = new Job(txtCategory.Text.Trim(), txtJobType.Text.Trim(), txtJobTitle.Text.Trim(), txtDescription.Text.Trim(), txtLocation.Text.Trim(), txtSalary.Text.Trim(), txtStartDate.Text.Trim(), txtCompanyName.Text.Trim(), txtUser.Text.Trim());
                dbConnect.UpdateJob(std,id);
            }
            _parent.Display();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
