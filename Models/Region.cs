namespace covoituragecodefirst.Models
{
    public class Region
    {
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
