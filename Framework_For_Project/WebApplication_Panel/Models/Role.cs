//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication_Panel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Role
    {
        public Role()
        {
            this.EmployeeRoleMappings = new HashSet<EmployeeRoleMapping>();
        }
    
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    
        public virtual ICollection<EmployeeRoleMapping> EmployeeRoleMappings { get; set; }
    }
}
