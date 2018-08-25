using Dapper;
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
        public async Task Create(Phongban entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ten", entity.Id);
            dynamicParameters.Add("@mota", entity.Mota);
            dynamicParameters.Add("@dateadd", DateTime.Now);
            dynamicParameters.Add("@useradd", 1);

            await QueryFirstOrDefault("usp_PhongBanInsert", dynamicParameters);
        }
        public async Task Delete(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            await Execute("usp_PhongBanDelete", dynamicParameters);
        }

        public async Task<IEnumerable<Phongban>> getAll()
        {
            return await Query("usp_PhongBanGetAll");
        }

        public async Task<Phongban> getById(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            return await QueryFirstOrDefault("usp_PhongBanGet", dynamicParameters);
        }

        public async Task Update(Phongban entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", entity.Id);
            dynamicParameters.Add("@ten", entity.Ten);
            dynamicParameters.Add("@mota", entity.Mota);
            dynamicParameters.Add("@dateedit", DateTime.Now);
            dynamicParameters.Add("@useredit", 1);

            await Execute("usp_PhongBanUpdate", dynamicParameters);
        }
    }
}
