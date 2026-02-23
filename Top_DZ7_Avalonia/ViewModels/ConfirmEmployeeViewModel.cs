using Top_DZ7_Avalonia.Models;

namespace Top_DZ7_Avalonia.ViewModels;

public class ConfirmEmployeeViewModel : ViewModelBase
{
    public ConfirmEmployeeViewModel(Employee employee)
    {
        Name = employee.Name;
    }

    public string Name { get; set; }

}
