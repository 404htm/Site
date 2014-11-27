using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web404.CMS
{
	public partial class Post : IPostSummary
	{
		public string TagsList {get { return string.Join(",", Tags.Select(t => t.Name)); }}
	}
}
