using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TelebuTinyUrlDotNetFramework4.Infrastructure.BLL.Implementation;
using TelebuTinyUrlDotNetFramework4.Models.APIContracts.Requests;

namespace TelebuTinyUrlDotNetFramework4.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("{key}")]
        public async Task<ActionResult> Index(string key)
        {
            if(string.IsNullOrWhiteSpace(key))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Url_BL BL = new Url_BL();
            var resp = await BL.GetOrignalUrlAgainstTinyUrl(key);
            if (resp.Success == 0)
            {
                return RedirectPermanent(resp.Payload.OrignalURL);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
        }
        [HttpPost]
        [Route("CreateShortUrl")]
        public async Task<ActionResult> CreateTinyUrl(CreateTinyUrlRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Url_BL BL = new Url_BL();
            var response = await BL.CreateTinyUrl(request);
            return Json(response);
        }
    }
}
