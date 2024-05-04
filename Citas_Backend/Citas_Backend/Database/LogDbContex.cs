using Citas_Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Citas_Backend.Database
{
    public class LogDbContext : DbContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
        {
        }

        public DbSet<LogEntity> Logs { get; set; }
    }
}
