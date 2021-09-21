using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Skills.Models
{
    public class SkillLevel
    {
        [Key]
        [Column(TypeName = "nVarchar(50)")]
        public int SkillLevelId { get; set; }
        [Column(TypeName = "nVarchar(500)")]
        public string SkillLevelName { get; set; }
    }
}
