using System.Collections.ObjectModel;
using Top_DZ8_Avalonia.ViewModels;

namespace Top_DZ8_Avalonia.Models;

public class Category : ViewModelBase
{
    private string _name = "";
    public string Name { get => _name; set => SetProperty(ref _name, value); }
    public ObservableCollection<ShoppingItem> Items { get; } = new();

    public Category(string name) => Name = name;
}