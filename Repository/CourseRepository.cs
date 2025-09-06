using Microsoft.EntityFrameworkCore;
using EDU.Models;
using EDU.Repository.IRepository;

namespace EDU.Repository;

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