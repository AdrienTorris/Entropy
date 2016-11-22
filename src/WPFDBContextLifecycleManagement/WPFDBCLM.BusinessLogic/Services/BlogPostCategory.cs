using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDBCLM.BusinessModel;
using WPFDBCLM.DataAccess.Repositories;

namespace WPFDBCLM.BusinessLogic.Services
{
    public sealed class BlogPostCategoryService : IBlogPostCategoryService
    {
        private readonly IBlogPostCategoryRepository _repo;

        public BlogPostCategoryService(System.Data.Common.DbConnection dbc)
        {
            _repo = new BlogPostCategoryRepository(dbc);
        }

        public List<BlogPostCategoryModel> ListAll()
        {
            return _repo.ListAll();
        }
    }
}