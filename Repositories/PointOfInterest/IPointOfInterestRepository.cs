using NaTour2021_API.Models;
using NaTour2021_API.Models.DTOs;

namespace NaTour2021_API.Repositories.PointOfInterest
{
    public interface IPointOfInterestRepository
    {

        public void AddPointOfInterest(PointOfInterestDTO pointOfInterest);

        public List<PointOfInterestModel> GetAll(Guid trackId);

    }
}
