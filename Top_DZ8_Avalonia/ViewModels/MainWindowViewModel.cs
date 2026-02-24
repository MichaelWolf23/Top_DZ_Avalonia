using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Top_DZ8_Avalonia.Models;
using Top_DZ8_Avalonia.Helpers;

namespace Top_DZ8_Avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Category> Categories { get; } = new();

    private decimal _totalSum;
    public decimal TotalSum
    {
        get => _totalSum;
        private set => SetProperty(ref _totalSum, value);
    }

    public MainWindowViewModel()
    {
        var dairy = new Category("Молочное");
        AddItemToCategory(dairy, new ShoppingItem("Молоко", 85));
        AddItemToCategory(dairy, new ShoppingItem("Творог", 120));

        Categories.Add(dairy);
        Categories.Add(new Category("Овощи"));

        UpdateTotal();
    }

    private void AddItemToCategory(Category cat, ShoppingItem item)
    {
        item.PropertyChanged += (s, e) => { if (e.PropertyName == nameof(ShoppingItem.IsBought)) UpdateTotal(); };
        cat.Items.Add(item);
    }

    public void UpdateTotal()
    {
        TotalSum = Categories.SelectMany(c => c.Items).Where(i => !i.IsBought).Sum(i => i.Price);
    }
}