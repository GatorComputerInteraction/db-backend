using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("student")]
    public class StudentModel
    {
        [Key]
        [Column("ufid", Order = 1)]
        public int UfId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("firstname")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("lastname")]
        public string LastName { get; set; }

        [ForeignKey("DegreeModel")]
        [Column("degreeid", Order = 1)]
        public int DegreeId { get; set; }

        private DegreeModel DegreeModel { get; set; }
    }
}
