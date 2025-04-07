namespace Program;

public class GitUser
{
    public string? Type { get; set; } = "";
    public string? Id { get; set; }
    public Repository? Repo { get; set; }
    public Payload? Payload { get; set; }
}

public class Repository
{
    public string? Name { get; set; } = "";
}

public class Payload
{
    public int Size { get; set; }
    public Member? Member { get; set; }
    public Forkee? Forkee { get; set; } 
    public string? Action { get; set; }
}

public class Forkee
{
    public string? Full_Name { get; set; }
}

public class Member
{
    public string? Login { get; set; }
    
}

