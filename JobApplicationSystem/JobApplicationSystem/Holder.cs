using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationSystem
{
    class Holder
    {
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Holder(string fname, string mname, string lname, string username, string password)
        {
            Fname = fname;
            Lname = lname;
            Mname = mname;
            Username = username;
            Password = password;
        }
    }


    class HolderEmp
    {
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public HolderEmp(string fname, string mname, string lname, string username, string password)
        {
            Fname = fname;
            Lname = lname;
            Mname = mname;
            Username = username;
            Password = password;
        }
    }


    class Job
    {

        public string Job_Category { get; set; }
        public string Job_Type { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Salary { get; set; }
        public string Description { get; set; }
        public string Start_Date { get; set; }
        public string Company_Name { get; set; }
        public string Employer { get; set; }

        public Job(string job_category, string job_type, string title, string description, string location, string salary, string start_date, string company_name, string employer)
        {
         
            Job_Category = job_category;
            Job_Type = job_type;
            Title = title;
            Location = location;
            Salary = salary;
            Description = description;
            Start_Date = start_date;
            Company_Name = company_name;
            Employer = employer;

        }
    }



    class Applications
    {

        public string Id { get; set; }
        public string User { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Applications(string id, string user, string phone, string email)
        {

            Id = id;
            User = user;
            Phone = phone;
            Email = email;

        }

       
    }


    class AppStatus
    {

        public string Id { get; set; }
        public string Status { get; set; }

        public AppStatus(string id, string status)
        {

            Id = id;
            Status = status;

        }


    }

}
