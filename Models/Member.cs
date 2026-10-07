namespace wt_lab3_3mvc_talashkevich.Models;

public class Member
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public string MembershipType { get; set; } = "";
    public bool IsActive { get; set; }
}