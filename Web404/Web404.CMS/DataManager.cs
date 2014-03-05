using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web404.CMS
{
    public class DataManager
    {
        public List<Page> GetPages()
        {
            using (var db = new Context())
            {
                return db.Pages.ToList();
            }
           

        }
    }
}
