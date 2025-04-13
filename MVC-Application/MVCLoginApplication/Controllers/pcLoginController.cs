using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLoginApplication.Models;


namespace MVCLoginApplication.Controllers
{
    public class pcLoginController : Controller
    {
        // GET: pcLogin
       // pcLoginModel pcLoginModelData=new pcLoginModel();
        public ActionResult Index()
        {
            return View("pcLoginView");
        }

        [HttpPost]

        public ActionResult LoginButtonClick(string Username,string Password)
        {
            return View();  
        }

       

    }
}