using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFDBCLM.BusinessModel;
using WPFDBCLM.Controllers;
using static WPFDBCLM.Controllers.AddBlogPostController;
using WPFDBCLM.Controllers.Extensions;

namespace WPFDBCLM.Presentation.UI.WPF
{
    /// <summary>
    /// Logique d'interaction pour AddPost.xaml
    /// </summary>
    public partial class AddPost : Window
    {
        #region Pprts & Ctor

        /// <summary>
        /// Controller who manages data workflow needed by this form
        /// </summary>
        private readonly IController _controller;

        /// <summary>
        /// List of available categories for a new blog post
        /// </summary>
        public List<BlogPostCategoryModel> AvailableCategories { get; set; }

        /// <summary>
        /// Form's new instance
        /// </summary>
        public AddPost()
        {
            InitializeComponent();

            _controller = new AddBlogPostController(ConfigurationManager.ConnectionStrings["DefaultCon"].ConnectionString);

            AvailableCategories = new BlogPostCategoryCollectionModel();
            AvailableCategories = _controller.Invoke<List<BlogPostCategoryModel>>(OperationEnum.ListAllCategories);
        }

        #endregion

        #region Events

        /// <summary>
        /// Executed when user clicks on the validation button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Guid? articleId = _controller.Invoke<Guid?>(OperationEnum.Create, new object[] { new BlogPostModel(txt_Title.Text, (int)cb_Category.SelectedValue) });
        }

        /// <summary>
        /// Executed when the user changes the selection of the categories dropdownlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        #endregion

        #region Internal logic

        #endregion
    }
}