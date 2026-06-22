using Microsoft.EntityFrameworkCore;

namespace PetCat.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Vacuna> Vacunas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Guardar el enum SexoMascota como texto legible en la BD
            modelBuilder.Entity<Mascota>()
                .Property(m => m.Sexo)
                .HasConversion<string>();

            // Relación: una Mascota tiene muchas Vacunas
            modelBuilder.Entity<Vacuna>()
                .HasOne(v => v.Mascota)
                .WithMany(m => m.Vacunas)
                .HasForeignKey(v => v.MascotaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}