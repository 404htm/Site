using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using Web404.CMS;

namespace Web404.AzureCMS
{
	public class AzureDataLoader : Web404.CMS.IDataLoader
	{
		CloudStorageAccount _acct;
		string _cnn;

		const string POST_CONTAINER = "posts";
		const string POST_FILE_CONTAINER = "files";


		private AzureDataLoader(CloudStorageAccount acct, string connectionString)
		{
			_acct = acct;
			_cnn = connectionString;
		}

		public static AzureDataLoader CreateDevLoader(string connectionString)
		{
			return new AzureDataLoader(CloudStorageAccount.DevelopmentStorageAccount, connectionString);
		}

		public void SetupEnvironment()
		{
			
			//var tableClient = _acct.CreateCloudTableClient();

			//var posts = tableClient.GetTableReference(POST_TABLE);
			//posts.CreateIfNotExists();

			//var tags = tableClient.GetTableReference(TAG_TABLE);
			//tags.CreateIfNotExists();

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

		public void SavePost(Post post)
		{
			var tableClient = _acct.CreateCloudTableClient();

			using (var db = new Context(_cnn))
            {
				db.PostSummaries.Attach(post);
				db.SaveChanges();
			}

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
