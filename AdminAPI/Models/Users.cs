namespace AdminAPI.Models;

// public class User
// {
//     public string? Username { get; set; }
//     public string? PasswordHash { get; set; }
//     
//     public string? FirstName { get; set; }
//     public string? LastName { get; set; }
//     public string? Email { get; set; }
//     
//     public string? Roles { get; set; }
// }

public readonly record struct Credentials(string Username, string PasswordHash);

public readonly record struct PersonalDetails(string FirstName, string LastName, string Email);

public record User(Credentials Credentials, PersonalDetails PersonalDetails, string Roles);
