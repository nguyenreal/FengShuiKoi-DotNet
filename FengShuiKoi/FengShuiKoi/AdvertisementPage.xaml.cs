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
        private readonly int? adID;
        public AdvertisementPage()
        {
            InitializeComponent();
            advertisementServices = new AdvertisementServices();
            categoryService = new CategoryServices();
        }
        public AdvertisementPage(int? adID)
        {
            InitializeComponent();
            advertisementServices = new AdvertisementServices();
            categoryService = new CategoryServices();
            this.adID = adID;
        }

        private void LoadDataInit()
        {
            this.dgAdData.ItemsSource = advertisementServices.GetAdvertisements();
            this.cboCategory.ItemsSource = categoryService.GetAllCategories();
            this.cboCategory.DisplayMemberPath = "CategoryName";
            this.cboCategory.SelectedValuePath = "CategoryID";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadDataInit();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch 
            { 
                
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
                CategoryId = cboCategory.SelectedValue?.ToString()
            };
            if (advertisementServices.SaveAdvertisement(advertisement))
            {
                MessageBox.Show("Add successfully");
                this.LoadDataInit();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgAdData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator
                .ContainerFromIndex(dgAdData.SelectedIndex);
            DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            String id = ((TextBlock)RowColumn.Content).Text;
            Advertisement ad = advertisementServices.GetAdvertisement(id);
            txtAdID.Text = ad.AdId;
            txtDescription.Text = ad.Description;
            txtPrice.Text = ad.Price.ToString();
            txtTitle.Text = ad.Title;
            txtUserID.Text = ad.UserId;
            cboCategory.SelectedValue = ad.Category;
        }
    }
}
