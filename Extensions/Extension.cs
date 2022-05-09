using NaTour2021_API.Models;
using NaTour2021_API.Models.DTOs;

namespace NaTour2021_API.Extensions
{
    public static class TrackExtension
    {
        public static TrackDTO AsDTO(this TrackModel trackModel)
        {
            return new TrackDTO
            {
                Id = trackModel.Id,
                Name = trackModel.Name,
                Difficulty = trackModel.Difficulty,
                Accessibility = trackModel.Accessibility,
                Duration = trackModel.Duration,
                Description = trackModel.Description,
                StartingPointLat = trackModel.StartingPointLat,
                StartingPointLng = trackModel.StartingPointLng,
                FinishPointLat = trackModel.FinishPointLat,
                FinishPointLng = trackModel.FinishPointLng,
            };
        }

        public static TrackModel FromDTO(this TrackDTO trackDTO)
        {
            return new TrackModel
            {
                Id = Guid.NewGuid(),
                Name = trackDTO.Name,
                Difficulty = trackDTO.Difficulty,
                Duration = trackDTO.Duration,
                Accessibility = trackDTO.Accessibility,
                Description = trackDTO.Description,
                StartingPointLat = trackDTO.StartingPointLat,
                StartingPointLng = trackDTO.StartingPointLng,
                FinishPointLat = trackDTO.FinishPointLat,
                FinishPointLng = trackDTO.FinishPointLng,
                creationDate = DateTime.UtcNow,
            };
        }
    }

    public static class POIExstension
    {
        public static PointOfInterestDTO AsDTO(this PointOfInterestModel pointOfInterest)
        {
            return new PointOfInterestDTO
            {
                Name = pointOfInterest.Name,
                PoiType = pointOfInterest.PoiType,
                LocationLat = pointOfInterest.LocationLat,
                LocationLng = pointOfInterest.LocationLng,
                trackId = pointOfInterest.TrackId,

            };
        }

        public static PointOfInterestModel FromDTO(this PointOfInterestDTO pointOfInterest)
        {
            return new PointOfInterestModel
            {
                Id = Guid.NewGuid(),
                Name = pointOfInterest.Name,
                PoiType = pointOfInterest.PoiType,
                LocationLat = pointOfInterest.LocationLat,
                LocationLng = pointOfInterest.LocationLng,
                TrackId = pointOfInterest.trackId,
            };
        }
    }
}
