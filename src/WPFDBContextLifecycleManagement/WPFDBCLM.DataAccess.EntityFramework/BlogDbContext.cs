using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDBCLM.DataAccess.EntityFramework
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(System.Data.Common.DbConnection dbc) : base(dbc, false)
        { }

        public virtual DbSet<BlogPost> BlogPostSet { get; set; }
        public virtual DbSet<BlogPostCategory> BlogPostCategorySet { get; set; }
    }
}