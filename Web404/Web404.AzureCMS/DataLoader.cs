using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
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

		public void SavePost(PostEntity post)
		{

			CloudStorageAccount storageAccount = CloudStorageAccount.DevelopmentStorageAccount;
			CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

			CloudTable table = tableClient.GetTableReference("posts");
			TableOperation insertOperation = TableOperation.InsertOrReplace(post);

			table.Execute(insertOperation); 

		}
	}
}
