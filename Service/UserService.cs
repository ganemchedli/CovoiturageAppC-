using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using covoituragecodefirst.Models;
using covoituragecodefirst.persistence;
using Microsoft.EntityFrameworkCore;

namespace covoituragecodefirst.Service

{
    public class UserService
    {
        private Context _context;

        public UserService(Context dbContext)
        {
            _context = dbContext;
        }
        //Ajout des personnes 
        public void AddConducteur(Conducteur conducteur)
        {
            _context.Users.Add(conducteur); // Ajouter un nouvel conducteur à la base de données
            _context.SaveChanges(); // Enregistrer les changements dans la base de données
        }

        public void AddPasssager(Passager passager)
        {
            _context.Users.Add(passager); // Ajouter un nouvel passager à la base de données
            _context.SaveChanges(); // Enregistrer les changements dans la base de données 
        }
       
      //mise à jour des comptes personnes 

        public  void UpdateConducteur(Conducteur conducteur)
        {
            var cond = _context.Users.Find(conducteur.Id);
            if (cond != null)
            {
                _context.Users.Update(cond); // Mettre à jour les informations d'un utilisateur dans la base de données
                _context.SaveChanges(); // Enregistrer les changements dans la base de données

            }
            else
            {
                Console.WriteLine("conducteur n existe pas !!");
            }


        }

        public void UpdatePassager(Passager passager)
        {
            var pass = _context.Users.Find(passager.Id);
            if (pass != null)
            {
                _context.Users.Update(pass); // Mettre à jour les informations d'un utilisateur dans la base de données
                _context.SaveChanges(); // Enregistrer les changements dans la base de données

            }
            else
            {
                Console.WriteLine("conducteur n existe pas !!");
            }


        }

       //supprimer un user
        public void DeleteConducteur(Conducteur conducteur)
        {
            // Supprimer un utilisateur de la base de données
            _context.Users.Remove(conducteur); 
            // Enregistrer les changements dans la base de données
            _context.SaveChanges();         }

        public void DeletePassager(Passager passager)
        {
            // Supprimer un utilisateur de la base de données
            _context.Users.Remove(passager);
            // Enregistrer les changements dans la base de données 
            _context.SaveChanges(); 

        }
        // un passager peut réserver un trajet 
        public void ReserverTrajet(double monttantAPayer , Passager Passager, Trajet trajet, int nbreplaces)
        {
            if (nbreplaces <= GetNombrePlacesRestantes( trajet.Id))
            {

                {
                    // Créer une nouvelle réservation avec le passager et le trajet
                    Reservation reservation = new Reservation(monttantAPayer, Passager, trajet, nbreplaces);

                    // Ajouter la réservation à la collection de réservations dans la classe User
                    Passager.Reservations.Add(reservation);


                    // Ajouter la réservation à la table Reservations dans la base de données
                    _context.Reservations.Add(reservation);
                    
                  
                    // Enregistrer les changements dans la base de données
                    _context.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("le nombre des places est insiffusant !");
            }



        }

        // un conducteur peut ajouter un trajet 
        public void AjouterTrajet(Conducteur conducteur , DateTime datedepart, int nbredeplaces , decimal prixplace, Region regionDepart , Region regionArrive)

        {
            Trajet nouvtrajet = new Trajet(nbredeplaces, datedepart, prixplace, regionDepart, regionArrive, conducteur);

            //ajouter le trajet à la collection des trajets du conducteur (kol conducteur ando une collection des trajets li créehom)
            conducteur.Trajets.Add(nouvtrajet);

            // ajout du trajet à la table trajets de la base de donnée
            _context.Trajets.Add(nouvtrajet);

        }

        // une methode returne la liste des reservations d'un passager donné !
        public List<Reservation> GetReservationsById(int passagerId)
        {
            var passager = _context.Users.Find(passagerId);
            if (passager != null)
            {
                var reservations = _context.Reservations
                    .Where(r => passager.Id == passagerId)
                    .ToList();
                return reservations;
            }
            else
            {
                // Gérer le cas où le passager n'est pas trouvé
                // Par exemple, retourner une liste vide ou lever une exception
                return new List<Reservation>();
                //Console.WriteLine("passager n existe pas !");
            }

        }

        // une methode qui returne la liste des trajets crée par un conducteur 
        public List<Trajet> GetTrajetsByConducteurId(int conducteurId)
        {
            var conducteur = _context.Users.Find(conducteurId);
            if (conducteur != null)
            {
                var trajets = _context.Trajets
                    .Where(t => conducteur.Id == conducteurId)
                    .ToList();
                return trajets;
            }
            else
            {
                // Gérer le cas où le conducteur n'est pas trouvé
                // Par exemple, retourner une liste vide ou lever une exception
                Console.WriteLine("Le conducteur n'existe pas !");
                return new List<Trajet>();
            }
        }

        // rechercher les trajets selon les regions de depart et d'arrivé et que date de depart n'a pas dépassé
        public List<Trajet> RechercherTrajet(Region lieuDepart, Region lieuArrivee)
        {
            var currentDate = DateTime.Now;
            var trajets = _context.Trajets
                .Where(t => t.RegionDepart == lieuDepart && t.RegionArrivee == lieuArrivee && t.DateDepart < currentDate)
                .ToList();
            return trajets;
        }

        // lezem fonction tfassa5li les trajets li date mteehhom a9al mil date actuelle 
        public void SupprimerTrajetsPasses()
        {
            var currentDate = DateTime.Now;
            var trajetsASupprimer = _context.Trajets
                .Where(t => t.DateDepart < currentDate)
                .ToList();

            foreach (var trajet in trajetsASupprimer)
            {
                _context.Trajets.Remove(trajet);
            }

            _context.SaveChanges();
        }
   // fonction qui supprime une reservation, si un passager veut annuler sa resevation

        public void SupprimerReservation(int idPassager, int idReservation)
        {
        // Rechercher le passager dans la base de données ou dans la liste des passagers
            Passager passager = (Passager)_context.Users.FirstOrDefault(p => p.Id == idPassager);

            if (passager != null)
            {
                // Rechercher la réservation dans la liste des réservations du passager
                Reservation reservation = passager.Reservations.FirstOrDefault(r => r.Id == idReservation);

                if (reservation != null)
                {
                    // Supprimer la réservation de la liste des réservations du passager
                    passager.Reservations.Remove(reservation);

                    // Enregistrer les modifications dans la base de données ou dans la liste des passagers
                    _context.SaveChanges(); 
                }
            }
        }


        // fonction qui supprime un trajet 
        public void SupprimerTrajet(int idConducteur, int idTrajet)
        {
            // Rechercher le conducteur dans la base de données ou dans la liste des conducteurs
            Conducteur conducteur = (Conducteur)_context.Users.FirstOrDefault(c => c.Id == idConducteur);

            if (conducteur != null)
            {
                // Rechercher le trajet dans la liste des trajets du conducteur
                Trajet trajet = conducteur.Trajets.FirstOrDefault(t => t.Id == idTrajet);

                if (trajet != null)
                {
                    // Supprimer le trajet de la liste des trajets du conducteur
                    conducteur.Trajets.Remove(trajet);

                    // Enregistrer les modifications dans la base de données ou dans la liste des conducteurs
                    _context.SaveChanges(); 
                }
            }
        }

        /*
        public bool AuthenticatePassager(string login, string password)
        {
            var user = _context.Passagers.SingleOrDefault(p => p.Login == login && p.Password == password);

            if (user == null)
            {
                // Passager not found or incorrect password
                return false;
            }
            else
            {
                // Passager found and password is correct
                return true;
            }
        }

        public bool AuthenticateConducteru(string login, string password)
        {
            var user = _context.Conducteurs.SingleOrDefault(p => p.Login == login && p.Password == password);

            if (user == null)
            {
                // Conduteur not found or incorrect password
                return false;
            }
            else
            {
                // Conduteur found and password is correct
                return true;
            }
        }
        */


         public bool AuthenticateUser(string login, string password)
        {
            User user = _context.Users.SingleOrDefault(u => u.Login == login && u.Password == password);

            if (user == null)
            {
                // user not found or incorrect password or login !
                return false;
            }
            else
            {
                // user found and password and login is correct
                return true;
            }
        }

        // une méthode returne la liste des réservations dans un trajet donné !

         public List<Reservation> GetReservationsByTrajetId(int trajetId)
        {
            // Utiliser LINQ pour interroger la base de données et récupérer les réservations
            var reservations = _context.Reservations
                .Where(r => r.Trajet.Id == trajetId)
                .ToList();

            return reservations;
        }

      
       // une methode returne le nombre des places reservée dans un trajet données 

     public int GetNombrePlacesReservees(int trajetId)
        {
            // Récupérer le trajet correspondant à l'ID donné
            var trajet = _context.Trajets.Find(trajetId);

            if (trajet != null)
            {
                // Parcourir la liste des réservations associées au trajet donné
                int nombrePlacesReservees = 0;
                foreach (var reservation in trajet.Reservations)
                {
                    // Ajouter le nombre de places réservées de cette réservation
                    nombrePlacesReservees += reservation.NombrePlacesReservees;
                }

                return nombrePlacesReservees;
            }
            else
            {
                // Trajet non trouvé, renvoyer une valeur par défaut ou générer une exception selon vos besoins
                return -1;
            }
        }

        //méthode returne le nombre des places restants dans un trajet
         public int GetNombrePlacesRestantes(int trajetId)
        {
            // Récupérer le nombre total de places dans le trajet
            var trajet = _context.Trajets.Find(trajetId);
            if (trajet != null)
            {
                int nombreTotalPlaces = trajet.NombrePlacesDisponibles;

                // Récupérer le nombre de places réservées dans le trajet
                int nombrePlacesReservees = GetNombrePlacesReservees(trajetId);

                // Calculer le nombre de places restantes
                int nombrePlacesRestantes = nombreTotalPlaces - nombrePlacesReservees;

                return nombrePlacesRestantes;
            }
            else
            {
                // Trajet non trouvé, renvoyer une valeur par défaut ou générer une exception selon vos besoins
                return -1;
            }
        }
       



    }




}