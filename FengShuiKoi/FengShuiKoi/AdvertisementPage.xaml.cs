using FSK_BusinessObjects;
using FSK_Services;
using System.Windows;
using System.Windows.Controls;

namespace FengShuiKoi
{
    /// <summary>
    /// Interaction logic for AdvertisementPage.xaml
    /// </summary>
    public partial class AdvertisementPage : Window
    {
        private readonly IAdvertisementServices advertisementServices;
        private readonly ICategoryService categoryService;
        private readonly IElementService elementService;
        private readonly User? user;

        public AdvertisementPage(User user)
        {
            InitializeComponent();
            advertisementServices = new AdvertisementServices();
            categoryService = new CategoryServices();
            elementService = new ElementService();
            this.user = user;
            LoadDataInit();
        }

        private void LoadDataInit()
        {
            LoadCategoryList();
            LoadElementList();
            LoadElementSearchList();
            LoadAdvertisementList();
        }
        public void LoadElementList()
        {
            try
            {
                var elementList = elementService.GetElements();
                cboElement.ItemsSource = elementList;
                this.cboElement.DisplayMemberPath = "ElementName";
                this.cboElement.SelectedValuePath = "ElementId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of elements");
            }
        }

        public void LoadElementSearchList()
        {
            try
            {
                var elementList = elementService.GetElements();
                cboElement.ItemsSource = elementList;
                this.cboSearchElement.DisplayMemberPath = "ElementName";
                this.cboSearchElement.SelectedValuePath = "ElementId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of elements");
            }
        }

        public void LoadCategoryList()
        {
            try
            {
                var categoryList = categoryService.GetAllCategories();
                cboCategory.ItemsSource = categoryList;
                this.cboCategory.DisplayMemberPath = "CategoryName";
                this.cboCategory.SelectedValuePath = "CategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of categories");
            }
        }

        public void LoadAdvertisementList()
        {
            try
            {
                var adList = advertisementServices.GetAdvertisements();
                dgAdData.ItemsSource = null; // Clear the current ItemsSource
                dgAdData.ItemsSource = adList; // Set new ItemsSource
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of advertisements");
            }
            finally
            {
                resetInput();
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadDataInit();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Advertisement advertisement = new Advertisement();
                advertisement.AdId = txtAdID.Text;
                advertisement.Title = txtTitle.Text;
                advertisement.Description = txtDescription.Text;
                advertisement.UserId = txtUserID.Text;
                advertisement.Price = Double.Parse(txtPrice.Text);
                advertisement.CategoryId = cboCategory.SelectedValue?.ToString();
                advertisement.ElementId = int.Parse(cboElement.SelectedValue?.ToString());

                if (advertisementServices.UpdateAdvertisement(advertisement))
                {
                    MessageBox.Show("Update successful");
                    LoadAdvertisementList(); // Just call LoadAdvertisementList directly
                }
                else
                {
                    MessageBox.Show("Update failed. Please try again!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating advertisement: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Advertisement advertisement = new Advertisement();
            advertisement.AdId = txtAdID.Text;
            advertisement.Title = txtTitle.Text;
            advertisement.Description = txtDescription.Text;
            advertisement.UserId = txtUserID.Text;
            advertisement.Price = Double.Parse(txtPrice.Text);
            advertisement.CategoryId = cboCategory.SelectedValue.ToString();
            advertisement.ElementId = int.Parse(cboElement.SelectedValue.ToString());
            if(advertisementServices.AddAdvertisement(advertisement))
            {
                MessageBox.Show("Thêm quảng cáo thành công");
                this.LoadDataInit();
            }
            else
            {
                MessageBox.Show("ID quảng cáo đã tồn tại");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string adID = txtAdID.Text;
            if(adID.Length > 0 && advertisementServices.DeleteAdvertisement(adID))
            {
                this.LoadDataInit();
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa không thành công. Hãy thử lại.");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgAdData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            try
            {
                DataGrid dataGrid = sender as DataGrid;
                if (dataGrid == null || dataGrid.SelectedIndex < 0) return;

                var selectedItem = dataGrid.SelectedItem as Advertisement;
                if (selectedItem != null)
                {
                    txtAdID.Text = selectedItem.AdId;
                    txtDescription.Text = selectedItem.Description;
                    txtPrice.Text = selectedItem.Price.ToString();
                    txtTitle.Text = selectedItem.Title;
                    txtUserID.Text = selectedItem.UserId;
                    cboCategory.SelectedValue = selectedItem.CategoryId;
                    cboElement.SelectedValue = selectedItem.ElementId;
                }
            }
            catch (Exception ex)
            {
                // Silently handle the error to prevent disrupting the UI
                Console.WriteLine($"Error in selection changed: {ex.Message}");
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = txtSearch.Text;

            int elementID = cboSearchElement.SelectedValue != null
                ? int.Parse(cboSearchElement.SelectedValue.ToString())
                : -1;

            dgAdData.ItemsSource = advertisementServices
                .GetAdvertisementsByFilter(search, elementID)
                .ToList();

            this.LoadDataInit();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow(user);
            mainWindow.Show();
        }

        private void resetInput()
        {
            txtAdID.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtTitle.Text = "";
            txtUserID.Text = "";
            cboCategory.SelectedValue = "";
            cboElement.SelectedValue = null;
        }
    }
}
