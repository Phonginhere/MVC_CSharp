using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_Project_Version_2.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }


        public string EmployeeName { get; set; }


        public string EmployeeEmail { get; set; }


        public string EmployeePhone { get; set; }


        public string EmployeeDepartment { get; set; }

        //truyen tham so

        public virtual ICollection<AssignTask> AssignTask { get; set; }
    }
}