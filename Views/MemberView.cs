using wt_lab3_3mvc_talashkevich.Models;

namespace wt_lab3_3mvc_talashkevich.Views;

public class MemberView
{
    public void ShowMembers(List<Member> members)
    {
        Console.WriteLine("=== СПИСОК ЧЛЕНОВ СПОРТИВНОГО КЛУБА ===");

        foreach (var member in members)
        {
            Console.WriteLine(
                $"{member.Id}. " +
                $"{member.Name} | " +
                $"Возраст: {member.Age} | " +
                $"Абонемент: {member.MembershipType} | " +
                $"Активен: {member.IsActive}"
            );
        }
    }

    public void ShowMember(Member member)
    {
        Console.WriteLine("=== ЧЛЕН СПОРТИВНОГО КЛУБА ===");
        Console.WriteLine($"ID: {member.Id}");
        Console.WriteLine($"Имя: {member.Name}");
        Console.WriteLine($"Возраст: {member.Age}");
        Console.WriteLine($"Тип абонемента: {member.MembershipType}");
        Console.WriteLine($"Активен: {member.IsActive}");
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}