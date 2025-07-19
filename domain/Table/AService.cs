using System.ComponentModel.DataAnnotations;

namespace domain.Table;

public class AService
{
    [Key]
    public string ServiceName { get; set; }
    public int IntervalRequestMIN { get; set; }
    public int RoleId { get; set; }
    public Boolean IsActive { get; set; }
    public int BeforDay { get; set; }
    public string ServiceDesc { get; set; }
    public string PeriodTime { get; set; }
}
