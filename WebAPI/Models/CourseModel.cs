using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class CourseModel
    {
        [Key]
        [Column(Order = 1)]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }

        [Required]
        public int Credits { get; set; }
    }
}
