using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web404.CMS
{
    public class DataManager
    {
        string _cnn;
        public DataManager(string connectionString)
        {
            _cnn = connectionString;
            
        }


        public List<Page> GetPages()
        {
            using (var db = new Context(_cnn))
            {
                return db.Pages.ToList();
            }
        }



		public Page GetArticle(string ID)
		{
			throw new NotImplementedException();
		}

		public Page GetTagArticleSummaries(string ID)
		{
			throw new NotImplementedException();
		}

		public Page GetSectionDefaultPage(string p)
		{
			throw new NotImplementedException();
		}

		public Page GetSectionPages(string p)
		{
			throw new NotImplementedException();
		}

		public object GetPage(string ID)
		{
			throw new NotImplementedException();
		}

		public object GetPageSummaries(string p, int start, int take)
		{
			throw new NotImplementedException();
		}
	}
}
