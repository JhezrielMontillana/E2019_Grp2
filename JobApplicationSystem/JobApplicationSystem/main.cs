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
    public partial class main : Form
    {
        apply frm;
        string user;
        public main()
        {
            InitializeComponent();
            frm = new apply(this);


        }
        public void abc(string user_session)
        {
            user = user_session.ToString();
            //txtUser.Text = user.ToString();
        }

        public void Display()
        {
            dbConnect.DisplayAndSearchJob("SELECT ID,Title,Company_Name,Location,Job_Type,Salary,Start_Date,Employer,Description,Created_at FROM job", dataGridView);
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Logout successfuly!");
            this.Hide();
            JobApplication frm = new JobApplicationSystem.JobApplication();
            frm.ShowDialog();
            this.Close();
        }

        private void main_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
                if (e.ColumnIndex == 1)
                {
                    frm.id = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                    frm.UpdateInfo();
                    frm.ab(user.ToString());
                    frm.ShowDialog();
                }
                return;
            }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dbConnect.DisplayAndSearchEmp("SELECT ID,Title,Company_Name,Location,Job_Type,Salary,Start_Date,Employer,Description,Created_at FROM job WHERE Title LIKE '%" + txtSearch.Text + "%' AND Company_Name LIKE '%" + txtSearch.Text + "%' AND Job_Type LIKE '%" + txtSearch.Text + "%' AND Location LIKE '%" + txtSearch.Text + "%' ", dataGridView);

        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
       
            myapplication frm = new JobApplicationSystem.myapplication();
            frm.ab(user.ToString());
            frm.ShowDialog();
          
        }
    }

  
    
}
