using System.ComponentModel;
using Top_DZ7_Avalonia.Models;

namespace Top_DZ7_Avalonia.ViewModels;

public class AddEmployeeViewModel : ViewModelBase
{
    public string Name { get; set; } = "";
    public string Role { get; set; } = "";
    public int Age { get; set; } = 18;

    public Employee BuildEmployee()
        => new() { Name = Name.Trim(), Role = Role.Trim(), Age = Age };
}