
namespace TallerMecanica.Repositories
{
    using System.Collections.Generic;
    public interface IRepository<T>
    {
        bool Insert(T item);
        bool Update(T item);
        bool Delete(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByValue(string value);//Searchs
    }
}
