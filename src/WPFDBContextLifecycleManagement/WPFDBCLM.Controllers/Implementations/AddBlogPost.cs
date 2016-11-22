namespace WPFDBCLM.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using BusinessModel;

    /// <summary>
    /// Implement here your implementation of the controller who manage blog post creation
    /// </summary>
    public sealed partial class AddBlogPostController
    {
        /// <summary>
        /// List of available operations in this controller
        /// This is the list of exposed methods from this controller, it needs to be up to date
        /// </summary>
        public enum OperationEnum
        {
            [Description("List all undeleted categories ordered by name alphabetical asc")]
            ListAllCategories = 1,
            [Description("Create new blog post")]
            Create = 2
        }

        #region Get methods

        /// <summary>
        /// List all categories available for a new post
        /// </summary>
        /// <returns></returns>
        public List<BlogPostCategoryModel> ListAllCategories()
        {
            return _blogPostCategoryService.ListAll();
        }

        #endregion

        #region Post methods

        public Guid? Create(BlogPostModel bp)
        {
            return _blogPostService.Create(bp);
        }

        #endregion
    }
}