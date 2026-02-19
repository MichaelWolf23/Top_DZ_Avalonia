using System.Collections.Generic;
using System.Collections.ObjectModel;
using Top_DZ7_Avalonia.Models;

namespace Top_DZ7_Avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        Employees.Add(new Employee { Name = "Анна", Role = "Дизайнер", Age = 24 });
        Employees.Add(new Employee { Name = "Илья", Role = "Разработчик", Age = 29 });
    }

    public void ReplaceEmployees(IEnumerable<Employee> items)
    {
        Employees.Clear();
        foreach (var e in items) Employees.Add(e);
    }

    public ObservableCollection<Employee> Employees { get; } = new();

    private Employee? _selectedEmployee;
    public Employee? SelectedEmployee
    {
        get => _selectedEmployee;
        set => SetProperty(ref _selectedEmployee, value);
    }
}
