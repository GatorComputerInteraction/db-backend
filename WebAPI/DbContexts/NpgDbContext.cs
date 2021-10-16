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

        public virtual DbSet<StudentModel> Students { get; set; }
        public virtual DbSet<CourseModel> Courses { get; set; }
        public virtual DbSet<DegreeModel> Degrees { get; set; }
        public virtual DbSet<PeriodModel> Periods { get; set; }
        public virtual DbSet<TimeslotModel> Timeslots { get; set; }
        public virtual DbSet<DegreeCourseModel> DegreeCourses { get; set; }
        public virtual DbSet<StudentCompletedCourseModel> StudentCompletedCourses { get; set; }
        public virtual DbSet<CourseInstanceModel> CourseInstances { get; set; }
        public virtual DbSet<StudentScheduleModel> StudentSchedules { get; set; }
    }
}
