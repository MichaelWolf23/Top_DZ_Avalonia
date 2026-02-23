using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Top_DZ7_Avalonia.Models;
using Top_DZ7_Avalonia.ViewModels;

namespace Top_DZ7_Avalonia;

public partial class ConfirmEmployeeWindow : Window
{
    private Employee? _originalEmployee;

    public ConfirmEmployeeWindow()
    {
        InitializeComponent();
    }

    public ConfirmEmployeeWindow(Employee employee)
    {
        InitializeComponent();
        _originalEmployee = employee;
        DataContext = new ConfirmEmployeeViewModel(employee);
    }

    private void Ok_Click(object sender, RoutedEventArgs e)
        => Close(_originalEmployee);
    

    private void Cancel_Click(object? sender, RoutedEventArgs e)
        => Close(null);
}