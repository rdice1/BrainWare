using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BrainWare.Models
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            Orderproducts = new HashSet<Orderproduct>();
        }

        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }
        [Required]
        [Column("name")]
        [StringLength(128)]
        public string Name { get; set; }
        [Column("price", TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }

        [InverseProperty(nameof(Orderproduct.Product))]
        public virtual ICollection<Orderproduct> Orderproducts { get; set; }
    }
}
