using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelebuTinyUrl.Models.APIContracts;
using TelebuTinyUrl.Models.APIContracts.Requests;
using TelebuTinyUrl.Models.APIContracts.Response;
using TelebuTinyUrl.Models.DBModels;

namespace TelebuTinyUrl.Infrastructure.BLL.Interfaces
{
    public interface IUrl_BL
    {
        public Task<GenericApiResponse<CreateTinyUrlResponse>> CreateTinyUrl(CreateTinyUrlRequest request);
        Task<GenericApiResponse<DBResultCreateTinyURL>> GetOrignalUrlAgainstTinyUrl(string key);
    }
}
