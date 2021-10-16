using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class StudentModel
    {
        [Key]
        [Column(Order = 1)]
        public int UfId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [ForeignKey("DegreeModel")]
        [Column(Order = 1)]
        public int DegreeId { get; set; }

        public DegreeModel DegreeModel { get; set; }
    }
}
