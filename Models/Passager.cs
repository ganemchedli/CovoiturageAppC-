namespace covoituragecodefirst.Models
{
    public class Passager : User
    {
        public virtual ICollection<Reservation> reservations { get; set; }
        public Passager(int id, string nom, string prenom, int cin, int tel, string login, string password) : base(id, nom, prenom, cin, tel, login, password)
        {
            reservations = new List<Reservation>();
        }

    }
}
