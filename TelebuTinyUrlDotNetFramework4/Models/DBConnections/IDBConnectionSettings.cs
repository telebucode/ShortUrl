using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TelebuTinyUrlDotNetFramework4.Models.DBConnections
{
    public interface IDBConnectionSettings
    {
        IDbConnection SqlConnection { get; }
    }
}