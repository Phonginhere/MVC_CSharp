using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_Project_Version_2.Models
{
    public class AssignTask
    {
        public int AssignTaskId { get; set; }


        public int EmployeeId { get; set; }


        public int ClientId { get; set; }


        public int ProjectId { get; set; }


        public string Task { get; set; }


        public string Note { get; set; }


        //truyen tham chieu

        public virtual Project Project { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Client Client { get; set; }
    }
}