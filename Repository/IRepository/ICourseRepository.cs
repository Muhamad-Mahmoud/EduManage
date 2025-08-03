using MVC02.Models;
using System.Collections.Generic;

namespace MVC02.Repository.IRepository
{
public interface ICourseRepository : IBaseRepository<Course>
{
    List<Course> GetAllWithDepartments();
    Course? GetByIdWithDepartment(int id);
}
}