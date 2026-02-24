using Avalonia.Controls;
using Avalonia.Interactivity;
using Top_DZ8_Avalonia.Models;
using Top_DZ8_Avalonia.ViewModels;

namespace Top_DZ8_Avalonia.Views;

public partial class MainWindow : Window
{
    public MainWindow() 
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }

    private async void OnEditCategoriesClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is MainWindowViewModel vm)
        {
            var dialog = new EditCategoriesWindow
            {
                DataContext = new EditCategoriesViewModel(vm.Categories)
            };
            await dialog.ShowDialog(this);
        }
    }

    private async void OnAddItemClick(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is Category selectedCategory)
        {
            var dialog = new AddItemWindow { DataContext = new AddItemViewModel() };

            var newItem = await dialog.ShowDialog<ShoppingItem>(this);

            if (newItem is not null && DataContext is MainWindowViewModel mainVm)
            {
                newItem.PropertyChanged += (s, ev) => {
                    if (ev.PropertyName == nameof(ShoppingItem.IsBought)) mainVm.UpdateTotal();
                };

                selectedCategory.Items.Add(newItem);
                mainVm.UpdateTotal();
            }
        }
    }
}