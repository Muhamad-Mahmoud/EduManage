using Microsoft.EntityFrameworkCore;
using MVC02.Models;
using MVC02.Repository.IRepository;

namespace MVC02.Repository;

public class CourseRepository : BaseRepository<Course>, ICourseRepository
{
    private readonly AppDbContext _context;
    public CourseRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public List<Course> GetAllWithDepartments()
    {
        return _context.Courses.Include(c => c.Department).ToList();
    }

    public Course? GetByIdWithDepartment(int id)
    {
        return _context.Courses.Include(c => c.Department).FirstOrDefault(c => c.Id == id);
    }
}