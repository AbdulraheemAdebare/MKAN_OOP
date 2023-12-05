namespace MKAN;

public abstract class Member
{
    public int Id { get; set; }
    public string FullName { get; set; } = default!;
    public string MemberNo { get; set; } = default!;
    public string Jamaat { get; set; } = default!;
    public string Circuit { get; set; } = default!;
}