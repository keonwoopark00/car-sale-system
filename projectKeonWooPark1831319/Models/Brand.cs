using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectKeonWooPark1831319.Models
{
    [Table("Brand")]
    public class Brand
    {
        public int Id { get; set; }
        [Required, MaxLength(15)]
        public String Name { get; set; }
    }
}