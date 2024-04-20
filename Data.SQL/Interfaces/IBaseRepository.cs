using Data.SQL.Models;

namespace Data.SQL.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        T Add(T model);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Remove(int id);
        bool Any();
        int Count();

        void Update(T model);

    }
}
