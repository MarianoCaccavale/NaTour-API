using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NaTour2021_API.Models
{
    //Creo l'index della tabella, che si basa sulla colonna del nome. In questo modo posso fare query migliori cercando per
    //nome, e specifico che quella tabella deve essere unica
    [Index(nameof(Name), IsUnique = true)]
    public class TrackModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        [Required]
        [Range(0, 3)]
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
        [DataType(DataType.Date)]
        public DateTime creationDate { get; set; }
        public ICollection<PointOfInterestModel> pois { get; set; }

    }
}
