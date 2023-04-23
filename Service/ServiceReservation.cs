using covoituragecodefirst.Models;
using Microsoft.EntityFrameworkCore;
using covoituragecodefirst.persistence;
namespace covoituragecodefirst.Service
{
    public class ServiceReservation
    {
        private readonly Context _dbContext; // Remplacez "MyDbContext" par le nom de votre classe de contexte

        public ServiceReservation(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public Reservation GetReservationById(int id)
        {

            return _dbContext.Reservations.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _dbContext.Reservations.ToList();
        }

        public void AddReservation(Reservation reservation)
        {
            _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();
        }

        public void UpdateReservation(Reservation reservation)
        {
            _dbContext.Reservations.Update(reservation);
            _dbContext.SaveChanges();
        }

        public void DeleteReservation(Reservation reservation)
        {
            _dbContext.Reservations.Remove(reservation);
            _dbContext.SaveChanges();
        }
    }
}
