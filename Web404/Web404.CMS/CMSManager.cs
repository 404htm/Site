using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Web404.CMS
{
    public class CmsManager : ICmsManager
    {
        string _cnn;
		IFileManger _fileManager;

		const int DEFAULT_PAGE_COUNT = 15;

        public CmsManager(string connectionString, IFileManger fileManager)
        {
            _cnn = connectionString;
			_fileManager = fileManager;
        }


        public List<Post> GetPosts(int start = 0, int? pageCount = null)
        {
            using (var db = new Context(_cnn))
            {
				var take = pageCount ?? DEFAULT_PAGE_COUNT;

                return db.Posts
				.Skip(() => start)
				.Take(() => take)
				.ToList();
            }
        }


		//public List<PageSummary> GetTagArticleSummaries(string tag, int start = 0, int? pageCount = null)
		//{
		//	using (var db = new Context(_cnn))
		//	{
		//		var take = pageCount ?? DEFAULT_PAGE_COUNT;

		//		return db
		//		.Posts
		//		.Where(p => p.Tags.Where(t => t.Name == tag).Any())
		//		.Where(p => p.Active)
		//		.OrderByDescending(p => p.Date)
		//		.Skip(() => start)
		//		.Take(() => take)
		//		.Select(p => new PageSummary
		//		{
		//			Summary = p.Summary,
		//			Date = p.Date,
		//			ID = p.ID,
		//			Tags = p.Tags.ToList(),
		//			Section = p.PostType.Name,
		//			Title = p.Title,
		//			URLName = p.URLName
		//		})
		//		.ToList();
		//	}
		//}

		//public Post GetSectionDefaultPage(string sectionName)
		//{
		//	using (var db = new Context(_cnn))
		//	{
		//		return db.Sections
		//		.Single(s => s.Name == sectionName)
		//		.Posts
		//		.Where(p => p.URLName == "index")
		//		.SingleOrDefault();
		//	}
		//}

		//public List<Post> GetSectionPages(string sectionName)
		//{
		//	using (var db = new Context(_cnn))
		//	{
		//		return db.Sections
		//		.Single(s => s.Name == sectionName)
		//		.Posts
		//		.Where(p => p.Active)
		//		.ToList();
		//	}
		//}

		public Post GetPost(string partition, string pageUrl)
		{
			using (var db = new Context(_cnn))
			{
				return db.Posts
				.SingleOrDefault(p => p.SID == pageUrl && p.Partition == partition && p.Active);
			}
		}

		public Post GetPost(int PageID)
		{
			using (var db = new Context(_cnn))
			{
				return db.Posts
				.SingleOrDefault(p => p.ID == PageID && p.Active);
			}
		}

		public IEnumerable<PostSummary> GetPostSummaries(int start = 0, int? pageCount = null)
		{
			using (var db = new Context(_cnn))
			{
				var take = pageCount ?? DEFAULT_PAGE_COUNT;

				return db.PostSummaries
				.OrderByDescending(p => p.Date)
				.Where(p => p.Active)
				.Skip(() => start)
				.Take(() => take)
				.ToList();
			}
		}

		public string GetPostContent(string year, string title)
		{
			return _fileManager.GetPostContent(year, title);
		}
	}
}
