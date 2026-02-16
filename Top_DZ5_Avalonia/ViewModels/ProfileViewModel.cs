using Avalonia.Controls;
using System.ComponentModel;

namespace Top_DZ5_Avalonia.ViewModels;

public class ProfileViewModel : INotifyPropertyChanged
{
    private string _fullName = "";
    private ComboBoxItem? _selectedRole;
    private string _email = "";
    private string _phone = "";
    private int _experienceYears = 0;
    private bool _isSubscribed;

    public string FullName
    {
        get => _fullName;
        set
        {
            _fullName = value;
            OnPropertyChanged(nameof(FullName));    
        }
    }

    public ComboBoxItem? SelectedRole
    {
        get => _selectedRole;
        set
        {
            _selectedRole = value;

            OnPropertyChanged(nameof(SelectedRole));
            OnPropertyChanged(nameof(SummaryLine));
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(WarningText));
        }
    }

    public string Phone
    {
        get => _phone;
        set
        {
            _phone = value;
            OnPropertyChanged(nameof(Phone));
            OnPropertyChanged(nameof(WarningText));
        }
    }

    public int ExperienceYears
    {
        get => _experienceYears;
        set
        {
            _experienceYears = value;
            OnPropertyChanged(nameof(ExperienceYears));
            OnPropertyChanged(nameof(SummaryLine));
        }
    }

    public bool IsSubscribed
    {
        get => _isSubscribed;
        set
        {
            _isSubscribed = value;
            OnPropertyChanged(nameof(IsSubscribed));
        }
    }

    public string SummaryLine =>
        SelectedRole != null
        ? $"{SelectedRole?.Content}, стаж: {ExperienceYears} лет"
        : $"Cтаж: {ExperienceYears} лет";


    public string WarningText
    {
        get
        {
            if (string.IsNullOrWhiteSpace(Email) && string.IsNullOrWhiteSpace(Phone))
                return "Email и телефон не указаны";

            if (string.IsNullOrWhiteSpace(Email))
                return "Email не указан";

            if (string.IsNullOrWhiteSpace(Phone))
                return "Телефон не указан";

            return "";
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
