using System;

namespace Top_DZ6_Avalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private double _billAmount;
        private double _tipPercentage = 10;
        private int _numberOfPeople = 1;
        private bool _isRounded;

        public double BillAmount
        {
            get => _billAmount;
            set
            {
                if (_billAmount == value) return;
                _billAmount = value;
                RaisePropertyChanged();
                UpdateResults();
            }
        }

        public double TipPercentage
        {
            get => _tipPercentage;
            set
            {
                _tipPercentage = value;
                RaisePropertyChanged();
                UpdateResults();
            }
        }

        public int NumberOfPeople
        {
            get => _numberOfPeople;
            set
            {
                _numberOfPeople = Math.Max(1, value);
                RaisePropertyChanged();
                UpdateResults();
            }
        }

        public bool IsRounded
        {
            get => _isRounded;
            set
            {
                _isRounded = value;
                RaisePropertyChanged();
                UpdateResults();
            }
        }

        public double TipAmount => BillAmount * (TipPercentage / 100);
        public double TotalAmount => IsRounded ? Math.Ceiling(BillAmount + TipAmount) : BillAmount + TipAmount;
        public double AmountPerPerson => TotalAmount / NumberOfPeople;
        public RelayCommand ResetCommand { get; }

        public MainWindowViewModel()
        {
            ResetCommand = new RelayCommand(() => {
                BillAmount = 0;
                TipPercentage = 10;
                NumberOfPeople = 1;
                IsRounded = false;
            });
        }

        private void UpdateResults()
        {
            RaisePropertyChanged(nameof(TipAmount));
            RaisePropertyChanged(nameof(TotalAmount));
            RaisePropertyChanged(nameof(AmountPerPerson));
        }
    }
}
