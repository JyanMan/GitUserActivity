namespace Program;

public class GitUser
{
    public string? Type { get; set; } = "";
    public string? Id { get; set; }
}


public class Actor
{
    public required int ID { get; set; }
    public required string Login { get; set; }
    public required string DisplayLogin { get; set; }
}

