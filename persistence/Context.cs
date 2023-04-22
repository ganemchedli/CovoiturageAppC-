using covoituragecodefirst.Models;
using Microsoft.EntityFrameworkCore;

namespace covoituragecodefirst.persistence
{
    public class Context :DbContext
    {
      public Context() { }

        public DbSet<Conducteur> Conducteurs { get; set; } = null;
        public DbSet<Passager> Passagers { get; set; } = null;
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
            // Définir les configurations de modèles d'entités, les relations, les clés primaires, etc.
            // si nécessaire
        }

    }
}
