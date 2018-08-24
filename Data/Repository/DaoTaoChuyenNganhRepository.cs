using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Repository
{
    public class DaoTaoChuyenNganhRepository : Repository<Daotaochuyennganh>, IDaoTaoChuyenNganhRepository
    {
        public Task Create(Daotaochuyennganh entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Daotaochuyennganh>> getAll()
        {
            throw new NotImplementedException();
        }

        public Task<Daotaochuyennganh> getById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Daotaochuyennganh entity)
        {
            throw new NotImplementedException();
        }
    }
}
