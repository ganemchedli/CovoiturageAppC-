namespace covoituragecodefirst.Models
{
    public class Reservation
    {

        public int Id { get; set; }
        public int NombrePlacesReservees { get; set; }
        
        public double MontantAPayer { get; set; }
        public Passager passager { get; set; }
        public Trajet Trajet { get; set; }

        public Reservation(Passager passager, Trajet trajet, int nombrePlaces)
        {
            passager = passager;
            Trajet = trajet;
            NombrePlacesReservees = nombrePlaces;
           
           
        }
    }
}
