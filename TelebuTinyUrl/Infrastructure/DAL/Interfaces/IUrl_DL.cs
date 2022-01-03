using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelebuTinyUrl.Models.APIContracts;
using TelebuTinyUrl.Models.APIContracts.Requests;
using TelebuTinyUrl.Models.APIContracts.Response;
using TelebuTinyUrl.Models.DBModels;

namespace TelebuTinyUrl.Infrastructure.DAL.Interfaces
{
    public interface IUrl_DL
    {
        Task<DBResultCreateTinyURL> GetTinyUrl(DBResultCreateTinyURL dB);
        Task<string> SaveOrignalUrl(DBResultCreateTinyURL dB);
    }
}
