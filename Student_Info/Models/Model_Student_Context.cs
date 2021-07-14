using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Student_Info.Models
{
    public class Model_Student_Context : DbContext
    {
        public Model_Student_Context() : base("name=Model_Students")
        {

        }
        public virtual DbSet<Student> student { get; set; }
    }
}