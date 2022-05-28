using System.ComponentModel.DataAnnotations;

namespace Csharp_WebAPI_Assignment3.DTOs.MovieDTOs
{
    public class MovieReadDTO
    {
        public int Id { get; set; }
        [MaxLength(50)] public string? Title { get; set; }
        [MaxLength(50)] public string? Genre { get; set; }
        //no releasedate for readdto
        [MaxLength(50)] public string? Director { get; set; }
        [MaxLength(50)] public string? Picture { get; set; }
        [MaxLength(50)] public string? Trailer { get; set; }
    }
}
