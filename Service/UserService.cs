using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using covoituragecodefirst.Models;
using covoituragecodefirst.persistence;
using Microsoft.EntityFrameworkCore;
using  covoituragecodefirst.Models;

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
            _context.Conducteurs.Add(conducteur); // Ajouter un nouvel conducteur à la base de données
            _context.SaveChanges(); // Enregistrer les changements dans la base de données
        }

        public void AddPasssager(Passager passager)
        {
            _context.Passagers.Add(passager); // Ajouter un nouvel passager à la base de données
            _context.SaveChanges(); // Enregistrer les changements dans la base de données 

       
      //mise à jour des comptes personnes 

        public void UpdateConducteur(Conducteur conducteur)
        {
            var cond = _context.Conducteurs.Find(conducteur.Id);
            if (cond != null)
            {
                _context.Conducteurs.Update(cond); // Mettre à jour les informations d'un utilisateur dans la base de données
                _context.SaveChanges(); // Enregistrer les changements dans la base de données

            }
            else
            {
                Console.WriteLine("conducteur n existe pas !!");
            }


        }

        public void UpdatePassager(Passager passager)
        {
            var pass = _context.Conducteurs.Find(passager.Id);
            if (pass != null)
            {
                _context.Conducteurs.Update(pass); // Mettre à jour les informations d'un utilisateur dans la base de données
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
            _context.Conducteurs.Remove(conducteur); // Supprimer un utilisateur de la base de données
            _context.SaveChanges(); // Enregistrer les changements dans la base de données
        }

        public void DeletePassager(Passager passager)
        {
            _context.Passagers.Remove(passager); // Supprimer un utilisateur de la base de données
            _context.SaveChanges(); // Enregistrer les changements dans la base de données 


        // un passager peut réserver un trajet 
        public void ReserverTrajet(Passager Passager, Trajet trajet, int nbreplaces)
        {
            if (nbreplaces < trajet.NombrePlacesDisponibles)
            {

                {
                    // Créer une nouvelle réservation avec le passager et le trajet
                    Reservation reservation = new Reservation(Passager, trajet, nbreplaces);

                    // Ajouter la réservation à la collection de réservations dans la classe User
                    Passager.reservations.Add(reservation);


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
            var passager = _context.Passagers.Find(passagerId);
            if (passager != null)
            {
                var reservations = _context.Reservations
                    .Where(r => r.passager.Id == passagerId)
                    .ToList();
                return reservations;
            }
            else
            {
                // Gérer le cas où le passager n'est pas trouvé
                // Par exemple, retourner une liste vide ou lever une exception
                return new List<Reservation>();
                Console.WriteLine("passager n existe pas !");
            }

        }

        // une methode qui returne la liste des trajets crée par un conducteur 
        public List<Trajet> GetTrajetsByConducteurId(int conducteurId)
        {
            var conducteur = _context.Conducteurs.Find(conducteurId);
            if (conducteur != null)
            {
                var trajets = _context.Trajets
                    .Where(t => t.createurdutrajet.Id == conducteurId)
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
            Passager passager = _context.Passagers.FirstOrDefault(p => p.Id == idPassager);

            if (passager != null)
            {
                // Rechercher la réservation dans la liste des réservations du passager
                Reservation reservation = passager.reservations.FirstOrDefault(r => r.Id == idReservation);

                if (reservation != null)
                {
                    // Supprimer la réservation de la liste des réservations du passager
                    passager.reservations.Remove(reservation);

                    // Enregistrer les modifications dans la base de données ou dans la liste des passagers
                    _context.SaveChanges(); 
                }
            }
        }


        // fonction qui supprime un trajet 
        public void SupprimerTrajet(int idConducteur, int idTrajet)
        {
            // Rechercher le conducteur dans la base de données ou dans la liste des conducteurs
            Conducteur conducteur = _context.Conducteurs.FirstOrDefault(c => c.Id == idConducteur);

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

    }




}