using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelebuTinyUrlDotNetFramework4.Models.APIContracts.Requests
{
    public class CreateTinyUrlRequest
    {
        [Required(ErrorMessage = "Please enter valid url")]
        [Url]
        public string OrignalURL { get; set; }
    }
}