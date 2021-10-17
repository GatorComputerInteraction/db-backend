using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("degreecourses")]
    public class DegreeCourseModel
    {
        [ForeignKey("DegreeModel")]
        [Column("degreeid", Order = 1)]
        public int DegreeId { get; set; }

        [ForeignKey("CourseModel")]
        [Column("courseid", Order = 1)]
        public int CourseId { get; set; }

        public DegreeModel DegreeModel { get; set; }

        public CourseModel CourseModel { get; set; }
    }
}
