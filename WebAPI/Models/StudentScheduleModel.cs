using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("studentschedule")]
    public class StudentScheduleModel
    {
        [ForeignKey("StudentModel")]
        [Column("ufid", Order = 1)]
        public int UfId { get; set; }

        [ForeignKey("CourseInstanceModel")]
        [Column("instanceid", Order = 1)]
        public int InstanceId { get; set; }

        private StudentModel StudentModel { get; set; }

        private CourseInstanceModel CourseInstanceModel { get; set; }
    }
}
