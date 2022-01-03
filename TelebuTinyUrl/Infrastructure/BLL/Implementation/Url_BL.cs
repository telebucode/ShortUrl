using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelebuTinyUrl.Infrastructure.BLL.Interfaces;
using TelebuTinyUrl.Infrastructure.DAL.Interfaces;
using TelebuTinyUrl.Models.APIContracts;
using TelebuTinyUrl.Models.APIContracts.Requests;
using TelebuTinyUrl.Models.APIContracts.Response;
using TelebuTinyUrl.Models.DBModels;
using TelebuTinyUrl.Utils;

namespace TelebuTinyUrl.Infrastructure.BLL.Implementation
{
	public class Url_BL : IUrl_BL
	{
		private readonly IUrl_DL DL;
		private readonly IHttpContextAccessor httpContext;

		public Url_BL(IUrl_DL dl, IHttpContextAccessor context)
		{
			DL = dl;
			httpContext = context;
		}

		public async Task<GenericApiResponse<CreateTinyUrlResponse>> CreateTinyUrl(CreateTinyUrlRequest request)
		{
            try
            {
				DBResultCreateTinyURL DBReq = new DBResultCreateTinyURL();
				CreateTinyUrlResponse Response = new CreateTinyUrlResponse();
				DBReq.OrignalURL = request.OrignalURL.Trim();
				DBReq.UniqueUrlKey = KeyGenerator.GetUniqueKey(6);
				var UniqueUrlKey = await DL.SaveOrignalUrl(DBReq);
				if (!string.IsNullOrEmpty(UniqueUrlKey))
				{
					Response.TinyUrl= new Uri(httpContext.HttpContext.Request.Scheme + "://" + httpContext.HttpContext.Request.Host.Value + httpContext.HttpContext.Request.PathBase + "/" + UniqueUrlKey).ToString();
					return GenericApiResponse<CreateTinyUrlResponse>.Successful(Response, "Short URL Created Successfully");
				}
                else
                {
					return GenericApiResponse<CreateTinyUrlResponse>.Failure("Unable to create short URL Something went",2);
                }
			}
            catch
            {
				throw;
            }
		}

		public async Task<GenericApiResponse<DBResultCreateTinyURL>> GetOrignalUrlAgainstTinyUrl(string key)
		{
			try
			{
				DBResultCreateTinyURL DBReq = new DBResultCreateTinyURL();
				DBReq.UniqueUrlKey = key;
				var OrignalUrlFromDbResponse = await DL.GetTinyUrl(DBReq);
				if (OrignalUrlFromDbResponse!=null && OrignalUrlFromDbResponse.OrignalURL!=null)
				{
					return GenericApiResponse<DBResultCreateTinyURL>.Successful(OrignalUrlFromDbResponse, "Orignal URL found Successfully");
				}
				else
				{
					return GenericApiResponse<DBResultCreateTinyURL>.Failure("No orignal url exists", 2);
				}
			}
			catch
			{
				throw;
			}
		}
	}
}
