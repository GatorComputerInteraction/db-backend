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

        [ForeignKey("RequirementTypeModel")]
        [Column("requirementtype", Order = 1)]
        public int RequirementType { get; set; }

        private DegreeModel DegreeModel { get; set; }

        private CourseModel CourseModel { get; set; }

        private RequirementTypeModel RequirementTypeModel { get; set; }
    }
}
