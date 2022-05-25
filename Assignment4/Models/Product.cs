
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Assignment4.Models
{
    public partial class Product
    {
        [Required]
        [Column(TypeName = "int")]
        public int ProductId { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string ProductName { get; set; }
        [Required]
        [Column(TypeName = "float")]
        public double? Price { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int? CategoryId { get; set; }

    }
}
