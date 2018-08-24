using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Repository
{
    public class NhanVienRepository : Repository<Nhanvien>, INhanVienRepository
    {
        public Task Create(Nhanvien entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Nhanvien>> getAll()
        {
            throw new NotImplementedException();
        }

        public Task<Nhanvien> getById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Nhanvien entity)
        {
            throw new NotImplementedException();
        }
    }
}
