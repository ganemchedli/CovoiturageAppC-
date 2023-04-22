
using covoituragecodefirst.Models;
using covoituragecodefirst.persistence;
using Microsoft.EntityFrameworkCore;

namespace covoituragecodefirst.Service

{
    public class ServiceTrajet
    {
        private readonly Context _dbContext; // Remplacez "MyDbContext" par le nom de votre classe de contexte

        public ServiceTrajet(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public Trajet GetTrajetById(int id)
        {
            return _dbContext.Trajets.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Trajet> GetAllTrajets()
        {
            return _dbContext.Trajets.ToList();
        }

        public void AddTrajet(Trajet trajet)
        {
            _dbContext.Trajets.Add(trajet);
            _dbContext.SaveChanges();
        }

        public void UpdateTrajet(Trajet trajet)
        {
            _dbContext.Trajets.Update(trajet);
            _dbContext.SaveChanges();
        }

        public void DeleteTrajet(Trajet trajet)
        {
            _dbContext.Trajets.Remove(trajet);
            _dbContext.SaveChanges();
        }




    }
}
