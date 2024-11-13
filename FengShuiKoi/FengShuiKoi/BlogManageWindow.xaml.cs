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
    /// Interaction logic for BlogManageWindow.xaml
    /// </summary>
    public partial class BlogManageWindow : Window
    {
        private readonly string? userId;
        private readonly User? user;
        private readonly IBlogService blogService;
        public BlogManageWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            this.userId = user.UserId;
            blogService = new BlogService();
        }

        public void LoadBlogList()
        {
            try
            {
                var blogList = blogService.GetBlogs();
                dgData.ItemsSource = blogList;
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show(ex.Message, "Error on load list of blogs");
                }
            }
            finally
            {
                resetInput();
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Blog blog = new Blog();
                blog.BlogId = txtBlogID.Text;
                blog.Title = txtTitle.Text;
                blog.Description = txtDescription.Text;
                blog.UserId = userId;
                blog.CreatedDate = dpCreatedDate.SelectedDate.HasValue
                                        ? DateOnly.FromDateTime(dpCreatedDate.SelectedDate.Value)
                                        : DateOnly.FromDateTime(DateTime.Now);
                blogService.CreateBlog(blog);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Create blog success!");
                LoadBlogList();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtBlogID.Text.Length > 0)
                {
                    Blog blog = new Blog();
                    blog.BlogId = txtBlogID.Text;
                    blog.Title = txtTitle.Text;
                    blog.Description = txtDescription.Text;
                    blog.UserId = userId;
                    blog.CreatedDate = dpCreatedDate.SelectedDate.HasValue
                                        ? DateOnly.FromDateTime(dpCreatedDate.SelectedDate.Value)
                                        : DateOnly.FromDateTime(DateTime.Now);
                    blogService.UpdateBlog(blog);
                }
                else
                {
                    
                    MessageBox.Show("You must select a blog!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Update blog success!");
                LoadBlogList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                    Blog blog = new Blog();
                    blog.BlogId = txtBlogID.Text;
                    blog.Title = txtTitle.Text;
                    blog.Description = txtDescription.Text;
                    blog.UserId = userId;
                    blog.CreatedDate = dpCreatedDate.SelectedDate.HasValue
                                        ? DateOnly.FromDateTime(dpCreatedDate.SelectedDate.Value)
                                        : DateOnly.FromDateTime(DateTime.Now);
                    blogService.DeleteBlog(blog);
                    MessageBox.Show("Delete blog success!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadBlogList();
            }

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dataGrid = sender as DataGrid;
                if (dataGrid == null || dataGrid.SelectedIndex < 0) return;

                var selectedItem = dataGrid.SelectedItem as Blog;
                if (selectedItem != null)
                {
                    txtBlogID.Text = selectedItem.BlogId.ToString();
                    txtTitle.Text = selectedItem.Title.ToString();
                    txtDescription.Text = selectedItem.Description.ToString();
                    dpCreatedDate.Text = selectedItem.CreatedDate.ToString();
                }
            }
            catch (Exception ex)
            {
                // Silently handle the error to prevent disrupting the UI
                Console.WriteLine($"Error in selection changed: {ex.Message}");
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BlogWindow blogWindow = new BlogWindow(user);
            blogWindow.Show();
        }

        private void resetInput()
        {
            txtBlogID.Text = "";
            txtTitle.Text = "";
            txtDescription.Text = "";
            dpCreatedDate.Text = "";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadBlogList();
        }
    }
}
