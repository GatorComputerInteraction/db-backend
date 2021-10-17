using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("course")]
    public class CourseModel
    {
        [Key]
        [Column("courseid", Order = 1)]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("coursename")]
        public string CourseName { get; set; }

        [Required]
        [Column("credits")]
        public int Credits { get; set; }
    }
}
