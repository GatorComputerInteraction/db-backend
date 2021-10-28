using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.DbContexts
{
    public partial class NpgDbContext : DbContext
    {
        public NpgDbContext(DbContextOptions<NpgDbContext> options)
            : base(options)
        {
        }

        /*
         * Defining composite keys for the models
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DegreeCourseModel>()
                .HasKey(nameof(DegreeCourseModel.DegreeId), nameof(DegreeCourseModel.CourseId));
            modelBuilder.Entity<StudentCompletedCourseModel>()
                .HasKey(nameof(StudentCompletedCourseModel.UfId), nameof(StudentCompletedCourseModel.CourseId));
            modelBuilder.Entity<StudentScheduleModel>()
                .HasKey(nameof(StudentScheduleModel.UfId), nameof(StudentScheduleModel.InstanceId));
        }

        public virtual DbSet<StudentModel> Student { get; set; }
        public virtual DbSet<CourseModel> Course { get; set; }
        public virtual DbSet<DegreeModel> Degree { get; set; }
        public virtual DbSet<PeriodModel> Period { get; set; }
        public virtual DbSet<TimeslotModel> Timeslot { get; set; }
        public virtual DbSet<DegreeCourseModel> DegreeCourses { get; set; }
        public virtual DbSet<StudentCompletedCourseModel> StudentCompletedCourses { get; set; }
        public virtual DbSet<CourseInstanceModel> CourseInstance { get; set; }
        public virtual DbSet<StudentScheduleModel> StudentSchedule { get; set; }
        public virtual DbSet<RequirementTypeModel> RequirementType { get; set; }
    }
}
