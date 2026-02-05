using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Styling;
using Avalonia;

namespace Top_DZ4_Avalonia
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    

        private void ToggleTheme_Click(object? sender, RoutedEventArgs e)
        {
            if (Application.Current is null) return;

            var current = Application.Current.RequestedThemeVariant;
            Application.Current.RequestedThemeVariant =
                current == ThemeVariant.Dark ? ThemeVariant.Light : ThemeVariant.Dark;
        }
    }
}