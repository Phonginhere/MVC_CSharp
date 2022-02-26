//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WAD_A1908G2_Phong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Product
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(maximumLength: 32 , ErrorMessage = "Product Name must be between 3 and 32", MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        
        public Nullable<decimal> Price { get; set; }
        [Required]
        [Range(maximum: 100, minimum: 1, ErrorMessage = "Quantity must be 1 and 100")]
        public Nullable<int> Quantity { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        [Required]
        public int CategoryId { get; set; }
    
        public virtual Category Category { get; set; }
    }
}