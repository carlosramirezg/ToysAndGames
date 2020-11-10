using System.Collections.Generic;

namespace ToysDatabase
{
	public interface IRepository<T> where T : class
    {
        T Get(int id);

        List<T> GetAll();

        void Add(T entity);

        void Update(T entity);

        void Delete(int id);
    }
}