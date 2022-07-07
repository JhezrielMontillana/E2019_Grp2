using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobApplicationSystem
{

    public partial class view_employers : Form
    {
        private readonly employers _parent;
        public string id, fname, mname, lname, username, password, dob, phone, email, companyname, position, datehired, address_primary, address_secondary, city, province, postal, company_id, created_at;

        private void lblId_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadFileAsync(new Uri("file:///D:/Users/Documents/Visual%20Studio%202015/Projects/JobApplicationSystem/JobApplicationSystem/bin/Debug/~/company_id/" + company_id), @"D:\Users\User\Desktop\" + company_id);
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed!");
        }

        public view_employers()
        {
            InitializeComponent();
        }

        public view_employers(employers parent)
        {
            InitializeComponent();
            _parent = parent;

        }

        public void Clear()
        {
            lblFirstName.Text = string.Empty;
        }

        public void UpdateInfo()
        {
            lblFirstName.Text = fname;
            lblMiddleName.Text = mname;
            lblLastName.Text = lname;
            lblUsername.Text = username;
            lblPassword.Text = password;
            lblDob.Text = dob;
            lblPhone.Text = phone;
            lblEmailAddress.Text = email;
            lblCompanyName.Text = companyname;
            lblPosition.Text = position;
            lblDateHired.Text = datehired;
            lblPrimaryAddress.Text  = address_primary;
            lblSecondaryAddress.Text  = address_secondary;
            lblCity.Text = city;
            lblProvince.Text = province;
            lblPostal.Text = postal;
            lblId.Text = company_id;
            lblCreatedAt.Text = created_at;


        }
        private void view_employers_Load(object sender, EventArgs e)
        {

        }
    }
}
