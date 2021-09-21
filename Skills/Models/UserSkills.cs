using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Skills.Models
{
    public class UserSkills
    {
        [Required]
        [Key]
        [Column(TypeName = "nVarchar(50)")]
        public string UserSkillId { get; set; }

        [Column(TypeName = "nVarchar(50)")]
        public string Username { get; set; }
        [ForeignKey("Username")]
        public User User { get; set; }


        public int SkillId { get; set; }
        [ForeignKey("SkillId")]
        public Skill Skill { get; set; }


        public int SkillLevelId { get; set; }
        [ForeignKey("SkillLevelId")]
        public SkillLevel SkillLevel { get; set; }
    }

}
