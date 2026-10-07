using wt_lab3_3mvc_talashkevich.Models;
using wt_lab3_3mvc_talashkevich.Views;

namespace wt_lab3_3mvc_talashkevich.Controllers;

public class MemberController
{
    private readonly List<Member> members;
    private readonly MemberView view;

    public MemberController()
    {
        members = new List<Member>
        {
            new Member
            {
                Id = 1,
                Name = "Анна Петрова",
                Age = 25,
                MembershipType = "Годовой",
                IsActive = true
            },

            new Member
            {
                Id = 2,
                Name = "Максим Иванов",
                Age = 30,
                MembershipType = "Месячный",
                IsActive = true
            },

            new Member
            {
                Id = 3,
                Name = "Елена Смирнова",
                Age = 22,
                MembershipType = "Годовой",
                IsActive = false
            }
        };

        view = new MemberView();
    }

    public void Index()
    {
        view.ShowMembers(members);
    }

    public void Show(int id)
    {
        var member = members.FirstOrDefault(m => m.Id == id);

        if (member == null)
        {
            view.ShowMessage("Член клуба не найден.");
            return;
        }

        view.ShowMember(member);
    }

    public void Add(Member member)
    {
        members.Add(member);
        view.ShowMessage("Член клуба успешно добавлен.");
    }

    public void Delete(int id)
    {
        var member = members.FirstOrDefault(m => m.Id == id);

        if (member == null)
        {
            view.ShowMessage("Член клуба не найден.");
            return;
        }

        members.Remove(member);
        view.ShowMessage("Член клуба успешно удалён.");
    }

    // Дополнительная операция:
    // вывод только активных участников
    public void ShowActiveMembers()
    {
        var activeMembers = members
            .Where(m => m.IsActive)
            .ToList();

        if (activeMembers.Count == 0)
        {
            view.ShowMessage("Активных участников нет.");
            return;
        }

        view.ShowMembers(activeMembers);
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("=== МЕНЮ СПОРТИВНОГО КЛУБА ===");
            Console.WriteLine("1. Показать участников");
            Console.WriteLine("2. Найти участника");
            Console.WriteLine("3. Добавить участника");
            Console.WriteLine("4. Удалить участника");
            Console.WriteLine("5. Показать активных участников");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            var command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    Index();
                    break;

                case "2":
                    ShowMemberByUserInput();
                    break;

                case "3":
                    AddMemberByUserInput();
                    break;

                case "4":
                    DeleteMemberByUserInput();
                    break;

                case "5":
                    ShowActiveMembers();
                    break;

                case "0":
                    return;

                default:
                    view.ShowMessage("Неизвестная команда.");
                    break;
            }
        }
    }

    private void ShowMemberByUserInput()
    {
        Console.Write("Введите ID участника: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }

        Show(id);
    }

    private void AddMemberByUserInput()
    {
        Console.Write("Введите ID: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }

        Console.Write("Введите имя: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Введите возраст: ");

        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            view.ShowMessage("Некорректный возраст.");
            return;
        }

        Console.Write("Введите тип абонемента: ");
        string membershipType = Console.ReadLine() ?? "";

        Console.Write("Участник активен? (да/нет): ");
        string activeInput = Console.ReadLine() ?? "";

        bool isActive = activeInput.Trim()
            .Equals("да", StringComparison.OrdinalIgnoreCase);

        Add(new Member
        {
            Id = id,
            Name = name,
            Age = age,
            MembershipType = membershipType,
            IsActive = isActive
        });
    }

    private void DeleteMemberByUserInput()
    {
        Console.Write("Введите ID участника для удаления: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }

        Delete(id);
    }
}