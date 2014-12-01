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


        public IList<Post> GetPosts(int start = 0, int? pageCount = null)
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


		public IList<PostSummary> GetTagPostSummaries(string tag, int start = 0, int? pageCount = null)
		{
			using (var db = new Context(_cnn))
			{
				var take = pageCount ?? DEFAULT_PAGE_COUNT;
				
				var summaries = db.Tags
					.Where(t => t.Name == tag)
					.SelectMany(t => t.Posts)
					.Join(db.PostSummaries, ps => ps.ID, p => p.ID, (p, ps) => ps)
					.OrderByDescending(ps => ps.Date)
					.Skip(start)
					.Take(take)
					.ToList();

				return summaries;
			}
		}

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
				//Enumerate so the include isn't ignored
				return db.Posts
				.Include("Tags")
				.Where(p => p.SID == pageUrl && p.Partition == partition && p.Active)
				.ToList()
				.SingleOrDefault();
			}
		}

		public Post GetPost(int PageID)
		{
			using (var db = new Context(_cnn))
			{
				//Enumerate so the include isn't ignored
				return db.Posts
				.Include("Tags")
				.Where(p => p.ID == PageID && p.Active)
				.ToList()
				.SingleOrDefault();
				
			}
		}

		public IList<PostSummary> GetPostSummaries(int start = 0, int? pageCount = null)
		{
			using (var db = new Context(_cnn))
			{
				var take = pageCount ?? DEFAULT_PAGE_COUNT;

				var results = db.PostSummaries
				.OrderByDescending(p => p.Date)
				.Where(p => p.Active)
				.Skip(() => start)
				.Take(() => take)
				.ToList();

				return results;
			}
		}

		public string GetPostContent(string partition, string sid)
		{
			using (var db = new Context(_cnn))
			{
				return db.Posts
				.Where(p => p.SID == sid && p.Partition == partition && p.Active)
				.Select(p => p.Body)
				.SingleOrDefault();
			}
		}
	}
}
