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

        private string GenerateNewBlogId()
        {
            Random random = new Random();
            int number = random.Next(1, 10000);
            return $"BL{number:D4}";
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title cannot be empty!", "Validation Error");
                txtTitle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Description cannot be empty!", "Validation Error");
                txtDescription.Focus();
                return false;
            }

            if (!dpCreatedDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select a valid date!", "Validation Error");
                dpCreatedDate.Focus();
                return false;
            }

            return true;
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
                MessageBox.Show(ex.Message, "Error on load list of blogs");
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
                if (!ValidateInput())
                {
                    return;
                }

                // Check if blog with same title exists using service
                var existingBlog = blogService.GetBlogByTitle(txtTitle.Text.Trim());
                if (existingBlog != null)
                {
                    MessageBox.Show("A blog with this title already exists!", "Validation Error");
                    txtTitle.Focus();
                    return;
                }

                Blog blog = new Blog();
                blog.BlogId = GenerateNewBlogId();
                blog.Title = txtTitle.Text.Trim();
                blog.Description = txtDescription.Text.Trim();
                blog.UserId = userId;
                blog.CreatedDate = dpCreatedDate.SelectedDate.HasValue
                                        ? DateOnly.FromDateTime(dpCreatedDate.SelectedDate.Value)
                                        : DateOnly.FromDateTime(DateTime.Now);

                blogService.CreateBlog(blog);
                MessageBox.Show("Create blog success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                LoadBlogList();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBlogID.Text))
                {
                    MessageBox.Show("You must select a blog to update!", "Validation Error");
                    return;
                }

                if (!ValidateInput())
                {
                    return;
                }

                // Check if blog with same title exists using service
                var existingBlog = blogService.GetBlogByTitle(txtTitle.Text.Trim());
                if (existingBlog != null && existingBlog.BlogId != txtBlogID.Text)
                {
                    MessageBox.Show("A blog with this title already exists!", "Validation Error");
                    txtTitle.Focus();
                    return;
                }

                Blog blog = new Blog();
                blog.BlogId = txtBlogID.Text;
                blog.Title = txtTitle.Text.Trim();
                blog.Description = txtDescription.Text.Trim();
                blog.UserId = userId;
                blog.CreatedDate = dpCreatedDate.SelectedDate.HasValue
                                        ? DateOnly.FromDateTime(dpCreatedDate.SelectedDate.Value)
                                        : DateOnly.FromDateTime(DateTime.Now);

                blogService.UpdateBlog(blog);
                MessageBox.Show("Update blog success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                LoadBlogList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBlogID.Text))
                {
                    MessageBox.Show("Please select a blog to delete!", "Validation Error");
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to delete this blog?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.No)
                {
                    return;
                }

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
                return;
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
