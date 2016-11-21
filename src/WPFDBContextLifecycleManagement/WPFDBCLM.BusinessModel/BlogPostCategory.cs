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
        public DateTime CreationDate { get; }

        public BlogPostCollectionModel BlogPosts { get; }

        public BlogPostCategoryModel(int id, string name, DateTime creationDate)
        {
            Id = id;
            Name = name;
            CreationDate = creationDate;
        }
    }

    public sealed class BlogPostCategoryCollectionModel : List<BlogPostCategoryModel>
    {
        public BlogPostCategoryCollectionModel()
        { }
    }
}