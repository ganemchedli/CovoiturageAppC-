namespace covoituragecodefirst.Models
{
    public class Conducteur : User
    {
        // chaque conducteur spécifiée par la liste des trajets li zedhom
        public virtual ICollection<Trajet> Trajets { get; set; }
        public Conducteur(int id, string nom, string prenom, int cin, int tel, string login, string password) : base(id , nom , prenom, cin, tel,login,password)
        {
            Trajets = new List<Trajet>();
        }


    }
}
