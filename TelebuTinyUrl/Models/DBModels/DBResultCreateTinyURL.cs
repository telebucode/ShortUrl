using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelebuTinyUrl.Models.DBModels
{
    public class DBResultCreateTinyURL
    {
        public int Id { get; set; }
        public string OrignalURL { get; set; }
        public string UniqueUrlKey { get; set; }
    }
}
