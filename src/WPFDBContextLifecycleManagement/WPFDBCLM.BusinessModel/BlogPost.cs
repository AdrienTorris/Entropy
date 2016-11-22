namespace WPFDBCLM.BusinessModel
{
    using System;
    using System.Collections.Generic;

    public sealed class BlogPostModel
    {
        public Guid Id { get; }
        public string Title { get; }
        public int CategoryId { get; }
        public DateTime CreationDate { get; }

        public BlogPostCategoryModel Category { get; }

        public BlogPostModel(string title, int categoryId)
        {
            CategoryId = categoryId;
            Title = title;
        }
    }

    public sealed class BlogPostCollectionModel : List<BlogPostModel>
    {
        public BlogPostCollectionModel()
        { }
    }
}