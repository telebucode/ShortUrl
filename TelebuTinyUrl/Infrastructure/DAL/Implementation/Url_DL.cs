using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TelebuTinyUrl.Infrastructure.DAL.Interfaces;
using TelebuTinyUrl.Models.Configurations;
using TelebuTinyUrl.Models.DBConnections;
using TelebuTinyUrl.Models.DBModels;

namespace TelebuTinyUrl.Infrastructure.DAL.Implementation
{
    public class Url_DL : IUrl_DL
    {
        private readonly IDBConnectionSettings DbConnection;
        public Url_DL(IOptions<ConnectionStrings> connectionConfig)
        {
            DbConnection = new DBConnectionSettings(new SqlConnection(connectionConfig.Value.DefaultConnection));
        }
        public async Task<DBResultCreateTinyURL> GetTinyUrl(DBResultCreateTinyURL dB)
        {
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@UniqueUrlKey", dB.UniqueUrlKey);
                var DBResult = await DbConnection.SqlConnection.QueryFirstOrDefaultAsync<DBResultCreateTinyURL>("API_TelebuGetOrignalURLInfo", parameter, commandType: CommandType.StoredProcedure);
                return DBResult;
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
