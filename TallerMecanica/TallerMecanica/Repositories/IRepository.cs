
namespace TallerMecanica.Repositories
{
    using System.Collections.Generic;
    public interface IRepository<T>
    {
        void Add(T petModel);
        void Edit(T petModel);
        void Delete(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByValue(string value);//Searchs
    }
}
