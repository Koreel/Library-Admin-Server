namespace AdminAPI.Models;
public readonly record struct Credentials(string Username, string PasswordHash);

public readonly record struct PersonalDetails(string FirstName, string LastName, string Email);

public record User(Credentials Credentials, PersonalDetails PersonalDetails, string Roles);
