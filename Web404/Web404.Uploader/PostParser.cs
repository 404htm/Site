using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web404.AzureCMS;

namespace Web404.Uploader
{
	public class PostParser
	{
		AzureDataLoader _uploader;
		public PostParser(AzureDataLoader uploader)
		{
			_uploader = uploader;
		}

		public void UploadDirectory(string directory)
		{
			var dir = new DirectoryInfo(directory);
			var files = dir.EnumerateFiles();

			foreach(var f in files)
			{
				if(string.Compare(f.Name, "post.html", true) == 0)
				{
					var post  = new PostEntity("test", DateTime.Now, PostType.Article);


					_uploader.SavePost(post);
				}
				else
				{

				}
			}

		}

	}
}
