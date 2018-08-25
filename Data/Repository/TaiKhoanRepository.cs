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
    public class TaiKhoanRepository : Repository<Taikhoan>, ITaiKhoanRepository
    {
        public async Task<Taikhoan> Authenticate(string username, string password)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@tendangnhap", username);
            dynamicParameters.Add("@matkhau", password);
            return await QueryFirstOrDefault("usp_TaiKhoanAuthenticate", dynamicParameters);
        }

        public async Task Create(Taikhoan entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@tendangnhap", entity.Taikhoan1);
            dynamicParameters.Add("@matkhau", entity.Matkhau);
            dynamicParameters.Add("@salt", entity.Salt);
            dynamicParameters.Add("@khoa", entity.Khoa);
            dynamicParameters.Add("@thoigian_mokhoa", null);
            dynamicParameters.Add("@lydo_khoa", null);

            await QueryFirstOrDefault("usp_TaiKhoanInsert", dynamicParameters);
        }
        public async Task Delete(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            await Execute("usp_TaiKhoanDelete", dynamicParameters);
        }

        public async Task<IEnumerable<Taikhoan>> getAll()
        {
            return await Query("usp_TaiKhoanGetAll");
        }

        public async Task<Taikhoan> getById(int? id)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@id", id);

            return await QueryFirstOrDefault("usp_TaiKhoanGet", dynamicParameters);
        }

        public async Task Update(Taikhoan entity)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", entity.Id);
            dynamicParameters.Add("@tendangnhap", entity.Taikhoan1);
            dynamicParameters.Add("@matkhau", entity.Matkhau);
            dynamicParameters.Add("@salt", entity.Salt);

            await Execute("usp_TaiKhoanUpdate", dynamicParameters);
        }

        public async Task ChangeStatus(string username, string status, string reason)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@tendangnhap", username);
            dynamicParameters.Add("@khoa", status);
            dynamicParameters.Add("@lydo_khoa", reason);

            await QueryFirstOrDefault("usp_TaiKhoanStatus", dynamicParameters);
        }
    }
}
