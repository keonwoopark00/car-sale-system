using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectKeonWooPark1831319.Models
{
    [Table("Sale")]    
    public class Sale
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ModelId { get; set; }
        public int BrandId { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}