using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_Project_Version_2.Models
{
    public class Project
    {
        public int ProjectId { get; set; }


        public String ProjectName { get; set; }


        public DateTime ProjectStart { get; set; }


        public DateTime ProjectEnd { get; set; }


        public string ProjectDescription { get; set; }

        //truyen tham so

        public virtual ICollection<AssignTask> AssignTask { get; set; }
    }
}