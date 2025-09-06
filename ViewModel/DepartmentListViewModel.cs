using EDU.Models;

namespace EDU.ViewModel;

public class DepartmentListViewModel
{
    public List<Department> Departments { get; set; } = new();
    public string Search { get; set; } = string.Empty;
}
