using Dapper;
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
        public async Task Create(LoaiDaotao entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ten", entity.Id);
            dynamicParameters.Add("@mota", entity.Mota);
            dynamicParameters.Add("@dateadd", DateTime.Now);
            dynamicParameters.Add("@useradd", 1);

            await QueryFirstOrDefault("usp_LoaiDaoTaoInsert", dynamicParameters);
        }
        public async Task Delete(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            await Execute("usp_LoaiDaoTaoDelete", dynamicParameters);
        }

        public async Task<IEnumerable<LoaiDaotao>> getAll()
        {
            return await Query("usp_LoaiDaoTaoGetAll");
        }

        public async Task<LoaiDaotao> getById(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            return await QueryFirstOrDefault("usp_LoaiDaoTaoGet", dynamicParameters);
        }

        public async Task Update(LoaiDaotao entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", entity.Id);
            dynamicParameters.Add("@ten", entity.Ten);
            dynamicParameters.Add("@mota", entity.Mota);
            dynamicParameters.Add("@dateedit", DateTime.Now);
            dynamicParameters.Add("@useredit", 1);

            await Execute("usp_LoaiDaoTaoUpdate", dynamicParameters);
        }
    }
}
