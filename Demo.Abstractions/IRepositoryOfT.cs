using System.Collections.Generic;

namespace BuildSchool.Mvc.Demo.Abstractions
{
    public interface IRepository<T, TKey> 
    {
        void Create(T model);
        void Update(T model);
        void Delete(T model);
        T Get(TKey key);
        IEnumerable<T> GetAll();
    }
}
