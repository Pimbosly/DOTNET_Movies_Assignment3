using System.ComponentModel.DataAnnotations;

namespace Csharp_WebAPI_Assignment3.Models
{
    public class Movie
    {
        //contains many characters (1 to many)
        //belongs to 1 franchise (1 to many)
        public int Id { get; set; }
        [MaxLength(50)] public string? Title { get; set; }
        [MaxLength(50)] public string? Genre { get; set; }
        public DateTime ReleaseYear { get; set; }
        [MaxLength(50)] public string? Director { get; set; }
        [MaxLength(50)] public string? Picture { get; set; }
        [MaxLength(50)] public string? Trailer { get; set; }
        //foreign keys
        public int CharacterId { get; set; }
        public Character? Character { get; set; }
        public int FranchiseId { get; set; }
        public Franchise? Franchise { get; set; }
    }
}
