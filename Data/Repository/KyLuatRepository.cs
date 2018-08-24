using Dapper;
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
        public async Task Create(Kyluat entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ten", entity.Id);
            dynamicParameters.Add("@mota", entity.Mota);
            dynamicParameters.Add("@dateadd", DateTime.Now);
            dynamicParameters.Add("@useradd", 1);

            await QueryFirstOrDefault("usp_KyLuatInsert", dynamicParameters);
        }
        public async Task Delete(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            await Execute("usp_KyLuatDelete", dynamicParameters);
        }

        public async Task<IEnumerable<Kyluat>> getAll()
        {
            return await Query("usp_KyLuatGetAll");
        }

        public async Task<Kyluat> getById(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            return await QueryFirstOrDefault("usp_KyLuatGet", dynamicParameters);
        }

        public async Task Update(Kyluat entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", entity.Id);
            dynamicParameters.Add("@ten", entity.Ten);
            dynamicParameters.Add("@mota", entity.Mota);
            dynamicParameters.Add("@dateedit", DateTime.Now);
            dynamicParameters.Add("@useredit", 1);

            await Execute("usp_KyLuatUpdate", dynamicParameters);
        }
    }
}
