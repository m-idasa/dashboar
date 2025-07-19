namespace domain.Table;

public class AspNetUser
{
    public int Id { set; get; }
    public string CompanyName { get; set; }
    public string? ManagerName { get; set; }
    public string? NationalCode { get; set; }
    public string UserName { get; set; }
    public string NormalizedUserName { get; set; }
    public string Email { get; set; }
    public string  NormalizedEmail { get; set; }
    public Boolean EmailConfirmed { get; set; }
    public string PasswordHash { get; set; }
    public string SecurityStamp { get; set; }
    public string ConcurrencyStamp { get; set; }
    public string? PhoneNumber { get; set; }
    public Boolean? PhoneNumberConfirmed { get; set; }
    public Boolean TwoFactorEnabled { get; set; }
    public DateTimeOffset? LockoutEnd { get; set; }
    public Boolean? LockoutEnabled { get; set; }
    public int AccessFailedCount { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public Boolean IsActive { get; set; }
    public string? TechnicalInterFaceName { get; set; }
    public string? TechnicalInterFaceMobile { get; set; }
    public DateTime? RegisterDate { get; set; }
    public DateOnly ExpireDate { get; set; }
    public Boolean ToExpire { get; set; }
    public int InsertUser { get; set; }
    public DateTime? InsertDate { get; set; }
    public string? Ip { get; set; }
}
