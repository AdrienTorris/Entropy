namespace WPFDBCLM.Controllers
{
    using System;
    using BusinessLogic.Services;

    /// <summary>
    /// Implement here the system methods to
    /// </summary>
    public sealed partial class AddBlogPostController : BaseController//, IController
    {
        #region Pprts & Ctor

        /// <summary>
        /// Service to deal with blog posts
        /// </summary>
        private IBlogPostService _blogPostService;

        /// <summary>
        /// Service to deal with categories
        /// </summary>
        private IBlogPostCategoryService _blogPostCategoryService;

        /// <summary>
        /// Instanciate new instance
        /// </summary>
        /// <param name="connectionString">db connection string</param>
        public AddBlogPostController(string connectionString)
            : base(connectionString)
        { }

        #endregion

        #region System

        /// <summary>
        /// Initialization of all the services this controller needs
        /// </summary>
        /// <param name="dbc"></param>
        public override void InitServices(System.Data.Common.DbConnection dbc)
        {
            _blogPostService = new BlogPostService(dbc);
            _blogPostCategoryService = new BlogPostCategoryService(dbc);
        }

        #endregion
    }
}