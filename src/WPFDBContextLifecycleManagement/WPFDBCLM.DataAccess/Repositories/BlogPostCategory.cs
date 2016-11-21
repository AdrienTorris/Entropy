using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDBCLM.BusinessModel;
using WPFDBCLM.DataAccess.EntityFramework;

namespace WPFDBCLM.DataAccess.Repositories
{
    public sealed class BlogPostCategoryRepository : IBlogPostCategoryRepository
    {
        private readonly BlogDbContext _dbContext;

        public BlogPostCategoryRepository(System.Data.Common.DbConnection dbc)
        {
            _dbContext = new BlogDbContext(dbc);
        }

        /// <summary>
        /// Liste all categories
        /// </summary>
        /// <returns></returns>
        public BlogPostCategoryCollectionModel ListAll()
        {
            BlogPostCategoryCollectionModel ret = new BlogPostCategoryCollectionModel();
            ret.Add(new BlogPostCategoryModel(1, "Category 1", DateTime.Now));
            ret.Add(new BlogPostCategoryModel(2, "Category 2", DateTime.Now.AddDays(-1)));
            ret.Add(new BlogPostCategoryModel(3, "Category 3", DateTime.Now.AddDays(-2)));
            ret.Add(new BlogPostCategoryModel(4, "Category 4", DateTime.Now.AddDays(-5)));
            ret.Add(new BlogPostCategoryModel(5, "Category 5", DateTime.Now.AddDays(-7)));
            ret.Add(new BlogPostCategoryModel(6, "Category 6", DateTime.Now.AddDays(-14)));
            return ret;
        }
    }
}