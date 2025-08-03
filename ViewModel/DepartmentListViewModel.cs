using MVC02.Models;

namespace MVC02.ViewModel;

public class DepartmentListViewModel
{
    public List<Department> Departments { get; set; } = new();
    public string Search { get; set; } = string.Empty;
}
