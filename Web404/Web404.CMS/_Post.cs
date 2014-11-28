using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web404.CMS
{
	public partial class Post : IPostSummary
	{
		string IPostSummary.TagList 
		{
			//TODO: Figure out why non-explicit implementation isn't working here
			get { return string.Join(",", Tags.Select(t => t.Name)); }
		}
	}
}
