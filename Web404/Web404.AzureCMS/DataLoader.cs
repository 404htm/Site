using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using Web404.Common;

namespace Web404.AzureCMS
{
	public class AzureDataLoader
	{
		CloudStorageAccount _acct;

		private AzureDataLoader(CloudStorageAccount acct)
		{
			_acct = acct;
		}

		public static AzureDataLoader CreateDevLoader()
		{
			return new AzureDataLoader(CloudStorageAccount.DevelopmentStorageAccount);
		}

		//public static AzureDataLoader Create(string connectionStr)
		//{
		//	var acct = new CloudStorageAccount(connectionStr, true);
		//	return new AzureDataLoader(acct);
		//}

		public void SavePost(PostSummary post, Stream postBody)
		{

			
			var tableClient = _acct.CreateCloudTableClient();

			CloudTable table = tableClient.GetTableReference("posts");
			var insertOperation = TableOperation.InsertOrReplace(post);

			table.Execute(insertOperation); 

			var blobClient = _acct.CreateCloudBlobClient();
			var container = blobClient.GetContainerReference("posts");
			var blockName = string.Format("{0}/{1}.html", post.PartitionKey, post.RowKey);
			var blob = container.GetBlockBlobReference(blockName);
			blob.UploadFromStream(postBody);

		}

		public void SaveRelatedFile(PostSummary post, string fileName, Stream fileBody)
		{
			var blobClient = _acct.CreateCloudBlobClient();
			var container = blobClient.GetContainerReference("files");
			var blockName = string.Format("{0}/{1}/{2}", post.PartitionKey, post.RowKey, fileName);
			var blob = container.GetBlockBlobReference(blockName);
			blob.UploadFromStream(fileBody);
		}

	}
}
