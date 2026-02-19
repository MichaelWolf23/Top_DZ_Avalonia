using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top_DZ7_Avalonia.Models;

public class Employee : ViewModels.ViewModelBase
{
    private string _name = "";
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    private string _role = "";
    public string Role
    {
        get => _role;
        set => SetProperty(ref _role, value);
    }

    private int _age = 18;
    public int Age
    {
        get => _age;
        set => SetProperty(ref _age, value);
    }

}