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
    public class TaiKhoanRepository : ITaiKhoanRepository
    {
        private readonly string connectionString = "Data Source=.;Initial Catalog=QLNS;Integrated Security=True";

        private SqlConnection sqlConnection;
            
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
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();

                var dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@tendangnhap", username);
                dynamicParameters.Add("@matkhau", password);

                return await sqlConnection.QuerySingleOrDefaultAsync<Taikhoan>(
                    "usp_TaiKhoanGet",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Task Update(Taikhoan entity)
        {
            throw new NotImplementedException();
        }
    }
}
