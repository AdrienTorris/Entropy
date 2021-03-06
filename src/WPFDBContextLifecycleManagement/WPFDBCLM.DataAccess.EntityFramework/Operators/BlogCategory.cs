﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDBCLM.BusinessModel;

namespace WPFDBCLM.DataAccess.EntityFramework
{
    public partial class BlogCategory
    {
        public static explicit operator BlogPostCategoryModel(BlogCategory ctg)
        {
            return new BlogPostCategoryModel(ctg.Id, ctg.Name);
        }
    }
}