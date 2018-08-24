using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Repository
{
    public class PhongBanRepository : Repository<Phongban>, IPhongBanRepository
    {
        public Task Create(Phongban entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Phongban>> getAll()
        {
            throw new NotImplementedException();
        }

        public Task<Phongban> getById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Phongban entity)
        {
            throw new NotImplementedException();
        }
    }
}
