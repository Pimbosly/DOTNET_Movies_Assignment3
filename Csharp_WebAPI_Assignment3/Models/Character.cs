using System.ComponentModel.DataAnnotations;

namespace Csharp_WebAPI_Assignment3.Models
{
    public class Character
    {
        //can play in many movies
        public int Id { get; set; }
        [MaxLength(50)] public string? FullName { get; set; }
        [MaxLength(50)] public string? Alias { get; set; }

        //gender = man, woman, other....5 maxlength
        [MaxLength(5)] public string? Gender { get; set; }
        [MaxLength(50)] public string? Picture { get; set; }

        public ICollection<Movie>? Movies { get; set; }
    }
}
