using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web404.CMS
{
	public class AzureDataManager
	{
		 string _cnn;
		const int DEFAULT_PAGE_COUNT = 15;


        public AzureDataManager(string connectionString)
        {
            _cnn = connectionString;
        }


	}
}
