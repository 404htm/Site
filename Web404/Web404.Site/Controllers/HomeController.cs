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
            var data = CMS.GetPageSummaries("Home", start, take);
            return View(data);
        }

		public ActionResult Article(string ID)
		{
			var data = CMS.GetPage(ID);
			return View(data);
		}

		public ActionResult Tag(string ID)
		{
			var data = CMS.GetTagArticleSummaries(ID);
			return View(data);
		}

		public ActionResult About()
		{
			var data = CMS.GetSectionDefaultPage("About");
			return View(data);
		}

		public ActionResult Projects()
		{
			var data = CMS.GetSectionPages("About");
			return View(data);
		}

		public ActionResult Tools()
		{
			var data = CMS.GetSectionPages("Tools");
			return View(data);
		}
	}
}