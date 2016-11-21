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

namespace WPFDBCLM.Presentation.UI.WPF
{
    /// <summary>
    /// Logique d'interaction pour AddPost.xaml
    /// </summary>
    public partial class AddPost : Window
    {
        private readonly IController _controller;

        public BlogPostCategoryCollectionModel AvailableCategories { get; set; }

        public AddPost()
        {
            InitializeComponent();

            _controller = new AddBlogPostController(ConfigurationManager.ConnectionStrings["ValorisPOC"].ConnectionString);

            AvailableCategories = new BlogPostCategoryCollectionModel();
            AvailableCategories = _controller.Invoke<BlogPostCategoryCollectionModel>(OperationEnum.ListAllCategories);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}