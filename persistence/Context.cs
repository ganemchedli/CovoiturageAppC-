using covoituragecodefirst.Models;
using Microsoft.EntityFrameworkCore;

namespace covoituragecodefirst.persistence
{
    public class Context :DbContext
    {
      public Context() { }
        
        public DbSet<User> Users { get; set; }  

       /* public DbSet<Conducteur> Conducteurs { get; set; } = null;
        public DbSet<Passager> Passagers { get; set; } = null;
        */
        public DbSet<Region> Regions { get; set; } = null;
        public DbSet<Trajet> Trajets { get; set; } = null;
        public DbSet<Reservation> Reservations { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configurer la chaîne de connexion à votre base de données
            optionsBuilder.UseMySQL("mysql://localhost:3360/covoiturage");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurer la table "Users"
        modelBuilder.Entity<User>()
            .ToTable("Users")
            .HasDiscriminator<int>("UserType")
            .HasValue<Passager>(1)
            .HasValue<Conducteur>(2);

        // Configurer les classes filles Passager et Conducteur
        modelBuilder.Entity<Passager>();
        modelBuilder.Entity<Conducteur>();

           // Configurer la relation entre Reservation et Passager
             modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Passager)
            .WithMany(p => p.Reservations)
            .HasForeignKey(r => r.PassagerId);

            // Configurer la relation entre Trajet et Conducteur
        modelBuilder.Entity<Trajet>()
            .HasOne(t => t.Conducteur)
            .WithMany(c => c.Trajets)
            .HasForeignKey(t => t.ConducteurId);

             // Configurer la relation entre Trajet et Reservation
        modelBuilder.Entity<Trajet>()
            .HasMany(t => t.Reservations)
            .WithOne(r => r.Trajet)
            .HasForeignKey(r => r.TrajetId);


        base.OnModelCreating(modelBuilder);
    }

    }
}
