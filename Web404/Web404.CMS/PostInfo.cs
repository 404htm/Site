using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web404.CMS
{
	public enum PostType { Main, Article, Tool, Snippet}

	public class PostInfo
	{
		public PostType Type { get; set;}
		public string URLName { get; set; }
		public DateTime Date { get; set; }

		public bool Active { get; set; }
	}
}
