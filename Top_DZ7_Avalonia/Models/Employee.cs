

namespace Top_DZ7_Avalonia.Models;

public class Employee : ViewModels.ViewModelBase
{
    private string _name = "";
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    private string _role = "";
    public string Role
    {
        get => _role;
        set => SetProperty(ref _role, value);
    }

    private int _age = 18;
    public int Age
    {
        get => _age;
        set => SetProperty(ref _age, value);
    }

    private string _email = "";
    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }

    public void UpdateFrom(Employee other)
    {
        if (other is null) return;
        Name = other.Name;
        Role = other.Role;
        Email = other.Email;
        Age = other.Age;
    }
}