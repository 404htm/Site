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
		const string POST_CONTAINER = "posts";
		const string POST_TABLE = "posts";
		const string POST_FILE_CONTAINER = "files";
		const string TAG_TABLE = "tags";


		private AzureDataLoader(CloudStorageAccount acct)
		{
			_acct = acct;
		}

		public static AzureDataLoader CreateDevLoader()
		{
			return new AzureDataLoader(CloudStorageAccount.DevelopmentStorageAccount);
		}

		public void SetupEnvironment()
		{
			
			var tableClient = _acct.CreateCloudTableClient();

			var posts = tableClient.GetTableReference(POST_TABLE);
			posts.CreateIfNotExists();

			var tags = tableClient.GetTableReference(TAG_TABLE);
			tags.CreateIfNotExists();

			var blobClient = _acct.CreateCloudBlobClient();

			
			//Public Security
			var container = blobClient.GetContainerReference(POST_FILE_CONTAINER);
			BlobContainerPermissions containerPermissions = new BlobContainerPermissions();
			containerPermissions.PublicAccess = BlobContainerPublicAccessType.Blob;
			container.SetPermissions(containerPermissions);
			

		}

		//public static AzureDataLoader Create(string connectionStr)
		//{
		//	var acct = new CloudStorageAccount(connectionStr, true);
		//	return new AzureDataLoader(acct);
		//}

		public void SavePost(PostSummary post, string postBody)
		{
			var tableClient = _acct.CreateCloudTableClient();

			CloudTable table = tableClient.GetTableReference(POST_TABLE);
			var insertOperation = TableOperation.InsertOrReplace(post);
			table.Execute(insertOperation); 

			CloudTable tagTable = tableClient.GetTableReference(TAG_TABLE);
			var tagBatch = new TableBatchOperation();

			foreach(var tagName in post.Tags.Split(','))
			{
				var tag = new TagIndex(tagName, post.Partition, post.ID);
				var tagInsert = TableOperation.InsertOrReplace(tag);
				tagTable.Execute(tagInsert);
			}

			var blobClient = _acct.CreateCloudBlobClient();
			var container = blobClient.GetContainerReference(POST_CONTAINER);
			var blockName = string.Format("{0}/{1}.html", post.PartitionKey, post.RowKey);
			var blob = container.GetBlockBlobReference(blockName);
			blob.UploadText(postBody, Encoding.UTF8);

		}

		public void SaveRelatedFile(string year, string postID, string fileName, Stream fileBody)
		{
			var blobClient = _acct.CreateCloudBlobClient();
			var container = blobClient.GetContainerReference(POST_FILE_CONTAINER);
			var blockName = string.Format("{0}/{1}/{2}", year, postID, fileName);
			var blob = container.GetBlockBlobReference(blockName);
			blob.UploadFromStream(fileBody);
		}

		public Uri GetFileURI(string year, string postID, string fileName)
		{
				return new Uri(_acct.BlobEndpoint, _acct.Credentials.AccountName + "/" + POST_FILE_CONTAINER + "/");
		}



	}
}
