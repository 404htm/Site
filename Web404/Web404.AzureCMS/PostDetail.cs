using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web404.Common;

namespace Web404.AzureCMS
{
	public class PostDetail : PostSummary, IPostDetail
	{
		public string ArticleBody { get; set; }
	}
}
