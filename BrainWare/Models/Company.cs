using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BrainWare.Models
{
    [Table("Company")]
    public partial class Company
    {
        public Company()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("company_id")]
        public int CompanyId { get; set; }
        [Required]
        [Column("name")]
        [StringLength(128)]
        public string Name { get; set; }

        [InverseProperty(nameof(Order.Company))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
