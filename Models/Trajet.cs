namespace covoituragecodefirst.Models
{
    public class Trajet
    {
        public int Id { get; set; }

        // Propriété du nombre de places disponibles
        public int NombrePlacesDisponibles { get; set; }

        // Propriété de la date de départ
        public DateTime DateDepart { get; set; }

        // Propriété du prix d'une place
        public decimal PrixPlace { get; set; }

        // Propriété de la région de départ
        public Region RegionDepart { get; set; }

        // Propriété de la région d'arrivée
        public Region RegionArrivee { get; set; }

        // liste des réservation dans un trajet 
        private List<Reservation> reservations = new List<Reservation>();

        public Conducteur createurdutrajet { get; set; }

        public Trajet( int nombrePlacesDisponibles, DateTime dateDepart, decimal prixPlace, Region regionDepart, Region regionArrivee, Conducteur createurDuTrajet)
        {
           
            NombrePlacesDisponibles = nombrePlacesDisponibles;
            DateDepart = dateDepart;
            PrixPlace = prixPlace;
            RegionDepart = regionDepart;
            RegionArrivee = regionArrivee;
            createurdutrajet = createurDuTrajet;
        }
    }
}
