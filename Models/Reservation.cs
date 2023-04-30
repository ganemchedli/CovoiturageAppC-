using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace covoituragecodefirst.Models
{
   
    public class Reservation
    {
      
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _nombrePlacesReservees;
        public int NombrePlacesReservees
        {
            get { return _nombrePlacesReservees; }
            set { _nombrePlacesReservees = value; }
        }

        private double _montantAPayer;
        public double MontantAPayer
        {
            get { return _montantAPayer; }
            set { _montantAPayer = value; }
        }

        private Passager? _passager;
        public Passager Passager
        {
            get { return _passager ?? (_passager = new Passager());}
            set { _passager = value; }
        }

        private Trajet? _trajet;
        public Trajet Trajet
        {
            get { return _trajet ?? (_trajet = new Trajet()); } 
            set { _trajet = value; }
        }


        public Reservation(double montatnAPayer, Passager passager, Trajet trajet, int nombrePlacesReservees)
        {
            this.Passager = passager;
            this.MontantAPayer = montatnAPayer;
            this.Trajet = trajet;
            this.NombrePlacesReservees = nombrePlacesReservees;


        }
    }
}
