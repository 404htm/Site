using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.WindowsAzure.Storage.Table;

namespace Web404.CMS
{
	public class PostSummary
	{
		public PostSummary()
		{
			
		}

		public PostSummary(string URLTitle, DateTime date, PostType type)
		{
			Year = date.Year.ToString();
			Name = URLTitle;
			Type = type;
			Date = date;
		}

		public int ID { get; set;}
		public string Name { get; set;}

		public string Year { get; set;}
		public PostType Type { get; set; }
		public DateTime Date { get; set; }
		public bool Active { get; set; }
		public string Title { get; set; }
		public string Summary { get; set; }
		public List<Tag> Tags { get; set;}
	}
}
