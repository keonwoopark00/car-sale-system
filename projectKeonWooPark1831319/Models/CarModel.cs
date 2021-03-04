using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectKeonWooPark1831319.Models
{
    [Table("Model")]
    public class CarModel
    {
        public int Id { get; set; }
        [Required, MaxLength(10)]
        public String Name { get; set; }
        [Required]
        public int BrandId { get; set; }
    }
}