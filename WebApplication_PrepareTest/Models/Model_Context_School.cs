using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication_PrepareTest.Models;


namespace WebApplication_PrepareTest.Models
{
    public class Model_Context_School  : DbContext
    {
        public Model_Context_School() : base("name=Db_School")
        {

        }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set;}
    }
}