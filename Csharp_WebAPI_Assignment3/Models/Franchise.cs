using System.ComponentModel.DataAnnotations;

namespace Csharp_WebAPI_Assignment3.Models
{
    public class Franchise
    {
        //can contain many movies
        public int Id { get; set; }
        [MaxLength(50)] public string? Name { get; set; }
        [MaxLength(50)] public string? Description { get; set; }
        
        public ICollection<Movie>? Movies { get; set; }
    }
}
