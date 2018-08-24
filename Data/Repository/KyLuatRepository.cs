using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Repository
{
    public class KyLuatRepository : Repository<Kyluat>, IKyLuatRepository
    {
        public Task Create(Kyluat entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Kyluat>> getAll()
        {
            throw new NotImplementedException();
        }

        public Task<Kyluat> getById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Kyluat entity)
        {
            throw new NotImplementedException();
        }
    }
}
