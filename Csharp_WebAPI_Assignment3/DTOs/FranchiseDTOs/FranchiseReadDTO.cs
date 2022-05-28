using System.ComponentModel.DataAnnotations;

namespace Csharp_WebAPI_Assignment3.DTOs.FranchiseDTOs
{
    public class FranchiseReadDTO
    {
        public int Id { get; set; }
        [MaxLength(50)] public string? Name { get; set; }
        [MaxLength(50)] public string? Description { get; set; }
    }
}
