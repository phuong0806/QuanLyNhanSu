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
        public Task Create(Taikhoan entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Taikhoan>> getAll()
        {
            throw new NotImplementedException();
        }

        public Task<Taikhoan> getById(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<Taikhoan> getUser(string username, string password)
        {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@tendangnhap", username);
                dynamicParameters.Add("@matkhau", password);
                return await QueryFirstOrDefault("usp_TaiKhoanGet", dynamicParameters);
        }

        public Task Update(Taikhoan entity)
        {
            throw new NotImplementedException();
        }
    }
}
