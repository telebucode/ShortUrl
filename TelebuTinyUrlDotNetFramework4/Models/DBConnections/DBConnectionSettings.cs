using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TelebuTinyUrlDotNetFramework4.Models.DBConnections
{
    public class DBConnectionSettings : IDBConnectionSettings
    {
        public IDbConnection SqlConnection { get; }
        public DBConnectionSettings(IDbConnection connection)
        {
            SqlConnection = connection;
        }
    }
}