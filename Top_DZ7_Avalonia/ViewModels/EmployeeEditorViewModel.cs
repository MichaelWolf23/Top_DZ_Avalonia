using Top_DZ7_Avalonia.Models;

namespace Top_DZ7_Avalonia.ViewModels;

public class EmployeeEditorViewModel : ViewModelBase
{
    public EmployeeEditorViewModel(string title)
    {
        Title = title;
    }
    public EmployeeEditorViewModel(Employee employee, string title)
    {
        Name = employee.Name;
        Role = employee.Role;
        Email = employee.Email;
        Age = employee.Age;
        Title = title;
    }
    private string _name = "";
    private string _role = "";
    private string _email = "";
    public int Age { get; set; } = 18;
    public string Title { get; set; }

    public string Name
    {
        get => _name;
        set
        {
            if (SetProperty(ref _name, value))
            {
                OnPropertyChanged(nameof(CanConfirmName));
                OnPropertyChanged(nameof(CanConfirm));
            }
        }
    }
    public string Role
    {
        get => _role;
        set
        {
            if (SetProperty(ref _role, value))
            {
                OnPropertyChanged(nameof(CanConfirmRole));
                OnPropertyChanged(nameof(CanConfirm));

            }
        }
    }
    public string Email
    {
        get => _email;
        set
        {
            if (SetProperty(ref _email, value))
            {
                OnPropertyChanged(nameof(CanConfirmEmail));
                OnPropertyChanged(nameof(CanConfirm));

            }
        }
    }

    public bool CanConfirmEmail
    {
        get
        {
            if (string.IsNullOrWhiteSpace(Email)) return false;

            int atIndex = Email.IndexOf('@');
            int lastDotIndex = Email.LastIndexOf('.');

            return atIndex > 0
                && lastDotIndex > atIndex + 1
                && lastDotIndex < Email.Length - 1
                && !Email.Contains(' ');
        }
    }
    public bool CanConfirmName => !string.IsNullOrWhiteSpace(Name);
    public bool CanConfirmRole => !string.IsNullOrWhiteSpace(Role);
    public bool CanConfirm => CanConfirmEmail && CanConfirmName && CanConfirmRole;

    public Employee BuildEmployee() => new()
    {
        Name = Name.Trim(),
        Role = Role.Trim(),
        Email = Email.Trim(),
        Age = Age
    };

    public void ApplyChanges(Employee employee)
    {
        employee.Name = Name;
        employee.Role = Role;
        employee.Email = Email;
        employee.Age = Age;
    }
}