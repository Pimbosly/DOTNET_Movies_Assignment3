using System.ComponentModel.DataAnnotations;

namespace Csharp_WebAPI_Assignment3.DTOs.MovieDTOs
{
    public class MovieCreateDTO
    {
        [MaxLength(50)] public string? Title { get; set; }
        //no genre for createdto
        public DateTime ReleaseYear { get; set; }
        [MaxLength(50)] public string? Director { get; set; }
        [MaxLength(50)] public string? Picture { get; set; }
        [MaxLength(50)] public string? Trailer { get; set; }
        //foreign keys
        public int CharacterId { get; set; }
        public int FranchiseId { get; set; }
    }
}
