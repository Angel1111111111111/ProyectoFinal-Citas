using Citas_Backend.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using todo_list_backend.Entities;

namespace Citas_Backend.Database
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Security");

            builder.Entity<UserEntity>().ToTable("users");
            builder.Entity<IdentityRole>().ToTable("roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("users_roles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("users_claims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("users_logins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("roles_claims");
            builder.Entity<IdentityUserToken<string>>().ToTable("users_tokens");
        }

        public DbSet<CitasEntity> Citas { get; set; }
        public DbSet<ConsultaEntity> Consultas { get; set; }
        public DbSet<EspecialidadEntity> Especialidades { get; set;}
        public DbSet<TurnoEntity> Turnos { get; set; }
        public DbSet<DoctorEntity> Doctor { get; set; }
        public DbSet<PacienteEntity> Pacientes { get; set; }
    }
}
