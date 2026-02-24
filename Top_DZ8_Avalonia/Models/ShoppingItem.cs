using Top_DZ8_Avalonia.ViewModels;

namespace Top_DZ8_Avalonia.Models;

public class ShoppingItem : ViewModelBase
{
    private string _name = "";
    private decimal _price;
    private bool _isBought;
    private bool _isImportant;
    
    public string Name { get => _name; set => SetProperty(ref _name, value); }
    public decimal Price { get => _price; set => SetProperty(ref _price, value); }

    public bool IsBought
    {
        get => _isBought;
        set => SetProperty(ref _isBought, value);
    }

    public bool IsImportant { get => _isImportant; set => SetProperty(ref _isImportant, value); }

    public ShoppingItem(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}