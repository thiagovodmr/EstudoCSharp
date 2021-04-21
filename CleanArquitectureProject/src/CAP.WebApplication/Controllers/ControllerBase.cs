using CAP.ApplicationCore.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAP.WebApplication.Controllers
{
    public class ControllerBase : Controller
    {
        public void SetFlash(FlashMessageType type, string text)
        {
            TempData["FlashMessage.Type"] = type;
            TempData["FlashMessage.Text"] = text;
        }
    }
}
