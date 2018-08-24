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
    public class HopDongRepository : IHopDongRepository
    {
        private readonly string connectionString = @"Data Source=DESKTOP-62473AB\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True";

        private SqlConnection sqlConnection;

        public async Task Create(Hopdong entity)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();

                var dynamicParameters = new DynamicParameters();
               
                dynamicParameters.Add("@sohopdong", entity.Sohopdong);
                dynamicParameters.Add("@ten", entity.Ten);
                dynamicParameters.Add("@noidung", entity.Noidung);
                dynamicParameters.Add("@ngaylap", entity.Ngaylap);
                dynamicParameters.Add("@dateadd", DateTime.Now);
                dynamicParameters.Add("@useradd",entity.Useradd);
                await sqlConnection.ExecuteAsync(
                    "usp_HopDongInsert",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Delete(int? id)
        {

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();

                var dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@id", id);

                await sqlConnection.ExecuteAsync(
                    "usp_HopDongDelete",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Hopdong>> getAll()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();

                return await sqlConnection.QueryAsync<Hopdong>(
                    "usp_HopDongGetAll",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Hopdong> getById(int? id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();

                var dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@id", id);

                return await sqlConnection.QuerySingleOrDefaultAsync<Hopdong>(
                    "usp_HopDongGet",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Update(Hopdong entity)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();

                var dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@id", entity.Id);
                dynamicParameters.Add("@sohopdong", entity.Sohopdong);
                dynamicParameters.Add("@ten", entity.Ten);
                dynamicParameters.Add("@noidung", entity.Noidung);
                dynamicParameters.Add("@ngaylap", entity.Ngaylap);
                dynamicParameters.Add("@dateedit", DateTime.Now);
                dynamicParameters.Add("@useredit", 1);

                await sqlConnection.ExecuteAsync(
                    "usp_HopDongUpdate",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

    }
}
