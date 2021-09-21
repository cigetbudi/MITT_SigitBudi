using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Skills.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        [Column(TypeName = "nVarchar(500)")]
        public string SkillName { get; set; }
    }
}
