using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Web404.Common;

namespace Web404.AzureCMS
{
	public class AzureCmsManager : ICmsManager
	{
	CloudStorageAccount _acct;
	const int DEFAULT_ITEMS = 10;

	private AzureCmsManager(CloudStorageAccount acct)
	{
		_acct = acct;
	}

	public static AzureCmsManager CreateDev()
	{
		return new AzureCmsManager(CloudStorageAccount.DevelopmentStorageAccount);
	}

	public IEnumerable<IPostSummary> GetPostSummaries(int start = 0, int? postCount = null)
	{
		var tableClient = _acct.CreateCloudTableClient();
		CloudTable posts = tableClient.GetTableReference("posts");

		var result =
		posts.CreateQuery<PostSummary>()
		//.OrderByDescending(p => p.Date)
		//.Where(p => p.Active)
		//.Skip(start)
		//.Take(postCount??DEFAULT_ITEMS)
		.ToList()
		;


		return result.Cast<IPostSummary>().ToList();
	}

	//public string GetPostContent()
	//{

	//}



	}
}
