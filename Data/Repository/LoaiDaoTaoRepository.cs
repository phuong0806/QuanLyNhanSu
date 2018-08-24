using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Repository
{
    public class LoaiDaoTaoRepository : Repository<LoaiDaotao>, ILoaiDaoTaoRepository
    {
        public Task Create(LoaiDaotao entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LoaiDaotao>> getAll()
        {
            throw new NotImplementedException();
        }

        public Task<LoaiDaotao> getById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(LoaiDaotao entity)
        {
            throw new NotImplementedException();
        }
    }
}
