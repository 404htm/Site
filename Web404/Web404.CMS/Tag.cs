using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web404.CMS
{
    public class Tag
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? HomePageID { get; set; }
        public virtual Page HomePage {get; set;}
        public virtual IEnumerable<Page> Pages { get; set; }
    }
}
