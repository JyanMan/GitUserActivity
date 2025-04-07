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
        if (gitUser.Repo == null)
            return;
        Console.WriteLine($"Pulled from {gitUser.Repo.Name}");
    }

    public static void Member(GitUser gitUser)
    {
        if (gitUser.Repo == null || gitUser.Payload == null || gitUser.Payload.Member == null)
            return;
        Console.WriteLine($"Added access to user {gitUser.Payload.Member.Login} to {gitUser.Repo.Name}");
    }

    public static void IssueComment(GitUser gitUser)
    {
        if (gitUser.Repo == null)
            return;
        Console.WriteLine($"Issued a comment on {gitUser.Repo.Name}");
    }

    public static void Issue(GitUser gitUser)
    {
        if (gitUser.Repo == null || gitUser.Payload == null)
            return;
        Console.WriteLine($"{gitUser.Payload.Action} an issue in {gitUser.Repo.Name}");
    }

    public static void Fork(GitUser gitUser)
    {

        if (gitUser.Payload == null || gitUser.Payload.Forkee == null || gitUser.Repo == null)
            return;
        Console.WriteLine($"Forked {gitUser.Repo.Name} to {gitUser.Payload.Forkee.Full_Name}");
    }

    public static void Watch(GitUser gitUser)
    {

    }
}
