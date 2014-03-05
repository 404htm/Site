using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web404.CMS
{
    public class Script
    {
        public int ID { get; set; }
        public string Name {get; set;}
        public string Description { get; set; }
        public virtual IEnumerable<ScriptContent> Content { get; set; }

    }
}
