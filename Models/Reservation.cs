namespace covoituragecodefirst.Models
{
    public class Reservation
    {

        public int Id { get; set; }
        public int NombrePlacesReservees { get; set; }
        
        public double MontantAPayer { get; set; }
        public User Utilisateur { get; set; }
        public Trajet Trajet { get; set; }

        public Reservation(User user, Trajet trajet, int nombrePlaces)
        {
            Utilisateur = user;
            Trajet = trajet;
            NombrePlacesReservees = nombrePlaces;
           
           
        }
    }
}
