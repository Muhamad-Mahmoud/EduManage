using EDU.Models;
using EDU.Repository.IRepository;

namespace EDU.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(T obj) => _context.Add(obj);

        public void Update(T obj) => _context.Update(obj);

        public void Delete(int id) => _context.Set<T>().Remove(GetById(id));

        public T? GetById(int id) => _context.Set<T>().Find(id);

        public List<T> GetAll() => _context.Set<T>().ToList();

        public void Save() => _context.SaveChanges();
    }
}