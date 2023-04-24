using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace covoituragecodefirst.Models
{
    [Table("Users")]
    //[Inheritance(strategy: InheritanceStrategy.SingleTable)]

    public class User
    {
        private int _id;
         [Key]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        private string _prenom;
        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        private int _cin;
        public int Cin
        {
            get { return _cin; }
            set { _cin = value; }
        }

        private int _tel;
        public int Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        private string _login;
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public User(int id, string nom, string prenom, int cin, int tel, string login, string password)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Cin = cin;
            Tel = tel;
            Login = login;
            Password = password;
        }

    }
}
