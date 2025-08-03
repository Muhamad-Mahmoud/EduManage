using MVC02.Models;

namespace MVC02.Repository.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        public void Add(T obj);
        public void Update(T obj);
        public void Delete(int id);
        public T? GetById(int id);
        public List<T> GetAll();
        public void Save();
    }
}
