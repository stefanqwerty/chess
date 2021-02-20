using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    public class HelloWorldController : Controller
    {
       
        public string Game(int ID)
        {
            return HttpUtility.HtmlEncode($"ID is {ID}");
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
