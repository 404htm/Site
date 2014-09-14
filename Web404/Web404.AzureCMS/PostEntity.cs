using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.WindowsAzure.Storage.Table;

namespace Web404.AzureCMS
{

		public class PostEntity : TableEntity
		{
			public PostEntity(string URLTitle, DateTime date, PostType type)
			{
				PartitionKey= "*";
				RowKey = URLTitle;
			}

			public PostType Type { get; set; }
			public DateTime Date { get; private set; }
			public bool Active { get; set; }
			public string Title { get; set; }
			public string Summary { get; set; }
			public string Tags { get; set;}



	}
}
