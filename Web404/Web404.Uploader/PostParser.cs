using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Web404.AzureCMS;
using Web404.Common;

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
			var files = dir.EnumerateFiles().ToList();

			var postFile = files.Single(f => string.Compare(f.Name, "post.html", true) == 0);
			files.Remove(postFile);

			string article;
			var post = parsePost(postFile, out article);
			_uploader.SavePost(post, article);

			foreach(var file in files.Where(f => string.Compare(f.Name, "thumbs.db", true) != 0))
			{
				using(var str = file.OpenRead())
				{
					_uploader.SaveRelatedFile(post, file.Name, str);
				}
			}
		}

		PostSummary parsePost(FileInfo file, out string article)
		{
			using (var str = file.OpenRead())
			{
				var xml = XDocument.Load(str);
				var head = xml.Root.Element("head");
				var body = xml.Root.Element("body");

				var title = (string)head.Element("title");
				var url = (string)head.Elements("meta").Select(m => m.Attribute("url")).Single(u => u != null);
				var tags = (string)head.Elements("meta").Select(m => m.Attribute("tags")).Single(u => u != null);

				var post = new PostSummary(url, DateTime.Now, PostType.Article);

				string fragment = String.Concat(post.Partition, "/", post.ID, "/");
				var storageUrl = new Uri(_uploader.StorageEndpoint, fragment).ToString();

				var summary = new XElement("div", body.Element("summary").Nodes()).FixLinks(storageUrl).ToString();
				article = new XElement("div", body.Element("article").Nodes()).FixLinks(storageUrl).ToString();
				
				post.Title = title;
				post.Summary = summary;
				post.Active = true;
				post.Tags = tags;

				return post;

			}
			
		}

	}
}
