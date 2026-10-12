namespace AdminAPI.Models;

public class LoginRequestModel
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public int LoginAttempts { get; set; }
    public int LockedFlag  { get; set; }
}