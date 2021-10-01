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

        public virtual DbSet<StudentModel> Students { get; set; }
    }
}
