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
        private readonly int? adID;
        public AdvertisementPage()
        {
            InitializeComponent();
            advertisementServices = new AdvertisementServices();
            categoryService = new CategoryServices();
            elementService = new ElementService();
        }
        public AdvertisementPage(int? adID)
        {
            InitializeComponent();
            advertisementServices = new AdvertisementServices();
            categoryService = new CategoryServices();
            elementService = new ElementService();
            this.adID = adID;
        }

        private void LoadDataInit()
        {
            this.dgAdData.ItemsSource = advertisementServices.GetAdvertisements();
            this.cboCategory.ItemsSource = categoryService.GetAllCategories();
            this.cboCategory.DisplayMemberPath = "CategoryName";
            this.cboCategory.SelectedValuePath = "CategoryId";
            this.cboElement.ItemsSource = elementService.GetElements();
            this.cboElement.DisplayMemberPath = "ElementName";
            this.cboElement.SelectedValuePath = "ElementId";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadDataInit();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Advertisement advertisement = new Advertisement
            {
                AdId = txtAdID.Text,
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                Price = Double.Parse(txtPrice.Text),
                ElementId = cboElement.SelectedValue as int?,
                CategoryId = cboCategory.SelectedValue.ToString(),
                UserId = txtUserID.Text
            };
            if (advertisementServices.UpdateAdvertisement(advertisement))
            {
                this.LoadDataInit();
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công. Hãy cập nhật lại!");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Advertisement advertisement = new Advertisement
            {
                AdId = txtAdID.Text,
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                Price = double.Parse(txtPrice.Text),
                UserId = txtUserID.Text,
                CategoryId = cboCategory.SelectedValue?.ToString(),
                ElementId = cboElement.SelectedValue as int?
            };
            if (advertisementServices.AddAdvertisement(advertisement))
            {
                MessageBox.Show("Thêm quảng cáo thành công");
                this.LoadDataInit();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            String userID = txtUserID.Text;
            if(userID.Length > 0 && advertisementServices.DeleteAdvertisement(userID))
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
            if (dgAdData.SelectedItem != null)
            {
                Advertisement advertisement = dgAdData.SelectedItem as Advertisement;

                if (advertisement != null)
                {
                    txtAdID.Text = advertisement.AdId;
                    txtTitle.Text = advertisement.Title;
                    txtDescription.Text = advertisement.Description;
                    txtPrice.Text = advertisement.Price.ToString();
                    txtUserID.Text = advertisement.UserId?.ToString();
                    cboCategory.SelectedValue = advertisement.CategoryId;
                    cboElement.SelectedValue = advertisement.ElementId;
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string category = cboCategory.SelectedValue?.ToString() ?? string.Empty;
            string element = cboElement.SelectedValue?.ToString() ?? string.Empty;
            string userID = txtUserID.Text;

            var filteredAds = advertisementServices.GetAdvertisementsByFilter(category, element, userID);
            dgAdData.ItemsSource = filteredAds;
        }
    }
}
