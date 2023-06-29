namespace ORIS_Exam_4sem.Models;

public class WeatherForecastVM
{
    public DateTime Date { get; set; }
    
    public int TemperatureC { get; set; }
    
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
    
    public string City { get; set; }
    public DateTime CreationDate { get; set; }
    
    public int AuthorId { get; set; }
}