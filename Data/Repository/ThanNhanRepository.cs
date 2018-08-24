using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Repository
{
    public class ThanNhanRepository : Repository<Thannhan>, IThanNhanRepository
    {
        public Task Create(Thannhan entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Thannhan>> getAll()
        {
            throw new NotImplementedException();
        }

        public Task<Thannhan> getById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Thannhan entity)
        {
            throw new NotImplementedException();
        }
    }
}
