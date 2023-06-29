using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity;

public class WeatherForecast
{
    public int Id { get; set; }
    public DateTime Date { get; set; }

    [Required]
    [Range(-100, 80)]
    public int TemperatureC { get; set; }
    
    [NotMapped]
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
    
    public string? City { get; set; }
    public DateTime CreationDate { get; set; }
    
    public int AuthorId { get; set; }
}