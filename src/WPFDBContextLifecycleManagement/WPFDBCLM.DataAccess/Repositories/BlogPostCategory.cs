using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDBCLM.BusinessModel;
using WPFDBCLM.DataAccess.EntityFramework;

namespace WPFDBCLM.DataAccess.Repositories
{
    /// <summary>
    /// Class to access to category data
    /// </summary>
    public sealed class BlogPostCategoryRepository : IBlogPostCategoryRepository
    {
        private  BlogDbContext _dbContext;

        public BlogPostCategoryRepository(System.Data.Common.DbConnection dbc)
        {
            _dbContext = new BlogDbContext(dbc);
        }

        /// <summary>
        /// Liste all categories
        /// </summary>
        /// <returns></returns>
        public List<BlogPostCategoryModel> ListAll()
        {
            List<BlogPostCategoryModel> ret = new List<BlogPostCategoryModel>();
            foreach (BlogCategory c in (from m in _dbContext.BlogCategories
                                        orderby m.Name ascending
                                        select m).ToList())
            {
                ret.Add((BlogPostCategoryModel)c);
            }
            return ret;
        }
    }
}