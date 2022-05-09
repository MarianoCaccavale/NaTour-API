namespace NaTour2021_API.Models.DTOs
{
    public class PointOfInterestDTO
    {
        public POIType PoiType { get; set; }
        public string Name { get; set; }
        public double LocationLat { get; set; }
        public double LocationLng { get; set; }
        public Guid trackId { get; set; }
    }
}
