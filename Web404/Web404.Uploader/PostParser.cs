using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
					
					var xml = XDocument.Load(f.OpenRead());
					var head = xml.Root.Element("head");
					var body = xml.Root.Element("body");

					var title = (string)head.Element("title");
					var url = (string)head.Elements("meta").Select(m => m.Attribute("url")).Single(u => u!= null);
					var tags = (string)head.Elements("meta").Select(m => m.Attribute("tags")).Single(u => u != null);

					var summary = (string)body.Element("summary");
					var article = (string)body.Element("article");
					

					var post = new PostEntity(url, DateTime.Now, PostType.Article);
					post.Title = title;
					post.Summary = summary;
					post.Active =true;
					post.Tags = tags;

					var ms = new MemoryStream(Encoding.UTF8.GetBytes(article));
					_uploader.SavePost(post, ms);
				}
				else
				{
					//_uploader.SaveFile();
				}
			}

		}

	}
}
