using Dapper;
using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Repository
{
    public class ChucVuRepository : Repository<Chucvu>, IChucVuRepository
    {
        public async Task Create(Chucvu entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ten", entity.Ten);
            dynamicParameters.Add("@phucap", entity.Phucap);
            dynamicParameters.Add("@mota", entity.Mota);
            dynamicParameters.Add("@dateadd", DateTime.Now);
            dynamicParameters.Add("@useradd", 1);

            await QueryFirstOrDefault("usp_ChucVuInsert", dynamicParameters);
        }
        public async Task Delete(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            await Execute("usp_ChucVuDelete", dynamicParameters);
        }

        public async Task<IEnumerable<Chucvu>> getAll()
        {
            return await Query("usp_ChucVuGetAll");
        }

        public async Task<Chucvu> getById(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            return await QueryFirstOrDefault("usp_ChucVuGet", dynamicParameters);
        }

        public async Task Update(Chucvu entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", entity.Id);
            dynamicParameters.Add("@ten", entity.Ten);
            dynamicParameters.Add("@phucap", entity.Phucap);
            dynamicParameters.Add("@mota", entity.Mota);
            dynamicParameters.Add("@dateedit", DateTime.Now);
            dynamicParameters.Add("@useredit", 1);

            await Execute("usp_ChucVuUpdate", dynamicParameters);
        }
    }
}
