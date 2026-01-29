using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Top_DZ1_Avalonia;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void ShowSecret_Click(object sender, RoutedEventArgs e)
    {
        var secret = TextSecret;
        secret.IsVisible = true;

    }

    public void Exit_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}