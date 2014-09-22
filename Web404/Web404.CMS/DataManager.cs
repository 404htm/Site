using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
//using Web404.Common;

namespace Web404.CMS
{
    public class DataManager //: ICmsManager
    {
        string _cnn;
		const int DEFAULT_PAGE_COUNT = 15;

        public DataManager(string connectionString)
        {
            _cnn = connectionString;
        }


        public List<Page> GetPages(int start = 0, int? pageCount = null)
        {
            using (var db = new Context(_cnn))
            {
				var take = pageCount ?? DEFAULT_PAGE_COUNT;

                return db.Pages
				.Skip(() => start)
				.Take(() => take)
				.ToList();
            }
        }


		public List<PageSummary> GetTagArticleSummaries(string tag, int start = 0, int? pageCount = null)
		{
			using (var db = new Context(_cnn))
			{
				var take = pageCount ?? DEFAULT_PAGE_COUNT;

				return db
				.Pages
				.Where(p => p.Tags.Where(t => t.Name == tag).Any())
				.Where(p => p.Active)
				.OrderByDescending(p => p.Date)
				.Skip(() => start)
				.Take(() => take)
				.Select(p => new PageSummary
				{
					Summary = p.Summary,
					Date = p.Date,
					Description = p.Description,
					ID = p.ID,
					Tags = p.Tags.ToList(),
					Section = p.Section.Name,
					Title = p.Title,
					URLName = p.URLName
				})
				.ToList();
			}
		}

		public Page GetSectionDefaultPage(string sectionName)
		{
			using (var db = new Context(_cnn))
			{
				return db.Sections
				.Single(s => s.Name == sectionName)
				.Pages
				.Where(p => p.URLName == "index")
				.SingleOrDefault();
			}
		}

		public List<Page> GetSectionPages(string sectionName)
		{
			using (var db = new Context(_cnn))
			{
				return db.Sections
				.Single(s => s.Name == sectionName)
				.Pages
				.Where(p => p.Active)
				.ToList();
			}
		}

		public Page GetPage(string pageUrl)
		{
			using (var db = new Context(_cnn))
			{
				return db.Pages
				.SingleOrDefault(p => p.URLName == pageUrl && p.Active);
			}
		}

		public object GetPage(int PageID)
		{
			using (var db = new Context(_cnn))
			{
				return db.Pages
				.SingleOrDefault(p => p.ID == PageID && p.Active);
			}
		}

		public List<PageSummary> GetPageSummaries(int start = 0, int? pageCount = null)
		{
			using (var db = new Context(_cnn))
			{
				var take = pageCount ?? DEFAULT_PAGE_COUNT;

				return db.Pages
				.OrderByDescending(p => p.Date)
				.Where(p => p.Active)
				.Skip(() => start)
				.Take(() => take)
				.Select(p => new PageSummary
					{
						Summary = p.Summary??p.Content,
						IsComplete = p.Summary == null,
						Date = p.Date,
						Description = p.Description,
						ID = p.ID,
						Tags = p.Tags.ToList(),
						Section = p.Section.Name,
						Title = p.Title,
						URLName = p.URLName
					})
				.ToList();
			}
		}

		public string GetPageContent(string ID)
		{
			using (var db = new Context(_cnn))
			{
				return db.Pages
				.Where(p => p.URLName == ID && p.Active)
				.Select(p => p.Content)
				.SingleOrDefault();
			}
		}
	}
}
