using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web404.AzureCMS;
using Web404.Common;

namespace Web404.Site.Controllers
{
    public abstract class BaseController : Controller
    {
		protected ICmsManager CMS
		{
			get {
				//var cnn = ConfigurationManager.ConnectionStrings["AzureSQL"].ConnectionString;
				//var cms = new CMS.DataManager(cnn);
				//return cms;

				return AzureCmsManager.CreateDev();
			}
		}
    }
}