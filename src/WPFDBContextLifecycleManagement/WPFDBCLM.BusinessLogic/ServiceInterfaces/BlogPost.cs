using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDBCLM.BusinessModel;

namespace WPFDBCLM.BusinessLogic.Services
{
    public interface IBlogPostService
    {
        BlogPostModel Get(Guid id);
        Guid? Create(BlogPostModel bp);
    }
}