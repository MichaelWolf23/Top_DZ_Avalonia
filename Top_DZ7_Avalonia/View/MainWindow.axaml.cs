using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using Top_DZ7_Avalonia.Models;
using Top_DZ7_Avalonia.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Top_DZ7_Avalonia;

public partial class MainWindow : Window
{
    public MainWindowViewModel ViewModel => (MainWindowViewModel)DataContext!;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }

    private async void Add_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var dlg = new AddEmployeeWindow();
        var employee = await dlg.ShowDialog<Employee?>(this);

        if (employee is not null)
            ViewModel.Employees.Add(employee);
    }

    private async void Save_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var file = await StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Сохранить сотрудников",
            SuggestedFileName = "employees.json",
            FileTypeChoices =
            [
                new FilePickerFileType("JSON") { Patterns = ["*.json"] }
            ]
        });

        if (file is null) return;

        await using var stream = await file.OpenWriteAsync();
        await JsonSerializer.SerializeAsync(stream, ViewModel.Employees,
            new JsonSerializerOptions { WriteIndented = true });
    }

    private async void Load_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var files = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Открыть файл сотрудников",
            AllowMultiple = false,
            FileTypeFilter =
            [
                new FilePickerFileType("JSON") { Patterns = ["*.json"] }
            ]
        });

        var file = files.FirstOrDefault();
        if (file is null) return;

        await using var stream = await file.OpenReadAsync();
        var loaded = await JsonSerializer.DeserializeAsync<List<Models.Employee>>(stream,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (loaded is null) return;

        ViewModel.ReplaceEmployees(loaded);
    }
}