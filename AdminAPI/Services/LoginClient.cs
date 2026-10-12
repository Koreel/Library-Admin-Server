using System.Net;
using System.Net.Http.Headers;
using System.Text;
using AdminAPI.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace AdminAPI.Services;

public class LoginClient(string username, string password, HttpClient httpClient)
{
    public async Task<bool> Login()
    {
        const string loginUrl = "https://localhost:4200/login";

        // Form data
        var formData = new Dictionary<string, string>
        {
            { "username", username },
            { "password", password }
        };
        
        using var content = new FormUrlEncodedContent(formData);
        
        // Basic Authentication header
        var credentials = $"{username}:{password}";
        var encodedCredentials =
            Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
        
        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic", encodedCredentials);
        HttpResponseMessage response =
            await httpClient.PostAsync(loginUrl, content);
        string responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Login successful");
            return true;
        }

        Console.WriteLine("Login Failed");
        Console.WriteLine(responseBody);
        return false;

    }
}