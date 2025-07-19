namespace domain.Dto;

public class TotalResponseDto
{
    public long? TotalRequest { get; set; }
    public long? TotalResponse { get; set; }
    public string? AverageWaitingTime { get; set; }
    public int? FaildResponse { get; set; }
}
