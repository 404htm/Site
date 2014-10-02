using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace Web404.AzureCMS
{
	public class TagIndex : TableEntity
	{
		public TagIndex(string tag, string postPartition, string postID)
		{
			this.PartitionKey = tag.Trim();
			this.RowKey = String.Format("{0}|{1}", postPartition, postID);
		}

		public string TagName { get {  return this.PartitionKey; } }
		public string PostPartition { get {  return RowKey.Split('|')[0]; } }
		public string PostID { get { return RowKey.Split('|')[1]; } }
	}
}
