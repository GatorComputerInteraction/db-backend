using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("degree")]
    public class DegreeModel
    {
        [Key]
        [Column("degreeid", Order = 1)]
        public int DegreeId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("degreename")]
        public string DegreeName { get; set; }
    }
}
