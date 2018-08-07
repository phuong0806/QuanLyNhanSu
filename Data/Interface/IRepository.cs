using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> getAll();

        Task<T> getById(int? id);

        Task Create(T entity);

        Task Update(T entity);

        Task Delete(int? id);
    }
}
