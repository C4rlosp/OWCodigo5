using Microsoft.EntityFrameworkCore;
using OWCodigo5.Models;

namespace OWCodigo5.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Asiento> Asientos { get; set; } = null!;
        public DbSet<Obra> Obras { get; set; } = null!;
        public DbSet<Genero> Generos { get; set; } = null!;
        public DbSet<Actor> Actores { get; set; } = null!;
        public DbSet<Teatro> Teatros { get; set; } = null!;
        public DbSet<ObraTeatro> ObrasTeatros { get; set; } = null!;
        public DbSet<Director> Directores { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Carrito> Carritos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de precisiones para propiedades

            // Relación uno a muchos entre Obra y Actor
            modelBuilder.Entity<Obra>()
                .HasMany(o => o.Actores)
                .WithOne(a => a.Obra)
                .HasForeignKey(a => a.IdObra)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación muchos a uno entre ObraTeatro y Obra
            modelBuilder.Entity<ObraTeatro>()
                .HasOne(ot => ot.Obra)
                .WithMany()
                .HasForeignKey(ot => ot.IdObra)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación muchos a uno entre ObraTeatro y Teatro
            modelBuilder.Entity<ObraTeatro>()
                .HasOne(ot => ot.Teatro)
                .WithMany()
                .HasForeignKey(ot => ot.IdTeatro)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación uno a muchos entre Carrito y ObraTeatro
            modelBuilder.Entity<Carrito>()
                .HasOne(c => c.ObraTeatro)
                .WithMany()
                .HasForeignKey(c => c.IdObraTeatro)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación uno a muchos entre Carrito y Asiento
            modelBuilder.Entity<Carrito>()
                .HasOne(c => c.Asiento)
                .WithMany()
                .HasForeignKey(c => c.IdAsiento)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a muchos entre Carrito y Usuario
            modelBuilder.Entity<Carrito>()
                .HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
