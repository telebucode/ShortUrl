using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TelebuTinyUrlDotNetFramework4.Models.DBConnections;
using TelebuTinyUrlDotNetFramework4.Models.DBModels;

namespace TelebuTinyUrlDotNetFramework4.Infrastructure.DAL.Implementation
{
    public class Url_DL 
    {
        private readonly IDBConnectionSettings DbConnection;
        public Url_DL()
        {
            DbConnection = new DBConnectionSettings(new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString));
        }
        public async Task<DBResultCreateTinyURL> GetTinyUrl(DBResultCreateTinyURL dB)
        {
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@UniqueUrlKey", dB.UniqueUrlKey);
                var DBResult = await DbConnection.SqlConnection.QueryAsync<DBResultCreateTinyURL>("API_TelebuGetOrignalURLInfo", parameter, commandType: CommandType.StoredProcedure);
                return DBResult.FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> SaveOrignalUrl(DBResultCreateTinyURL dB)
        {
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@OrignalURL", dB.OrignalURL);
                parameter.Add("@UniqueUrlKey", dB.UniqueUrlKey);

                var DBResult = await DbConnection.SqlConnection.ExecuteScalarAsync("API_TelebuSaveOrignalURLInfo", parameter, commandType: CommandType.StoredProcedure);

                return DBResult.ToString();

            }
            catch
            {
                throw;
            }
        }
    }
}