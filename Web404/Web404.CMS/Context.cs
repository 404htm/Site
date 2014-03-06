using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure; 

namespace Web404.CMS
{
    public class Context : DbContext
    {
        internal Context(string connectionString)
            : base(connectionString)
        {

        }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
