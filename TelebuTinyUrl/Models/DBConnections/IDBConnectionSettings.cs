using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TelebuTinyUrl.Models.DBConnections
{
    public interface IDBConnectionSettings
    {
        IDbConnection SqlConnection { get; }
    }
}
