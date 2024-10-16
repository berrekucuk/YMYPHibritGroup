// See https://aka.ms/new-console-template for more information

public class User
{
    public string Name { get; set; }
    public int Age { get; set; }

}

internal class Program
{
    static void Main(string[] args)
    {
        var user = new User()
        {
            Name = "Ahmet",
            Age = 23
        };
        Console.WriteLine($"Name= {user.Name}, Age={user.Age}");

        ChangeUserName(user);
        Console.WriteLine($"Name= {user.Name}, Age={user.Age}");

        ChangeAge(user.Age);
        Console.WriteLine($"Name= {user.Name}, Age={user.Age}");

    }

    static void ChangeUserName(User user)
    {
        user.Name = "Mehmet";
        user.Age = 50;
    }


    static void ChangeAge(int age)
    {
        age = 40;
    }

}
