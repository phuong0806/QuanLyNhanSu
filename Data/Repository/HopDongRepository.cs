using Dapper;
using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Repository
{
    public class HopDongRepository : Repository<Hopdong>, IHopDongRepository
    {
        public async Task Create(Hopdong entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@sohopdong", entity.Sohopdong);
            dynamicParameters.Add("@ten", entity.Ten);
            dynamicParameters.Add("@noidung", entity.Noidung);
            dynamicParameters.Add("@ngaylap", entity.Ngaylap);
            dynamicParameters.Add("@dateadd", DateTime.Now);
            dynamicParameters.Add("@useradd", 1);

            await QueryFirstOrDefault("usp_HopDongInsert", dynamicParameters);
        }

        public async Task Delete(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            await Execute("usp_HopDongDelete", dynamicParameters);
        }

        public async Task<IEnumerable<Hopdong>> getAll()
        {
            return await Query("usp_HopDongGetAll");
        }

        public async Task<Hopdong> getById(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            return await QueryFirstOrDefault("usp_HopDongGet", dynamicParameters);
        }

        public async Task Update(Hopdong entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", entity.Id);
            dynamicParameters.Add("@sohopdong", entity.Sohopdong);
            dynamicParameters.Add("@ten", entity.Ten);
            dynamicParameters.Add("@noidung", entity.Noidung);
            dynamicParameters.Add("@ngaylap", entity.Ngaylap);
            dynamicParameters.Add("@dateedit", DateTime.Now);
            dynamicParameters.Add("@useredit", 1);

            await Execute("usp_HopDongUpdate", dynamicParameters);
        }
    }
}
