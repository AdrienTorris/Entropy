using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDBCLM.DataAccess.EntityFramework;

namespace WPFDBCLM.DataAccess.Repositories
{
    public sealed class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogDbContext _dbContext;

        public BlogPostRepository(System.Data.Common.DbConnection dbc)
        {
            _dbContext = new BlogDbContext(dbc);
        }
    }
}