using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Web404.CMS
{
    public class DataManager
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



		public Page GetArticle(string ID)
		{
			
		}

		public Page GetTagArticleSummaries(string ID)
		{
			using (var db = new Context(_cnn))
			{
				return db.Tags
				.Single(s => s.Name == ID)
				.Pages
				.Select(p => new )
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

		public object GetPage(string pageUrl)
		{
			using (var db = new Context(_cnn))
			{
				return db.Pages
				.Where(p => p.URLName == pageUrl && p.Active)
				.ToList();
			}
		}

		public object GetPage(int PageID)
		{
			using (var db = new Context(_cnn))
			{
				return db.Pages
				.Where(p => p.ID == PageID && p.Active)
				.SingleOrDefault();
			}
		}

		public object GetPageSummaries(string p, int start, int take)
		{
			throw new NotImplementedException();
		}
	}
}
