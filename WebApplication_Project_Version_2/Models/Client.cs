using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_Project_Version_2.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        
        public String ClientName { get; set; }


        public String ClientPhone { get; set; }


        public String ClientCompany { get; set; }


        public String ClientEmail { get; set; }

        //truyen tham so

        public virtual ICollection<AssignTask> AssignTask { get; set; }

    }
}