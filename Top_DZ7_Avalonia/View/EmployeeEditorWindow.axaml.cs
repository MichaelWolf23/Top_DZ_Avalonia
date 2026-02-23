using Avalonia.Controls;
using Top_DZ7_Avalonia.Models;
using Top_DZ7_Avalonia.ViewModels;

namespace Top_DZ7_Avalonia;

public partial class EmployeeEditorWindow : Window
{
    public EmployeeEditorWindow()
    {
        InitializeComponent();
    }

    public EmployeeEditorWindow(string title) : this()
    {
        DataContext = new EmployeeEditorViewModel(title);
    }

    public EmployeeEditorWindow(Employee employee, string title) : this()
    {
        DataContext = new EmployeeEditorViewModel(employee, title);
    }


    private void Ok_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var vm = (EmployeeEditorViewModel)DataContext!;
        Close(vm.BuildEmployee());
    }

    private void Cancel_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        => Close(null);
}