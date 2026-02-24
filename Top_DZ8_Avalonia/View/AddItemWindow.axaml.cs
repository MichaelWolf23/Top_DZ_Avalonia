using Avalonia.Controls;
using Avalonia.Interactivity;
using Top_DZ8_Avalonia.ViewModels;

namespace Top_DZ8_Avalonia.Views;

public partial class AddItemWindow : Window
{
    public AddItemWindow() => InitializeComponent();

    private void OnOkClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is AddItemViewModel vm)
        {
            vm.ConfirmCommand.Execute(null);

            if (vm.Result is not null)
                Close(vm.Result);
            
        }
    }
}