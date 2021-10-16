using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class CourseInstanceModel
    {
        [Key]
        [Column(Order = 1)]
        public int InstanceId { get; set; }

        [Required]
        [MaxLength(6)]
        public string Semester { get; set; }

        [Required]
        public int Year { get; set; }

        [ForeignKey("CourseModel")]
        [Column(Order = 1)]
        public int CourseId { get; set; }

        [ForeignKey("TimeslotModel")]
        [Column(Order = 1)]
        public int SlotId { get; set; }

        public CourseModel CourseModel { get; set; }

        public TimeslotModel TimeslotModel { get; set; }
    }
}
