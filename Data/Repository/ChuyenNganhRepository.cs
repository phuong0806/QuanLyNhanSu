using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Repository
{
    public class ChuyenNganhRepository : Repository<Chuyennganh>, IChuyenNganhRepository
    {
        public Task Create(Chuyennganh entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Chuyennganh>> getAll()
        {
            throw new NotImplementedException();
        }

        public Task<Chuyennganh> getById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Chuyennganh entity)
        {
            throw new NotImplementedException();
        }
    }
}
