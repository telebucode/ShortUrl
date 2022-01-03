using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TelebuTinyUrl.Infrastructure.BLL.Interfaces;
using TelebuTinyUrl.Models;
using TelebuTinyUrl.Models.APIContracts.Requests;

namespace TelebuTinyUrl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUrl_BL BL;

        public HomeController(ILogger<HomeController> logger, IUrl_BL bl)
        {
            _logger = logger;
            BL = bl;
        }
        [HttpGet("/{key}")]
        public async Task<IActionResult> Index(string key)
        {
            var resp = await BL.GetOrignalUrlAgainstTinyUrl(key);
            if(resp.Success==0)
            {
                return RedirectPermanent(resp.Payload.OrignalURL);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateTinyUrl([FromBody] CreateTinyUrlRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await BL.CreateTinyUrl(request);
            return Json(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
