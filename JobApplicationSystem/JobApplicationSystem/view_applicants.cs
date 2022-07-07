using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobApplicationSystem
{
    public partial class view_applicants : Form
    {
        private readonly applicants _parent;
        private readonly view_applications _child;
        public string id, fname, mname, lname, username, password,dob, phone, email, street, city, province, postal, education, experience, last_employer, resume, valid_id, created_at;

        private void view_applicants_Load(object sender, EventArgs e)
        {

        }

        private void lblId_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadFileAsync(new Uri("file:///D:/Users/Documents/Visual%20Studio%202015/Projects/JobApplicationSystem/JobApplicationSystem/bin/Debug/~/valid_id/" + valid_id), @"C:\Users\User\Downloads\Applicants" + valid_id);
        }

        private void lblResume_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadFileAsync(new Uri("file:///D:/Users/Documents/Visual%20Studio%202015/Projects/JobApplicationSystem/JobApplicationSystem/bin/Debug/~/resume/" + resume ), @"C:\Users\User\Downloads\Applicants" + resume);
        }


        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed!");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtFirst_TextChanged(object sender, EventArgs e)
        {

        }

        public view_applicants(applicants parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public view_applicants(view_applications parent)
        {
            InitializeComponent();
            _child = parent;
        }

        public view_applicants()
        {
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
           lblStreet.Text = street;
           lblCity.Text = city;
           lblProvince.Text = province;
           lblPostal.Text = postal;
           lblEducation.Text = education;
           lblExperience.Text = experience;
           lblEmployer.Text = last_employer;
           lblResume.Text = resume;
           lblId.Text = valid_id;
           lblCreatedAt.Text = created_at;



        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
