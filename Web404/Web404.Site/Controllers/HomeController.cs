using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace Web404.Site.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var cnn = ConfigurationManager.ConnectionStrings["AzureSQL"].ConnectionString;
            var cms = new CMS.DataManager(cnn);

            var data = cms.GetPages();
            //var pages = cms.GetPages();
            return View();
        }
	}
}