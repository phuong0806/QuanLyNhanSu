using Dapper;
using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Repository
{
    public class KhenThuongRepository : Repository<Khenthuong>, IKhenThuongRepository
    {
        public async Task Create(Khenthuong entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ten", entity.Ten);
            dynamicParameters.Add("@noidung", entity.Noidung);
            dynamicParameters.Add("@ngaylap", entity.Ngaylap);
            dynamicParameters.Add("@ngaycapnhat", entity.Ngaycapnhat);
            dynamicParameters.Add("@dateadd", DateTime.Now);
            dynamicParameters.Add("@useradd", 1);

            await QueryFirstOrDefault("usp_KhenThuongInsert", dynamicParameters);
        }
        public async Task Delete(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            await Execute("usp_KhenThuongDelete", dynamicParameters);
        }

        public async Task<IEnumerable<Khenthuong>> getAll()
        {
            return await Query("usp_KhenThuongGetAll");
        }

        public async Task<Khenthuong> getById(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            return await QueryFirstOrDefault("usp_KhenThuongGet", dynamicParameters);
        }

        public async Task Update(Khenthuong entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", entity.Id);
            dynamicParameters.Add("@ten", entity.Ten);
            dynamicParameters.Add("@noidung", entity.Noidung);
            dynamicParameters.Add("@ngaylap", entity.Ngaylap);
            dynamicParameters.Add("@ngaycapnhat", entity.Ngaycapnhat);
            dynamicParameters.Add("@dateedit", DateTime.Now);
            dynamicParameters.Add("@useredit", 1);

            await Execute("usp_KhenThuongUpdate", dynamicParameters);
        }
    }
}
