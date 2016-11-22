using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDBCLM.DataAccess.EntityFramework
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbConnection dbc)
            : base(dbc, false)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<BlogPost> BlogPosts { get; set; }
        public virtual DbSet<BlogCategory> BlogCategories { get; set; }
    }
}