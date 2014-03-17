using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Configuration; 

namespace Web404.CMS
{
    public class Context : DbContext
    {
       public Context(string connectionString)
            : base(connectionString)
        {

        }

        public Context()
            : base(ConfigurationManager.ConnectionStrings["AzureSQL"].ConnectionString)
        {

        }

        public DbSet<Page> Pages { get; set; }
        public DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Page>()
                .HasMany<Tag>(c => c.Tags)
                .WithMany() 
                .Map(x =>
                {
                    x.MapLeftKey("PageID");
                    x.MapRightKey("TagID");
                    x.ToTable("PageTags");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
