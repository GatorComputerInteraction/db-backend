using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class StudentCompletedCourseModel
    {
        [ForeignKey("StudentModel")]
        [Column(Order = 1)]
        public int UfId { get; set; }

        [ForeignKey("CourseModel")]
        [Column(Order = 1)]
        public int CourseId { get; set; }

        public StudentModel StudentModel { get; set; }
        public CourseModel CourseModel { get; set; }
    }
}
