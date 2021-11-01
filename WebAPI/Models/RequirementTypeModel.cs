using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("requirementtypes")]
    public class RequirementTypeModel
    {
        [Key]
        [Column("requirementtype", Order = 1)]
        public int RequirementType { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("name")]
        public string Name { get; set; }
    }
}
