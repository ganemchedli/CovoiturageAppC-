using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace covoituragecodefirst.Models
{
    [Table("trajets")] 
    public class Trajet
    {
        [Key]
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _nombrePlacesDisponibles;
        public int NombrePlacesDisponibles
        {
            get { return _nombrePlacesDisponibles; }
            set { _nombrePlacesDisponibles = value; }
        }

        private DateTime _dateDepart;
        public DateTime DateDepart
        {
            get { return _dateDepart; }
            set { _dateDepart = value; }
        }

        private decimal _prixPlace;
        public decimal PrixPlace
        {
            get { return _prixPlace; }
            set { _prixPlace = value; }
        }

        private Region? _regionDepart;
        public Region? RegionDepart
        {
            get { return _regionDepart; }
            set { _regionDepart = value; }
        }

        private Region? _regionArrivee;
        public Region? RegionArrivee
        {
            get { return _regionArrivee; }
            set { _regionArrivee = value; }
        }

        private List<Reservation>? _reservations;
        public List<Reservation> Reservations
        {
            get { return _reservations ?? (_reservations = new List<Reservation>()); }
            set { _reservations = value; }
        }

        private Conducteur? _createurDuTrajet;
        public Conducteur? CreateurDuTrajet
        {
            get { return _createurDuTrajet; }
            set { _createurDuTrajet = value; }
        }

        public Trajet(){}
        public Trajet( int nombrePlacesDisponibles, DateTime dateDepart, decimal prixPlace, Region regionDepart, Region regionArrivee, Conducteur createurDuTrajet)
        {
           
            NombrePlacesDisponibles = nombrePlacesDisponibles;
            DateDepart = dateDepart;
            PrixPlace = prixPlace;
            RegionDepart = regionDepart;
            RegionArrivee = regionArrivee;
            CreateurDuTrajet = createurDuTrajet;
        }
    }
}
