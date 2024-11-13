using FSK_BusinessObjects;
using FSK_Services;
using System;
using System.Collections.Generic;
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

namespace FengShuiKoi
{
    /// <summary>
    /// Interaction logic for BlogWindow.xaml
    /// </summary>
    public partial class BlogWindow : Window
    {
        private readonly IBlogService iBlogService;
        private readonly string? userId;
        private readonly string? roleName;
        private readonly User? user;


        public BlogWindow(User user)
        {
            InitializeComponent();
            iBlogService = new BlogService();
            this.user = user;
            this.roleName = user.RoleName;
            this.userId = user.UserId;
            InitializeWebView();
        }

        private async void InitializeWebView()
        {
            try
            {
                await webView.EnsureCoreWebView2Async();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing WebView2: " + ex.Message);
            }
        }

        private void LoadBlogList()
        {
            try
            {
                var blogList = iBlogService.GetBlogs();
                dgBlogs.ItemsSource = blogList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading blogs");
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadBlogList();
            switch (roleName?.ToUpper())  // Use null-conditional operator and convert to uppercase for safe comparison
            {
                case "ADMIN":
                    // Admin has full access
                    break;
                case "USER":
                    // User (Staff) has limited access
                    this.btnManageBlog.IsEnabled = false;
                    break;
                default:
                    // Invalid or null role
                    this.Close();
                    break;
            }
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow(user);
            mainWindow.Show();
        }

        private void dgBlogs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgBlogs.SelectedItem is Blog selectedBlog)
            {
                try
                {
                    if (!string.IsNullOrEmpty(selectedBlog.Description))
                    {
                        webView.Source = new Uri(selectedBlog.Description);
                        txtCurrentBlog.Text = selectedBlog.Title;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading blog: {ex.Message}", "Error");
                }
            }
        }

        private void btnManageBlog_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BlogManageWindow blogWindow = new BlogManageWindow(user);
            blogWindow.Show();
        }
    }
}
