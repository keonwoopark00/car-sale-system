using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectKeonWooPark1831319.Models
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public String Username { get; set; }
        [Required, MaxLength(20)]
        public String Password { get; set; }
    }
}