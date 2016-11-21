using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDBCLM.BusinessModel;

namespace WPFDBCLM.DataAccess.Repositories
{
    public interface IBlogPostCategoryRepository
    {
        /// <summary>
        /// Liste all categories
        /// </summary>
        /// <returns></returns>
        BlogPostCategoryCollectionModel ListAll();
    }
}