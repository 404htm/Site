using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;

namespace Web404.AzureCMS
{
	public class AzureDataLoader
	{
		string _cnn;

		public AzureDataLoader(string cnn)
		{
			_cnn = cnn;
		}

		public void SavePost(PostEntity post, Stream postBody)
		{

			var storageAccount = CloudStorageAccount.DevelopmentStorageAccount;
			var tableClient = storageAccount.CreateCloudTableClient();

			CloudTable table = tableClient.GetTableReference("posts");
			var insertOperation = TableOperation.InsertOrReplace(post);

			table.Execute(insertOperation); 

			var blobClient = storageAccount.CreateCloudBlobClient();
			var container = blobClient.GetContainerReference("posts");
			var blob = container.GetBlockBlobReference("2014/FirstPost.html");
			blob.UploadFromStream(postBody);

		}

	}
}
