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
            switch (user.RoleName.ToUpper())
            {
                case "ADMIN":
                    break;
                default:
                    this.btnModerate.Visibility = Visibility.Collapsed;
                    this.btnModerate.IsEnabled = false;
                    break;
            }
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
                cboSearchElement.ItemsSource = elementList;
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
                switch (user.RoleName.ToUpper())
                {
                    case "ADMIN":
                        var adList = advertisementServices.GetAdvertisements();
                        dgAdData.ItemsSource = null; // Clear the current ItemsSource
                        dgAdData.ItemsSource = adList; // Set new ItemsSource
                        break;
                    case "MEMBER":
                        var verifiedList = advertisementServices.GetVerifiedAdvertisements();
                        dgAdData.ItemsSource = null; // Clear the current ItemsSource
                        dgAdData.ItemsSource = verifiedList; // Set new ItemsSource
                        break;
                    case "USER":
                        verifiedList = advertisementServices.GetVerifiedAdvertisements();
                        dgAdData.ItemsSource = null; // Clear the current ItemsSource
                        dgAdData.ItemsSource = verifiedList; // Set new ItemsSource
                        this.btnAdd.IsEnabled = false;
                        this.btnDelete.IsEnabled = false;
                        this.btnUpdate.IsEnabled = false;
                        break;
                }
                
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
            switch (user.RoleName.ToUpper())
            {
                case "ADMIN": break;
                case "MEMBER": break;
                case "USER": this.btnAdd.IsEnabled = false; 
                             this.btnDelete.IsEnabled = false;
                             this.btnUpdate.IsEnabled = false;
                             break;
            }
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
                advertisement.Price = Double.Parse(txtPrice.Text);
                advertisement.CategoryId = cboCategory.SelectedValue?.ToString();
                advertisement.ElementId = int.Parse(cboElement.SelectedValue?.ToString());

                if (advertisementServices.UpdateAdvertisement(advertisement) 
                    && advertisement.UserId.Equals(user.UserId))
                {
                    MessageBox.Show("Update successful");
                    LoadAdvertisementList();
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
            advertisement.Price = Double.Parse(txtPrice.Text);
            advertisement.CategoryId = cboCategory.SelectedValue.ToString();
            advertisement.ElementId = int.Parse(cboElement.SelectedValue.ToString());
            advertisement.UserId = user.UserId;
            advertisement.Status = "Pending";
            if(advertisementServices.AddAdvertisement(advertisement))
            {
                MessageBox.Show("Add successfully");
                this.LoadDataInit();
            }
            else
            {
                MessageBox.Show("AdID has been existed");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string adID = txtAdID.Text;
            Advertisement advertisement = advertisementServices.GetAdvertisement(adID);
            if(adID.Length > 0 && advertisement.UserId.Equals(user.UserId))
            {
                MessageBoxResult result = MessageBox.Show("Do you really want to delete this advertisement?",
                                                            "Delete confirmation",
                                                            MessageBoxButton.YesNo,
                                                            MessageBoxImage.Question);
                if(result == MessageBoxResult.Yes && advertisementServices.DeleteAdvertisement(adID))
                {
                    MessageBox.Show("Delete successfully");
                    this.LoadDataInit();
                }
                else
                {
                    MessageBox.Show("Delete failed! Please try again");
                }
            }
            else
            {
                MessageBox.Show("Choose the advertisement you want to delete");
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
            resetInput();
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

        private void btnModerate_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ModerateWindow moderateWindow = new ModerateWindow(user);
            moderateWindow.Show();
        }
    }
}
