using Avalonia.Controls;
using Top_DZ7_Avalonia.Models;
using Top_DZ7_Avalonia.ViewModels;

namespace Top_DZ7_Avalonia;

public partial class AddEmployeeWindow : Window
{
    public AddEmployeeWindow()
    {
        InitializeComponent();
        DataContext = new AddEmployeeViewModel();
    }

    private void Ok_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var vm = (AddEmployeeViewModel)DataContext!;
        Employee employee = vm.BuildEmployee();

        if (string.IsNullOrWhiteSpace(employee.Name))
            return;

        Close(employee);
    }

    private void Cancel_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        => Close(null);
}