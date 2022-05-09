namespace NaTour2021_API.Models
{
    public enum POIType
    {
        sorgente, punto_panoramico, area_picnic, baita, flora, grotte, luogo_artistico, altro
    }

    public class PointOfInterestModel
    {
        public Guid Id { get; set; }
        public POIType PoiType { get; set; }
        public string Name { get; set; }
        public double LocationLat { get; set; }
        public double LocationLng { get; set; }
        public Guid TrackId { get; set; }

        public TrackModel Track { get; set; }


    }
}
