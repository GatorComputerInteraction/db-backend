using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class StudentScheduleModel
    {
        [ForeignKey("StudentModel")]
        [Column(Order = 1)]
        public int UfId { get; set; }

        [ForeignKey("CourseInstanceModel")]
        [Column(Order = 1)]
        public int InstanceId { get; set; }

        public StudentModel StudentModel { get; set; }

        public CourseInstanceModel CourseInstanceModel { get; set; }
    }
}
