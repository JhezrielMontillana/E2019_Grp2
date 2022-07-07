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
    public partial class apply : Form
    {
        public string id, phone, email,user,users;
        private readonly main _parent;
        public object collections { get; private set; }

        public apply(main parent)
        {
            InitializeComponent();
             _parent = parent;
        }

        public void ab(string user)
        {
            user = user.ToString();
            txtUsers.Text = user.ToString();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (btnSave.Text == "Submit")
            {
                Applications std = new Applications(lblId.Text.Trim(), txtUsers.Text.Trim(), txtPhoneNumber.Text.Trim(), txtEmail.Text.Trim());
                dbConnect.AddApplication(std);

            }
        }

        public void UpdateInfo()
        {
            lblId.Text = id;
            txtPhoneNumber.Text = phone;
            txtEmail.Text = email;
            txtUsers.Text = users;

        }

        private void apply_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
