namespace Program;

public static class DisplayEvent
{
    public static void Push(GitUser gitUser)
    {
        if (gitUser.Payload == null || gitUser.Repo == null)
        {
            return;
        }
        string commitW = (gitUser.Payload.Size == 1) ? "commit" : "commits";
        Console.WriteLine($"Pushed {gitUser.Payload.Size} {commitW} to {gitUser.Repo.Name}");
    }

    public static void Create(GitUser gitUser)
    {
        if (gitUser.Repo == null)
            return;
        Console.WriteLine($"Created new repo {gitUser.Repo.Name}");

    }

    public static void Pull(GitUser gitUser)
    {

    }
}
