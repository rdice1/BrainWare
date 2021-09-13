using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BrainWare.Models
{
    [Table("orderproduct")]
    public partial class Orderproduct
    {
        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }
        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }
        [Column("price", TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("Orderproducts")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("Orderproducts")]
        public virtual Product Product { get; set; }
    }
}
