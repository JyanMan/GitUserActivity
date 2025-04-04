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
    JsonSerializerOptions jsonOptions = new(){ PropertyNameCaseInsensitive = true };

    public void GetActivity(string username)
    {
        string url = $"https://api.github.com/users/{username}/events";
        ApiHandler api = new () { Url = url };
        HttpResponseMessage response = api.SendRequest(); 
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
                    DisplayPush(gitUser);
                    break;
                case "CreateEvent":
                    DisplayCreate(gitUser);
                    break;
                default:
                    Console.WriteLine(gitUser.Type);
                    break;
            }
        }
    }

    void DisplayPush(GitUser gitUser)
    {
        if (gitUser.Payload == null || gitUser.Repo == null)
        {
            return;
        }
        string commitW = (gitUser.Payload.Size == 1) ? "commit" : "commits";
        Console.WriteLine($"Pushed {gitUser.Payload.Size} {commitW} to {gitUser.Repo.Name}");
    }

    void DisplayCreate(GitUser gitUser)
    {
        if (gitUser.Repo == null)
            return;
        Console.WriteLine($"Created new repo {gitUser.Repo.Name}");

    }
}

