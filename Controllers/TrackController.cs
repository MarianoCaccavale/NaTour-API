using Microsoft.AspNetCore.Mvc;
using NaTour2021_API.DBHelper;
using NaTour2021_API.Extensions;
using NaTour2021_API.Models;
using NaTour2021_API.Models.DTOs;
using NaTour2021_API.Repositories.Track;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NaTour2021_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {

        private readonly ITrackRepository repository;

        public TrackController(ITrackRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/get_recent_tracks
        [HttpGet]
        public IEnumerable<TrackDTO> GetRecentTracks()
        {
            IEnumerable<TrackModel> tracksModel = repository.GetRecentTracks();

            List<TrackDTO> tracksToReturn = new List<TrackDTO>();
            foreach (TrackModel track in tracksModel)
            {
                tracksToReturn.Add(track.AsDTO());
            }

            //todo eventuale ritorno di lista nulla

            return tracksToReturn;
        }

        // GET api/<TrackController>/5
        [HttpGet("{id}")]
        public TrackDTO Get(Guid id)
        {
            TrackModel trackModel = repository.GetById(id);
            return trackModel.AsDTO();
        }

        // POST api/<TrackController>
        [HttpPost]
        public void Post([FromBody] TrackDTO trackInfo)
        {

            repository.AddTrack(trackInfo);

        }
    }
}
