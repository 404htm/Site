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
		const string POST_CONTAINER = "posts";
		const string POST_TABLE = "posts";
		const string TAG_TABLE = "tags";
		const string POST_FILE_CONTAINER = "files";

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
			CloudTable posts = tableClient.GetTableReference(POST_TABLE);

			var result =
			posts.CreateQuery<PostSummary>()
			//.OrderByDescending(p => p.Date)
			.Where(p => p.Active)
			//.Skip(start)
			//.Take(postCount??DEFAULT_ITEMS)
			.ToList();
			return result.Cast<IPostSummary>().ToList();
		}

		public IEnumerable<IPostSummary> GetPostSummariesByTag(string tag, int start=0, int? postCount = null)
		{
			tag = tag.Trim().ToLowerInvariant();

			var tableClient = _acct.CreateCloudTableClient();
			CloudTable tags = tableClient.GetTableReference(TAG_TABLE);
			var ids = tags.CreateQuery<TagIndex>()
				.Where(t => t.PartitionKey == tag)
				.ToList();

			foreach(var partition in ids.GroupBy(id => id.PostPartition))
			{
				var batch = new TableBatchOperation();
				//var ret = Tab
			}
		}

		public string GetPostContent(string partition, string id)
		{
			var blobClient = _acct.CreateCloudBlobClient();
			var container = blobClient.GetContainerReference(POST_CONTAINER);
			var blockName = string.Format("{0}/{1}.html", partition, id);
			var blob = container.GetBlockBlobReference(blockName);

			return blob.DownloadText(Encoding.UTF8);
		}

		public IPostDetail GetPost(string partition, string id)
		{
			var tableClient = _acct.CreateCloudTableClient();
			CloudTable posts = tableClient.GetTableReference(POST_TABLE);

			var result = posts.CreateQuery<PostDetail>()
				.Where(p => p.PartitionKey == partition)
				.Where(p => p.RowKey == id)
				.SingleOrDefault();

			if(result != null)
			{
				result.ArticleBody = GetPostContent(partition, id);
			}

			return result;
		}
	}
}
