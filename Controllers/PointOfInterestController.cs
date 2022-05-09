using Microsoft.AspNetCore.Mvc;
using NaTour2021_API.Models;
using NaTour2021_API.Models.DTOs;
using NaTour2021_API.Repositories.PointOfInterest;
using NaTour2021_API.Extensions;

namespace NaTour2021_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointOfInterestController : ControllerBase
    {

        private readonly IPointOfInterestRepository repository;

        public PointOfInterestController(IPointOfInterestRepository repository)
        {
            this.repository = repository;
        }

        // GET api/<TrackController>/5
        [HttpGet]
        public IEnumerable<PointOfInterestDTO> GetPOIs(Guid trackID)
        {
            IEnumerable<PointOfInterestModel> poiModels = repository.GetAll(trackID);
            List<PointOfInterestDTO> poisToReturn = new List<PointOfInterestDTO>();

            foreach(PointOfInterestModel poi in poiModels)
            {
                poisToReturn.Add(poi.AsDTO());
            }

            return poisToReturn;
        }

        // POST api/<TrackController>
        [HttpPost]
        public void AddPoi([FromBody] PointOfInterestDTO poi)
        {
            repository.AddPointOfInterest(poi);
        }

    }
}
