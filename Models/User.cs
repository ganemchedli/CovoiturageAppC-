namespace covoituragecodefirst.Models
{
    public class User
    {

        public int Id { get; set; }

        // Propriété de nom
        public string Nom { get; set; }

        // Propriété de prénom
        public string Prenom { get; set; }
        public int Cin { get; set; }
        public int Tel { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        // Liste pour stocker les réservations
        public List<Reservation> reservations = new List<Reservation>();
    }
}
