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
    public partial class change_status : Form
    {
        public string id, user;
        private readonly view_applications _parent;
        view_applications form;
        public change_status(view_applications parent)
        {
            InitializeComponent();

        }
        public void ChangeStatus()
        {
            lblId.Text = id;
        }
        private void change_status_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AppStatus std = new AppStatus(lblId.Text.Trim(),txtStatus.Text.Trim());
            dbConnect.UpdateStatus(std, id);
            this.Close();
        
        }
    }
}
