using covoituragecodefirst.Models;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore; 

namespace covoituragecodefirst.persistence
{
    public class Context :DbContext
    {
      public Context() { }
        
        public DbSet<User> Users { get; set; }  

       /* public DbSet<Conducteur> Conducteurs { get; set; } = null;
        public DbSet<Passager> Passagers { get; set; } = null;
        */
        public DbSet<Region> Regions { get; set; } 
        public DbSet<Trajet> Trajets { get; set; } 
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configurer la chaîne de connexion à votre base de données
            optionsBuilder.UseMySQL("mysql://root:root@localhost:3306/carpooling");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurer la table "Users"
        modelBuilder.Entity<User>()
                .ToTable("Users", schema: "carpooling")
            .HasDiscriminator<string>("UserType")
            .HasValue<User>("User")
            .HasValue<Passager>("Passager")
            .HasValue<Conducteur>("Conducteur");

        /*Configurer les classes filles Passager et Conducteur
        modelBuilder.Entity<Passager>();
        modelBuilder.Entity<Conducteur>(); */

           // Configurer la relation entre Reservation et Passager
             modelBuilder.Entity<Reservation>()
            .ToTable("Reservations", schema: "carpooling")
            .HasOne(r => r.Passager)
            .WithMany(p => p.Reservations)
            .HasForeignKey(r => r.Passager.Id);

            // Configurer la relation entre Trajet et Conducteur
        modelBuilder.Entity<Trajet>()
            .ToTable("Trajets", schema: "carpooling")
            .HasOne(t => t.CreateurDuTrajet)
            .WithMany(t => t.Trajets)
            .HasForeignKey(t => t.CreateurDuTrajet.Id);

             // Configurer la relation entre Trajet et Reservation
        modelBuilder.Entity<Trajet>()
            .HasMany(t => t.Reservations)
            .WithOne(r => r.Trajet)
            .HasForeignKey(r => r.Trajet.Id);


        base.OnModelCreating(modelBuilder);
    }

    }
}
