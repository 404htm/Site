//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web404.CMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Page
    {
        public Page()
        {
            this.Scripts = new HashSet<Script>();
            this.Styles = new HashSet<Style>();
            this.Tags = new HashSet<Tag>();
            this.Tags1 = new HashSet<Tag>();
        }
    
        public int ID { get; set; }
        public System.DateTime Date { get; set; }
        public string Title { get; set; }
        public string URLName { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public bool Active { get; set; }
        public Nullable<int> SectionID { get; set; }
    
        public virtual ICollection<Script> Scripts { get; set; }
        public virtual ICollection<Style> Styles { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual Section Section { get; set; }
        public virtual ICollection<Tag> Tags1 { get; set; }
    }
}
