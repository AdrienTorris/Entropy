using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDBCLM.BusinessModel;
using WPFDBCLM.DataAccess.Repositories;

namespace WPFDBCLM.BusinessLogic.Services
{
    public sealed class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _repo;

        public BlogPostService(System.Data.Common.DbConnection dbc)
        {
            _repo = new BlogPostRepository(dbc);
        }

        public BlogPostModel Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Guid? Create(BlogPostModel bp)
        {
            throw new NotImplementedException();
        }
    }
}