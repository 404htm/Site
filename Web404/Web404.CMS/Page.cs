using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web404.CMS
{
    public class Page
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string URLName { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Script> SummaryScripts { get; set; }
        public virtual ICollection<Script> Scripts { get; set; }
    }
}
