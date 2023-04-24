using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace covoituragecodefirst.Models
{
    [Table("regions")]
    public class Region
    {
        [Key]
        private int _id;
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

        private string _codePostale;
        public string CodePostale
        {
            get { return _codePostale; }
            set { _codePostale = value; }
        }

    }
}
