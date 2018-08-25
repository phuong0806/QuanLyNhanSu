using Dapper;
using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Repository
{
    public class ChuyenNganhRepository : Repository<Chuyennganh>, IChuyenNganhRepository
    {
        public async Task Create(Chuyennganh entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ten", entity.Ten);
            dynamicParameters.Add("@dateadd", DateTime.Now);
            dynamicParameters.Add("@useradd", 1);

            await QueryFirstOrDefault("usp_ChuyenNganhInsert", dynamicParameters);
        }
        public async Task Delete(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            await Execute("usp_ChuyenNganhDelete", dynamicParameters);
        }

        public async Task<IEnumerable<Chuyennganh>> getAll()
        {
            return await Query("usp_ChuyenNganhGetAll");
        }

        public async Task<Chuyennganh> getById(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            return await QueryFirstOrDefault("usp_ChuyenNganhGet", dynamicParameters);
        }

        public async Task Update(Chuyennganh entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ten", entity.Id);
            dynamicParameters.Add("@useredit", 1);

            await Execute("usp_ChuyenNganhUpdate", dynamicParameters);
        }
    }
}
