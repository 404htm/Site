using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web404.Site.Controllers
{
    public abstract class BaseController : Controller
    {
		protected CMS.DataManager CMS
		{
			get {
				var cnn = ConfigurationManager.ConnectionStrings["AzureSQL"].ConnectionString;
				var cms = new CMS.DataManager(cnn);
				return cms;
			}
		}
    }
}