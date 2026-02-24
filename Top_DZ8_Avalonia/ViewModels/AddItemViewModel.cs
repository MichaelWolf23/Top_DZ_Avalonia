using System.Windows.Input;
using Top_DZ8_Avalonia.Helpers;
using Top_DZ8_Avalonia.Models;

namespace Top_DZ8_Avalonia.ViewModels;

public class AddItemViewModel : ViewModelBase
{
    private string _name = "";

    private decimal _price = 0;
    

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public decimal Price
    {
        get => _price;
        set => SetProperty(ref _price, value);
    }

    public ShoppingItem? Result { get; private set; }

    public ICommand ConfirmCommand { get; }

    public AddItemViewModel()
    {
        ConfirmCommand = new RelayCommand(_ =>
        {
            if (!string.IsNullOrWhiteSpace(Name))
            {
                Result = new ShoppingItem(Name, Price);
            }
        });
    }
}