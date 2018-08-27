using Dapper;
using Microsoft.AspNetCore.Mvc;
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
    public class KyHopDongRepository : Repository<Kyhopdong>, IKyHopDongRepository
    {
        public async Task Create(Kyhopdong entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@trangthai", entity.Trangthai);
            dynamicParameters.Add("@ngay_ky", entity.NgayKy);
            dynamicParameters.Add("@thoihan", entity.Thoihan);
            dynamicParameters.Add("@dateadd", DateTime.Now);
            dynamicParameters.Add("@useradd",entity.Useradd);
            dynamicParameters.Add("@id_hopdong", entity.IdHopdong);
            dynamicParameters.Add("@id_nhanvien", entity.IdNhanvien);
            await QueryFirstOrDefault("usp_KyHopDongInsert", dynamicParameters);
        }

        public Task Create(Hopdong model)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            await Execute("usp_KyHopDongDelete", dynamicParameters);
        }

        public async Task<IEnumerable<Kyhopdong>> getAll()
        {
            return await Query("usp_KyHopDongGetAll");
        }

        public async Task<Kyhopdong> getById(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            return await QueryFirstOrDefault("usp_KyHopDongGet", dynamicParameters);
        }

        public async Task Update(Kyhopdong entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", entity.Id);
            dynamicParameters.Add("@trangthai", entity.Trangthai);
            dynamicParameters.Add("@ngay_ky", entity.NgayKy);
            dynamicParameters.Add("@thoihan", entity.Thoihan);
            dynamicParameters.Add("@dateedit", DateTime.Now);
            dynamicParameters.Add("@useredit", entity.Useradd);
            dynamicParameters.Add("@id_hopdong", entity.IdHopdong);
            dynamicParameters.Add("@id_nhanvien", entity.IdNhanvien);
            await Execute("usp_KyHopDongUpdate", dynamicParameters);
        }
        public async Task UpdateGiaHan(Kyhopdong entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", entity.Id);
            //TimeSpan gh = DateTime.Now - DateTime.Parse(entity.Thoihan);
            //int tmp = Convert.ToInt32(gh.ToString());
            //if (tmp <= 15)
            //{
            //    //dynamicParameters.Add("@trangthai", "Sap het han");
            //    entity.Trangthai = "sap het";
            //}
            //else if (tmp > 15)
            //{
            //    //dynamicParameters.Add("@trangthai", "Con han");
            //    entity.Trangthai = "con";
            //}
            //else if (tmp > 15)
            //{
            //    //dynamicParameters.Add("@trangthai", "Het han");
            //    entity.Trangthai = " het";
            //}
            //entity.Trangthai = "con";
            dynamicParameters.Add("@trangthai", entity.Trangthai);
            dynamicParameters.Add("@thoihan", entity.Thoihan);
            dynamicParameters.Add("@dateedit", DateTime.Now);
            dynamicParameters.Add("@useredit", entity.Useradd);
            dynamicParameters.Add("@id_hopdong", entity.IdHopdong);
            dynamicParameters.Add("@id_nhanvien", entity.IdNhanvien);
            await Execute("usp_KyHopDongGiaHan", dynamicParameters);
        }
        public Task Update(Hopdong model)
        {
            throw new NotImplementedException();
        }

        public Task getHopDong()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> getHopDong(int? id)
        {
            throw new NotImplementedException();
        }
    }
}