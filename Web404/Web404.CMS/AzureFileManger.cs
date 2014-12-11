using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Web404.CMS
{
	public class AzureFileManger : Web404.CMS.IFileManger
	{
		const string POST_CONTAINER = "posts";
		const string POST_FILE_CONTAINER = "files";
		CloudStorageAccount _acct;

		private AzureFileManger(CloudStorageAccount acct)
		{
			_acct = acct;
		}

		public static AzureFileManger CreateDev()
		{
			return new AzureFileManger(CloudStorageAccount.DevelopmentStorageAccount);
		}

		public static AzureFileManger Create(string storage_cnn)
		{
			var acct = CloudStorageAccount.Parse(storage_cnn);
			return new AzureFileManger(acct);
		}

		public void SetupEnvironment()
		{
			var blobClient = _acct.CreateCloudBlobClient();

			var container = blobClient.GetContainerReference(POST_FILE_CONTAINER);
			container.CreateIfNotExists();

			
			BlobContainerPermissions containerPermissions = new BlobContainerPermissions();
			containerPermissions.PublicAccess = BlobContainerPublicAccessType.Blob;
			container.SetPermissions(containerPermissions);
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
