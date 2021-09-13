using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BrainWare.Models
{
    [Table("Order")]
    public partial class Order
    {
        public Order()
        {
            Orderproducts = new HashSet<Orderproduct>();
        }

        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }
        [Required]
        [Column("description")]
        [StringLength(1000)]
        public string Description { get; set; }
        [Column("company_id")]
        public int CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        [InverseProperty("Orders")]
        public virtual Company Company { get; set; }
        [InverseProperty(nameof(Orderproduct.Order))]
        public virtual ICollection<Orderproduct> Orderproducts { get; set; }
    }
}
