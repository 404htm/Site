using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace Web404.AzureCMS
{

		public class PostEntity : TableEntity
		{
			public PostEntity(string URLTitle, DateTime date, PostType type)
			{
				PartitionKey= "*";
				RowKey = "Key";
			}

			public PostType Type { get; set; }
			public bool Active { get; set; }
			public string Title { get; set; }
			public DateTime Date { get; private set; }



	}
}
