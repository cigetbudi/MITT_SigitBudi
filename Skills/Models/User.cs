using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Skills.Models
{
    public class User
    {
        [Key]
        [Column(TypeName = "nVarchar(50)")]
        public string Username { get; set; }
        [Required]
        [Column(TypeName = "nVarchar(50)")]
        public string Password { get; set; }
    }
}
