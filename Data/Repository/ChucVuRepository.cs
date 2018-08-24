using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Repository
{
    public class ChucVuRepository : Repository<ChucVuRepository>, IChucVuRepository
    {
        public Task Create(Chucvu entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Chucvu>> getAll()
        {
            throw new NotImplementedException();
        }

        public Task<Chucvu> getById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Chucvu entity)
        {
            throw new NotImplementedException();
        }
    }
}
