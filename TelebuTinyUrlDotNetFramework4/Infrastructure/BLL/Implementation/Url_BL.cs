using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TelebuTinyUrlDotNetFramework4.Infrastructure.DAL.Implementation;
using TelebuTinyUrlDotNetFramework4.Models.APIContracts;
using TelebuTinyUrlDotNetFramework4.Models.APIContracts.Requests;
using TelebuTinyUrlDotNetFramework4.Models.APIContracts.Response;
using TelebuTinyUrlDotNetFramework4.Models.DBModels;
using TelebuTinyUrlDotNetFramework4.Utils;

namespace TelebuTinyUrlDotNetFramework4.Infrastructure.BLL.Implementation
{
	public class Url_BL 
	{
		public async Task<GenericApiResponse<CreateTinyUrlResponse>> CreateTinyUrl(CreateTinyUrlRequest request)
		{
			try
			{
				DBResultCreateTinyURL DBReq = new DBResultCreateTinyURL();
				CreateTinyUrlResponse Response = new CreateTinyUrlResponse();
				DBReq.OrignalURL = request.OrignalURL.Trim();
				DBReq.UniqueUrlKey = KeyGenerator.GetUniqueKey(6);
				Url_DL DL = new Url_DL();
				var UniqueUrlKey = await DL.SaveOrignalUrl(DBReq);
				if (!string.IsNullOrEmpty(UniqueUrlKey))
				{
					Response.TinyUrl = new Uri(GetBaseUrl() + "/" + UniqueUrlKey).ToString();
					return GenericApiResponse<CreateTinyUrlResponse>.Successful(Response, "Short URL Created Successfully");
				}
				else
				{
					return GenericApiResponse<CreateTinyUrlResponse>.Failure("Unable to create short URL Something went", 2);
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
				Url_DL DL = new Url_DL();
				var OrignalUrlFromDbResponse = await DL.GetTinyUrl(DBReq);
				if (OrignalUrlFromDbResponse != null && OrignalUrlFromDbResponse.OrignalURL != null)
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

		private string GetBaseUrl()
		{
			var request = HttpContext.Current.Request;
			var appUrl = HttpRuntime.AppDomainAppVirtualPath;

			if (appUrl != "/")
				appUrl = "/" + appUrl;

			var baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

			return baseUrl;
		}
	}
}