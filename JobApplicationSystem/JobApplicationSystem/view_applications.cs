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
    public partial class view_applications : Form
    {
        private readonly main_employer _parent;
        public string id,user;
        view_applicants form;
        change_status frm;
        public view_applications(main_employer parent)
        {
            InitializeComponent();
            _parent = parent;
            form = new view_applicants(this);
            frm = new change_status(this);
        }

        public view_applications()
        {
        }

        public void ViewApplicants()
        {
            lblId.Text = id;
            
        }

        public void Display()
        {
            dbConnect.DisplayAndSearchApplicants("SELECT applications.ID, applications.Job_Id, users.fname, users.mname, users.lname, applications.Phone, applications.Email, applications.Status, applications.User, username,password,dob,street,city,province,postal,education,experience,last_employer,resume,valid_id,users.created_at FROM applications LEFT JOIN users ON users.username = applications.User WHERE Job_Id='" + id + "'", dataGridView);
        }

        public void Clear()
        {
            lblId.Text = string.Empty;
        }
        private void view_applications_Load(object sender, EventArgs e)
        {

        }

        private void view_applications_Shown(object sender, EventArgs e)
        {
            Display();
        }
     

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                //change status
                frm.id = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.Close();
                frm.ChangeStatus();
                frm.ShowDialog();
                return;

            }

            if (e.ColumnIndex == 1)
            {
                //view details
                form.Clear();
                form.fname = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.mname = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.lname = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
               // form.username = dataGridView.Rows[e.RowIndex].Cells[11].Value.ToString();
               // form.password = dataGridView.Rows[e.RowIndex].Cells[12].Value.ToString();
                form.dob = dataGridView.Rows[e.RowIndex].Cells[13].Value.ToString();
                form.phone = dataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                form.email = dataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
                form.street = dataGridView.Rows[e.RowIndex].Cells[14].Value.ToString();
                form.city = dataGridView.Rows[e.RowIndex].Cells[15].Value.ToString();
                form.province = dataGridView.Rows[e.RowIndex].Cells[16].Value.ToString();
                form.postal = dataGridView.Rows[e.RowIndex].Cells[17].Value.ToString();
                form.education = dataGridView.Rows[e.RowIndex].Cells[18].Value.ToString();
                form.experience = dataGridView.Rows[e.RowIndex].Cells[19].Value.ToString();
                form.last_employer = dataGridView.Rows[e.RowIndex].Cells[20].Value.ToString();
                form.resume = dataGridView.Rows[e.RowIndex].Cells[21].Value.ToString();
                form.valid_id = dataGridView.Rows[e.RowIndex].Cells[22].Value.ToString();
                form.created_at = dataGridView.Rows[e.RowIndex].Cells[23].Value.ToString();


                form.UpdateInfo();
                form.ShowDialog();
                return;
            }
           
           
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].HeaderText.Equals("Status"))
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
