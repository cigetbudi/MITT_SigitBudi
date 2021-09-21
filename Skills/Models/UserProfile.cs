using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Skills.Models
{
    public class UserProfile
    {
        [Key]
        [Column(TypeName = "nVarchar(50)")]
        public string Username { get; set; }
        [ForeignKey("Username")]
        public User User { get; set; }


        [Column(TypeName = "nVarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nVarchar(500)")]
        public string Address { get; set; }
        public DateTime BOD { get; set; }

        [Column(TypeName = "nVarchar(500)")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
