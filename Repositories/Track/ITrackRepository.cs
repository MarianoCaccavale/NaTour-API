using NaTour2021_API.Models;
using NaTour2021_API.Models.DTOs;

namespace NaTour2021_API.Repositories.Track
{
    public interface ITrackRepository
    {

        public TrackModel GetById(Guid id);

        public IEnumerable<TrackModel> GetRecentTracks();

        public void AddTrack(TrackDTO trackInfo);

        public TrackModel GetTrackByName(string name);
    }
}
