using EDU.Models;
using System.Collections.Generic;

namespace EDU.Repository.IRepository
{
public interface ICourseRepository : IBaseRepository<Course>
{
    List<Course> GetAllWithDepartments();
    Course? GetByIdWithDepartment(int id);
}
}