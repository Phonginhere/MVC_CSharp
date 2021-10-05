namespace WebApplication_CLoud_Azure.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LinhsTestTable2
    {
        [Key]
        public int TestId { get; set; }

        [StringLength(150)]
        public string LinhsComment { get; set; }

        [StringLength(150)]
        public string feelings { get; set; }
    }
}
