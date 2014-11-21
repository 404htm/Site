using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Web404.AzureCMS;
using Web404.CMS;

namespace Web404.Uploader
{
	public class PostParser
	{
		IDataLoader _loader;

		public PostParser(IDataLoader dataLoader)
		{
			_loader = dataLoader;
		}

		public void UploadDirectory(string directory)
		{
			var dir = new DirectoryInfo(directory);
			var files = dir.EnumerateFiles().ToList();

			var postFile = files.Single(f => string.Compare(f.Name, "post.html", true) == 0);
			files.Remove(postFile);

			string article;
			var post = parsePost(postFile);
			_loader.SavePost(post);

			foreach(var file in files.Where(f => string.Compare(f.Name, "thumbs.db", true) != 0))
			{
				using(var str = file.OpenRead())
				{
					//_loader.SaveRelatedFile(post.Year, post.ID, file.Name, str);
				}
			}
		}

		PostDetail parsePost(FileInfo file)
		{
			using (var str = file.OpenRead())
			{
				var xml = XDocument.Load(str);
				var head = xml.Root.Element("head");
				var body = xml.Root.Element("body");

				var title = (string)head.Element("title");
				var url = (string)head.Elements("meta").Select(m => m.Attribute("url")).Single(u => u != null);
				var tags = (string)head.Elements("meta").Select(m => m.Attribute("tags")).Single(u => u != null);

				//var post = new PostDetail(url, DateTime.Now, PostType.Article);
				var post = new PostDetail();
				post.Name = url;
				post.Date = DateTime.Now;
				post.Year = post.Date.Year.ToString();


				string fragment = String.Concat(post.Year, "/", post.ID, "/");
				//var storageUrl = _loader.GetFileURI(post.Year, post.Name, file )

				var postSummary = new XElement("div", body.Element("summary").Nodes()).ToString();//.FixLinks(storageUrl).ToString();
				var postBody = new XElement("div", body.Element("article").Nodes()).ToString();//.FixLinks(storageUrl).ToString();
				
				post.Title = title;
				post.Summary = postSummary;
				post.ArticleBody = postBody;
				post.Active = true;
				//post.Tags = tags;

				return post;

			}
			
		}

	}
}
