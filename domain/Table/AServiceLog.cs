namespace domain.Table;

public class AServiceLog
{
    public int Id { get; set; }
    public string AServiceName { get; set; }
    public string RequestData { get; set; }
    public string ResponeType { get; set; }
    public string ResponeData { get; set; }
    //public string ResponeStatus { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public float TotalMiliTime { get; set; }
    public int UserId { get; set; }
    public string Ip { get; set; }
}
