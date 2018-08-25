using Dapper;
using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Repository
{
    public class DaoTaoChuyenNganhRepository : Repository<Daotaochuyennganh>, IDaoTaoChuyenNganhRepository
    {
        public async Task Create(Daotaochuyennganh entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ten", entity.Id);
            dynamicParameters.Add("@ten", entity.Ten);
            dynamicParameters.Add("@batdau", entity.Batdau);
            dynamicParameters.Add("@ketthuc", entity.Ketthuc);
            dynamicParameters.Add("@id_chucvu", entity.IdChucvu);
            dynamicParameters.Add("@id_chuyennganh", entity.IdChuyennganh);
            dynamicParameters.Add("@id_phongban", entity.IdPhongban);
            dynamicParameters.Add("@dateadd", DateTime.Now);
            dynamicParameters.Add("@useradd", 1);

            await QueryFirstOrDefault("usp_DaoTaoChuyenNganhInsert", dynamicParameters);
        }
        public async Task Delete(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            await Execute("usp_DaoTaoChuyenNganhDelete", dynamicParameters);
        }

        public async Task<IEnumerable<Daotaochuyennganh>> getAll()
        {
            return await Query("usp_DaoTaoChuyenNganhGetAll");
        }

        public async Task<Daotaochuyennganh> getById(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            return await QueryFirstOrDefault("usp_DaoTaoChuyenNganhGet", dynamicParameters);
        }

        public async Task Update(Daotaochuyennganh entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", entity.Id);
            dynamicParameters.Add("@ten", entity.Id);
            dynamicParameters.Add("@ten", entity.Ten);
            dynamicParameters.Add("@batdau", entity.Batdau);
            dynamicParameters.Add("@ketthuc", entity.Ketthuc);
            dynamicParameters.Add("@id_chucvu", entity.IdChucvu);
            dynamicParameters.Add("@id_chuyennganh", entity.IdChuyennganh);
            dynamicParameters.Add("@id_phongban", entity.IdPhongban);
            dynamicParameters.Add("@dateedit", DateTime.Now);
            dynamicParameters.Add("@useredit", 1);

            await Execute("usp_DaoTaoChuyenNganhUpdate", dynamicParameters);
        }
    }
}
