using System.Collections.ObjectModel;
using System.Windows.Input;
using Top_DZ8_Avalonia.Models;
using Top_DZ8_Avalonia.Helpers;

namespace Top_DZ8_Avalonia.ViewModels;

public class EditCategoriesViewModel : ViewModelBase
{
    public ObservableCollection<Category> Categories { get; }
    private string _newName = "";
    private Category? _selectedCategory;

    public string NewName
    {
        get => _newName;
        set => SetProperty(ref _newName, value);
    }

    public Category? SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            if (SetProperty(ref _selectedCategory, value))
                (RemoveCommand as RelayCommand)?.RaiseCanExecuteChanged();
            
        }
    }

    public ICommand AddCommand { get; }
    public ICommand RemoveCommand { get; }

    public EditCategoriesViewModel(ObservableCollection<Category> categories)
    {
        Categories = categories;

        AddCommand = new RelayCommand(_ => {
            if (!string.IsNullOrWhiteSpace(NewName))
            {
                Categories.Add(new Category(NewName));
                NewName = "";
            }
        });

        RemoveCommand = new RelayCommand(_ => {
            if (SelectedCategory is not null)
            {
                Categories.Remove(SelectedCategory);
            }
        }, _ => SelectedCategory is not null);
    }
}