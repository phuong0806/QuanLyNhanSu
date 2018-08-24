using Dapper;
using QLNS.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Data.Repository
{
    public class Repository<T>
    {
        private string connectionString = @"Data Source =.; Initial Catalog=QLNS; Integrated Security = True";

        protected async Task<T> QueryFirstOrDefault(string sql, DynamicParameters paramaters)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();

                return await sqlConnection.QuerySingleOrDefaultAsync<T>(
                    sql,
                    paramaters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        protected async Task<IEnumerable<T>> Query(string sql)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();

                return await sqlConnection.QueryAsync<T>(
                    sql,
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        protected async Task Execute(string sql, DynamicParameters paramaters)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();

                await sqlConnection.ExecuteAsync(
                    sql,
                    paramaters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
