using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDBCLM.BusinessModel;

namespace WPFDBCLM.BusinessLogic.Services
{
    public interface IBlogPostCategoryService
    {
        BlogPostCategoryCollectionModel ListAll();
    }
}