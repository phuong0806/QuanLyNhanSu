using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Repository
{
    public class DonViRepository : Repository<Donvi>, IDonViRepository
    {
        public Task Create(Donvi entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Donvi>> getAll()
        {
            throw new NotImplementedException();
        }

        public Task<Donvi> getById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Donvi entity)
        {
            throw new NotImplementedException();
        }
    }
}
