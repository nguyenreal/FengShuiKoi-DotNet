using FSK_BusinessObjects;
using FSK_Services;
using System.Windows;
using System.Windows.Controls;

namespace FengShuiKoi
{
    /// <summary>
    /// Interaction logic for KoiFishWindow.xaml
    /// </summary>
    public partial class KoiFishWindow : Window
    {
        private readonly IKoiFishService _koiFishService;
        private readonly IElementService _elementService;

        public KoiFishWindow()
        {
            InitializeComponent();
            _koiFishService = new KoiFishService();
            _elementService = new ElementService();
        }

        private void LoadDataInit()
        {
            LoadElementList();
            LoadKoiFishList();
        }

        public void LoadElementList()
        {
            try
            {
                var elementList = _elementService.GetElements();
                cboSearchElement.ItemsSource = elementList;
                this.cboSearchElement.DisplayMemberPath = "ElementName";
                this.cboSearchElement.SelectedValuePath = "ElementId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of elements");
            }
        }

        public void LoadKoiFishList()
        {
            try
            {
                var koiFishList = _koiFishService.GetKoiFish();
                dgKoiData.ItemsSource = null;
                dgKoiData.ItemsSource = koiFishList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of koi fishes");
            }
            finally
            {
                resetInput();
            }
        }

        private void resetInput()
        {
            txtKoiID.Text = "";
            txtKoiName.Text = "";
            txtSize.Text = "";
            txtWeight.Text = "";
            txtColor.Text = "";
            txtDescription.Text = "";
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

                var selectedItem = dataGrid.SelectedItem as KoiFish;
                if (selectedItem != null)
                {
                    txtKoiID.Text = selectedItem.KoiId;
                    txtDescription.Text = selectedItem.Description;
                    txtKoiName.Text = selectedItem.Name;
                    txtSize.Text = selectedItem.Size;
                    txtWeight.Text = selectedItem.Weight;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in selection changed: {ex.Message}");
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
