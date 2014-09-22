﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.WindowsAzure.Storage.Table;
using Web404.Common;

namespace Web404.AzureCMS
{
	public class PostSummary : TableEntity, IPostSummary
	{
		public PostSummary()
		{

		}

		public PostSummary(string URLTitle, DateTime date, PostType type)
		{
			PartitionKey= date.Year.ToString();
			RowKey = URLTitle;
			Type = type;
		}

		public PostType Type { get; set; }
		public DateTime Date { get; private set; }
		public bool Active { get; set; }
		public string Title { get; set; }
		public string Summary { get; set; }
		public string Tags { get; set;}
	}
}
