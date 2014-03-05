using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web404.CMS
{
    public class ScriptContent
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int Version { get; set; }
        public string Content { get; set; }
        public string Notes { get; set; }
    }
}
