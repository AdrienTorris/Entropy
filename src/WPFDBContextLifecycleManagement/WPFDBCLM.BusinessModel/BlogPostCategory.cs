using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDBCLM.BusinessModel
{
    public sealed class BlogPostCategoryModel
    {
        public int Id { get; }
        public string Name { get; }

        public BlogPostCollectionModel BlogPosts { get; }

        public BlogPostCategoryModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public sealed class BlogPostCategoryCollectionModel : List<BlogPostCategoryModel>
    {
        public BlogPostCategoryCollectionModel()
        { }
    }
}