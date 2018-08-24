using Dapper;
using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Repository
{
    public class ChiTietDaoTaoRepository : Repository<ChitietDaotao>, IChiTietDaoTapRepository
    {
        public async Task Create(ChitietDaotao entity)
        {

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ten", entity.Ten);
            dynamicParameters.Add("@batdau", entity.Batdau);
            dynamicParameters.Add("@ketthuc", entity.Ketthuc);
            dynamicParameters.Add("@diachi", entity.Diachi);
            dynamicParameters.Add("@noidung", entity.Noidung);
            dynamicParameters.Add("@gia", entity.Gia);
            dynamicParameters.Add("@id_loai_daotao", entity.IdLoaiDaotao);
            dynamicParameters.Add("@dateadd", DateTime.Now);
            dynamicParameters.Add("@useradd", 1);

            await QueryFirstOrDefault("usp_ChiTiet_DaoTaoInsert", dynamicParameters);
        }

        public async Task Delete(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            await Execute("usp_ChiTiet_DaoTaoDelete", dynamicParameters);
        }

        public async Task<IEnumerable<ChitietDaotao>> getAll()
        {
            return await Query("usp_ChiTiet_DaoTaoGetAll");
        }

        public async Task<ChitietDaotao> getById(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            return await QueryFirstOrDefault("usp_Chitiet_DaotaoGet", dynamicParameters);
        }

        public async Task Update(ChitietDaotao entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ten", entity.Id);
            dynamicParameters.Add("@ten", entity.Ten);
            dynamicParameters.Add("@batdau", entity.Batdau);
            dynamicParameters.Add("@ketthuc", entity.Ketthuc);
            dynamicParameters.Add("@diachi", entity.Diachi);
            dynamicParameters.Add("@noidung", entity.Noidung);
            dynamicParameters.Add("@gia", entity.Gia);
            dynamicParameters.Add("@id_loai_daotao", entity.IdLoaiDaotao);
            dynamicParameters.Add("@dateedit", DateTime.Now);
            dynamicParameters.Add("@useredit", 1);

            await Execute("usp_Chitiet_DaotaoUpdate", dynamicParameters);
        }
    }
}
