using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace Web404.Site.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(int start = 0, int take = 10)
        {
           var data = CMS.GetPostSummaries();
           return View(data);
	
        }

		public ActionResult Article(string ID)
		{
			//var data = CMS.GetPage(ID);
			//return View(data);
			return View();
		}

		public ActionResult ArticleBody(string ID)
		{
			//var data = CMS.GetPageContent(ID);
			//return Content(data);
			return View();
		}

		public ActionResult Tags(string ID)
		{
			//var data = CMS.GetTagArticleSummaries(ID);
			//return View(data);
			return View();
		}

		public ActionResult About()
		{
			//var data = CMS.GetSectionDefaultPage("About");
			//return View(data);
			return View();
		}

		public ActionResult Projects()
		{
			//var data = CMS.GetSectionPages("About");
			//return View(data);
			return View();
		}

		public ActionResult Tools()
		{
			//var data = CMS.GetSectionPages("Tools");
			//return View(data);
			return View();
		}
	}
}