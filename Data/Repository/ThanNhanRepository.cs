using Dapper;
using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Repository
{
    public class ThanNhanRepository : Repository<Thannhan>, IThanNhanRepository
    {
        public async Task Create(Thannhan entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ten", entity.Ten);
            dynamicParameters.Add("@ngaysinh", entity.Ngaysinh);
            dynamicParameters.Add("@nghenghiep", entity.Nghenghiep);
            dynamicParameters.Add("@id_nhanvien", entity.IdNhanvien);
            dynamicParameters.Add("@dateadd", DateTime.Now);
            dynamicParameters.Add("@useradd", entity.Useradd);

            await QueryFirstOrDefault("usp_ThanNhanInsert", dynamicParameters);
        }
        public async Task Delete(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            await Execute("usp_ThanNhanDelete", dynamicParameters);
        }

        public async Task<IEnumerable<Thannhan>> getAll()
        {
            return await Query("usp_ThanNhanGetAll");
        }

        public async Task<Thannhan> getById(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            return await QueryFirstOrDefault("usp_ThanNhanGet", dynamicParameters);
        }

        public async Task Update(Thannhan entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", entity.Id);
            dynamicParameters.Add("@ten", entity.Id);
            dynamicParameters.Add("@ngaysinh", entity.Ngaysinh);
            dynamicParameters.Add("@nghenghiep", entity.Nghenghiep);
            dynamicParameters.Add("@id_nhanvien", entity.IdNhanvien);
            dynamicParameters.Add("@dateedit", DateTime.Now);
            dynamicParameters.Add("@useredit", entity.Useredit);

            await Execute("usp_ThanNhanUpdate", dynamicParameters);
        }
    }
}
