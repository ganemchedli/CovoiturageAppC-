namespace covoituragecodefirst.Models
{
    public class Passager : User
    {
        private ICollection<Reservation> _reservations;
        public virtual ICollection<Reservation> Reservations
        {
            get { return _reservations ?? (_reservations = new List<Reservation>()); }
            set { _reservations = value; }
        }

        public Passager(int id, string nom, string prenom, int cin, int tel, string login, string password, ICollection<Reservation> reservations) : base(id, nom, prenom, cin, tel, login, password)
        {
            Reservations = reservations ;
        }

    }
}
