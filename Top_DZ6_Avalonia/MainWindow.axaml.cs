using Avalonia.Controls;
using Top_DZ6_Avalonia.ViewModels;

namespace Top_DZ6_Avalonia;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}