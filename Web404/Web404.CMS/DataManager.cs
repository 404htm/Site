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


    }
}
