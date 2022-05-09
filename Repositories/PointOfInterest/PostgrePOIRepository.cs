using NaTour2021_API.DBHelper;
using NaTour2021_API.Models;
using NaTour2021_API.Models.DTOs;
using NaTour2021_API.Extensions;

namespace NaTour2021_API.Repositories.PointOfInterest
{
    public class PostgrePOIRepository : IPointOfInterestRepository
    {

        private readonly PostgreSqlHelper db;

        //Creazione del DBHelper con dependency injection. Sarebbe più efficace con un helper interfaccia, da considerare
        public PostgrePOIRepository(PostgreSqlHelper db)
        {
            this.db = db;
        }

        public void AddPointOfInterest(PointOfInterestDTO pointOfInterest)
        {
            PointOfInterestModel poiToAdd = pointOfInterest.FromDTO();
            db.pois.Add(poiToAdd);
            db.SaveChanges();
        }

        public List<PointOfInterestModel> GetAll(Guid trackId) => db.pois.Where(poi => poi.TrackId == trackId).ToList();
    }
}
