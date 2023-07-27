namespace CodeCool.CrashTest.Model;

public record Seat()
{
    public bool IsUsed { get; }
    public bool IsAirbagOpen { get; set; }

    public Seat(bool isUsed, bool isAirbagOpen) : this()
    {
        IsUsed = isUsed;
        IsAirbagOpen = isAirbagOpen;
    }
}
