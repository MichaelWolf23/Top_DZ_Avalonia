using Avalonia.Controls;
using Top_DZ5_Avalonia.ViewModels;

namespace Top_DZ5_Avalonia;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new ProfileViewModel();
    }
}