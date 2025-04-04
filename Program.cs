// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Net.Http.Headers;
using System.Collections;

namespace Program;

public class Program
{
    static void Main(string[] args)
    {
        GithubActivity githa = new();
        if (args.Length == 0)
        {
            Console.WriteLine("requires one argument <github-username>");
            return;
        }
        githa.GetActivity(args[0]);
    }
}

class GithubActivity
{
    readonly JsonSerializerOptions jsonOptions = new(){ PropertyNameCaseInsensitive = true };

    public void GetActivity(string username)
    {
        string url = $"https://api.github.com/users/{username}/events";
        ApiHandler api = new () { Url = url };
        HttpResponseMessage response = api.SendRequest(); 
        if ((int)response.StatusCode == 404) //status NotFound
        {
            Console.WriteLine($"The github username {username} does not exists");
            return;
        }

        StreamReader reader = new(response.Content.ReadAsStream());
        string content = reader.ReadToEnd();
        var jsonContent = JsonSerializer.Deserialize<List<GitUser>>(content, jsonOptions);

        if (jsonContent == null)
        {
            Console.WriteLine("jsonContent is null");
            return;
        }
        for (int i = 0; i < jsonContent.Count; i++)
        {
            GitUser gitUser = jsonContent[i];
            if (gitUser.Payload == null || gitUser.Repo == null)
                continue;
            switch (gitUser.Type)
            {
                case "PushEvent":
                    DisplayEvent.Push(gitUser);
                    break;
                case "CreateEvent":
                    DisplayEvent.Create(gitUser);
                    break;
                default:
                    Console.WriteLine(gitUser.Type);
                    break;
            }
        }
    }
}
