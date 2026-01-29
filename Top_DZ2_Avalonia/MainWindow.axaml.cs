using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace Top_DZ2_Avalonia
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Calc();
        }

        private void Calc()
        {
            if (SummText == null) return;

            decimal price = 0;

            if (MargaritaRadio?.IsChecked == true) price += 300;
            else if (PepperoniRadio?.IsChecked == true) price += 400;
            else if (GavajskayaRadio?.IsChecked == true) price += 500;

            if (PeretsCheck?.IsChecked == true) price += 20;
            if (LukCheck?.IsChecked == true) price += 25;
            if (PomidorCheck?.IsChecked == true) price += 30;
            if (GribCheck?.IsChecked == true) price += 35;
            if (OlivkiCheck?.IsChecked == true) price += 40;
            if (CheeseCheck?.IsChecked == true) price += 50;

            decimal amount = AmountNumeric?.Value ?? 1;
            price *= amount;

            SummText.Text = $"Сумма: {price:N0} руб.";
        }

        private void UpdatePrice(object? sender, RoutedEventArgs e)
        {
            Calc();
        }

        private void AmountNumeric_ValueChanged(object? sender, NumericUpDownValueChangedEventArgs e)
        {
            Calc();
        }

        private void OrderButton_Click(object? sender, RoutedEventArgs e)
        {
            OrderInfoText.Foreground = Brushes.Red;

            if (string.IsNullOrWhiteSpace(NameBox?.Text))
            {
                OrderInfoText.Text = "Ошибка: Вы не заполнили имя";
                return;
            }

            if (string.IsNullOrWhiteSpace(TelBox?.Text))
            {
                OrderInfoText.Text = "Ошибка: Вы не заполнили телефон";
                return;
            }

            if (string.IsNullOrWhiteSpace(AddressBox?.Text))
            {
                OrderInfoText.Text = "Ошибка: Вы не заполнили адрес";
                return;
            }

            OrderInfoText.Foreground = Brushes.Green;
            string totalSum = SummText?.Text ?? "0";

            OrderInfoText.Text = $"Заказ успешно оформлен!\n" +
                                 $"Клиент: {NameBox.Text}\n" +
                                 $"Телефон: {TelBox.Text}\n" +
                                 $"Адрес: {AddressBox.Text}\n" +
                                 $"{totalSum}";
        }
    }
}