namespace covoituragecodefirst.Models
{
    [Table("Users")]
    public class Conducteur : User
    {
        // chaque conducteur spécifiée par la liste des trajets li zedhom
        private ICollection<Trajet> _trajets;
        public virtual  ICollection<Trajet> Trajets
        {
            get { return _trajets ?? (_trajets = new List<Trajet>()); }
            set { _trajets = value; }
        }
        public Conducteur(int id, string nom, string prenom, int cin, int tel, string login, string password, ICollection<Trajet> trajets) : base(id, nom, prenom, cin, tel, login, password)
        {
            Trajets = trajets;
        }
    }
}
