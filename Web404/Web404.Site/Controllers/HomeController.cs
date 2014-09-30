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

		public ActionResult Post(string partition, string ID)
		{
			if(Request.IsAjaxRequest())
			{
				var data = CMS.GetPostContent(partition, ID);
				return Content(data);
				
			}
			else
			{
				var data = CMS.GetPost(partition, ID);
				return View(data);
			}
			
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