using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("courseinstance")]
    public class CourseInstanceModel
    {
        [Key]
        [Column("instanceid", Order = 1)]
        public int InstanceId { get; set; }

        [Required]
        [MaxLength(6)]
        [Column("semester")]
        public string Semester { get; set; }

        [Required]
        [Column("year")]
        public int Year { get; set; }

        [ForeignKey("CourseModel")]
        [Column("courseid", Order = 1)]
        public int CourseId { get; set; }

        [ForeignKey("TimeslotModel")]
        [Column("slotid", Order = 1)]
        public int SlotId { get; set; }

        public CourseModel CourseModel { get; set; }

        public TimeslotModel TimeslotModel { get; set; }
    }
}
