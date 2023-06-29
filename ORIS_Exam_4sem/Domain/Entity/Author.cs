using System.ComponentModel.DataAnnotations;

namespace Domain.Entity;

public class Author
{
    public int Id { get; set; }
    
    [Required]
    public string? Name { get; set; }

}