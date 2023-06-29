namespace Contracts;

public class WeatherForecastDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
    
    public string? City { get; set; }
    public DateTime CreationDate { get; set; }
    
    public int AuthorId { get; set; }
}