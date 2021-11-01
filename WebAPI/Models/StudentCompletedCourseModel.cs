using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("studentcompletedcourses")]
    public class StudentCompletedCourseModel
    {
        [ForeignKey("StudentModel")]
        [Column("ufid", Order = 1)]
        public int UfId { get; set; }

        [ForeignKey("CourseModel")]
        [Column("courseid", Order = 1)]
        public int CourseId { get; set; }

        private StudentModel StudentModel { get; set; }

        private CourseModel CourseModel { get; set; }
    }
}
