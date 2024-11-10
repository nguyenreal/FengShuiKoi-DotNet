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
        private readonly int? RoleID;
        public AdvertisementPage()
        {
            InitializeComponent();
            advertisementServices = new AdvertisementServices();
            categoryService = new CategoryServices();
            elementService = new ElementService();
        }
        public AdvertisementPage(int? RoleID)
        {
            InitializeComponent();
            advertisementServices = new AdvertisementServices();
            categoryService = new CategoryServices();
            elementService = new ElementService();
            this.RoleID = RoleID;
        }

        private void LoadDataInit()
        {
            this.dgAdData.ItemsSource = advertisementServices.GetAdvertisements().ToList();
            this.cboCategory.ItemsSource = categoryService.GetAllCategories().ToList();
            this.cboCategory.DisplayMemberPath = "CategoryName";
            this.cboCategory.SelectedValuePath = "CategoryId";
            this.cboElement.ItemsSource = elementService.GetElements().ToList();
            this.cboElement.DisplayMemberPath = "ElementName";
            this.cboElement.SelectedValuePath = "ElementId";
            this.cboSearchElement.ItemsSource = elementService.GetElements().ToList();
            this.cboSearchElement.DisplayMemberPath = "ElementName";
            this.cboSearchElement.SelectedValuePath = "ElementId";
            txtAdID.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtTitle.Text = "";
            txtUserID.Text = "";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadDataInit();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Advertisement advertisement = new Advertisement();
            advertisement.AdId = txtAdID.Text;
            advertisement.Title = txtTitle.Text;
            advertisement.Description = txtDescription.Text;
            advertisement.UserId = txtUserID.Text;
            advertisement.Price = Double.Parse(txtPrice.Text);
            advertisement.CategoryId = cboCategory.SelectedValue.ToString();
            if (advertisementServices.UpdateAdvertisement(advertisement))
            {
                MessageBox.Show("Cập nhật thành công");
                this.LoadDataInit();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công. Hãy cập nhật lại!");
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
            DataGrid dataGrid = sender as DataGrid;
            
            DataGridRow row = dataGrid.ItemContainerGenerator
                    .ContainerFromIndex(dataGrid.SelectedIndex) as DataGridRow;
            if(row != null) { 
                DataGridCell rowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                string id = ((TextBlock)rowColumn.Content).Text;

                Advertisement advertisement = advertisementServices.GetAdvertisement(id);
                if (advertisement != null)
                {
                    txtAdID.Text = advertisement.AdId;
                    txtDescription.Text = advertisement.Description;
                    txtPrice.Text = advertisement.Price.ToString();
                    txtTitle.Text = advertisement.Title;
                    txtUserID.Text = advertisement.UserId;
                    cboCategory.SelectedValue = advertisement.CategoryId;
                    cboElement.SelectedValue = advertisement.ElementId;
                }
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
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
