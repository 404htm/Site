using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web404.CMS
{
	public class PageSummary
	{
		public int ID { get; set; }
		public System.DateTime Date { get; set; }
		public string Title { get; set; }
		public string URLName { get; set; }
		public string Description { get; set; }
		public string Summary { get; set; }

		public List<Tag> Tags { get; set; }
		public string Section { get; set; }

		public bool IsComplete { get; set; }
	}
}
