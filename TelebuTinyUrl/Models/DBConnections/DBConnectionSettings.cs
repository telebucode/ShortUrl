using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TelebuTinyUrl.Models.DBConnections
{
    public class DBConnectionSettings : IDBConnectionSettings
    {
        public IDbConnection SqlConnection { get; }
        public  DBConnectionSettings(IDbConnection connection)
        {
            SqlConnection = connection;
        }
    }
}
