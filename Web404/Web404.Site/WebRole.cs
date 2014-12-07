using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Web.Administration;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace Web404.Site
{
    public class WebRole : RoleEntryPoint
    {

		public override void Run()
		{
			using (var serverManager = new ServerManager())
			{
				var mainSite = serverManager.Sites[RoleEnvironment.CurrentRoleInstance.Id + "_Web"];
				var mainApplication = mainSite.Applications["/"];
				var mainApplicationPool = serverManager.ApplicationPools[mainApplication.ApplicationPoolName];
				mainApplicationPool["autoStart"] = true;
				mainApplicationPool["startMode"] = "AlwaysRunning";

				serverManager.CommitChanges();
			}

			base.Run();
		}

        public override bool OnStart()
        {
            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }
    }
}
