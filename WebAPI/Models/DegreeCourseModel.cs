using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class DegreeCourseModel
    {
        [ForeignKey("DegreeModel")]
        [Column(Order = 1)]
        public int DegreeId { get; set; }

        [ForeignKey("CourseModel")]
        [Column(Order = 1)]
        public int CourseId { get; set; }

        public DegreeModel DegreeModel { get; set; }
        public CourseModel CourseModel { get; set; }
    }
}
