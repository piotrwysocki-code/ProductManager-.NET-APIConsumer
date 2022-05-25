using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Assignment4.Models
{
    public partial class Category
    {

        [Required]
        [Column(TypeName = "int")]
        public int CategoryId { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string CategoryName { get; set; }

    }
}
