using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web404.CMS
{
    internal partial class Context : DbContext
    {
        public Context(string connection_string)
            : base(connection_string)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

    }
}
