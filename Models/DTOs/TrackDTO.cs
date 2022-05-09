using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using NaTour2021_API.Utils;

namespace NaTour2021_API.Models.DTOs
{
    public class TrackDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        [JsonConverter(typeof(JsonTimestampConverter))]
        public TimeSpan Duration { get; set; }
        [Required]
        public int Difficulty { get; set; }
        public bool Accessibility { get; set; }
        [Required]
        public double StartingPointLat { get; set; }
        [Required]
        public double StartingPointLng { get; set; }
        [Required]
        public double FinishPointLat { get; set; }
        [Required]
        public double FinishPointLng { get; set; }
        public List<PointOfInterestDTO> pois { get; set; }

    }
}
