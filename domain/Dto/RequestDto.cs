namespace domain.Dto;

public class RequestDto
{
    public string From { get; set; }
    public string To { get; set; }
    public required List<string> Services { get; set; }
    public required List<string> Clients { get; set; }
    public int? TimePeriod { get; set; }
}
