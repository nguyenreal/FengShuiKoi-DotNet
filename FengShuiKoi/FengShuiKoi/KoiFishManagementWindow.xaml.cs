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
            LoadDataInit();
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
                    txtColor.Text = selectedItem.Color;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in selection changed: {ex.Message}");
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = txtSearch.Text;

            int elementID = cboSearchElement.SelectedValue != null
                ? int.Parse(cboSearchElement.SelectedValue.ToString())
                : -1;

            dgKoiData.ItemsSource = _koiFishService.GetKoiFishByFilter(search, elementID)
                .ToList();

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            KoiFish koiFish = new KoiFish();
            koiFish.KoiId = txtKoiID.Text;
            koiFish.Name = txtKoiName.Text;
            koiFish.Size = txtSize.Text;
            koiFish.Weight = txtWeight.Text;
            koiFish.Color = txtColor.Text;
            koiFish.Description = txtDescription.Text;

            if (_koiFishService.AddKoiFish(koiFish))
            {
                MessageBox.Show("Add successfully");
                this.LoadDataInit();
            }
            else
            {
                MessageBox.Show("ID Koi fish duplicate");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                KoiFish koiFish = new KoiFish();
                koiFish.KoiId = txtKoiID.Text;
                koiFish.Name = txtKoiName.Text;
                koiFish.Size = txtSize.Text;
                koiFish.Weight = txtWeight.Text;
                koiFish.Color = txtColor.Text;
                koiFish.Description = txtDescription.Text;

                if (_koiFishService.UpdateKoiFish(koiFish))
                {
                    MessageBox.Show("Update successful");
                    LoadKoiFishList();
                }
                else
                {
                    MessageBox.Show("Update failed. Please try again!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating koi fish: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string koiId = txtKoiID.Text;
            if (koiId.Length > 0 && _koiFishService.DeleteKoiFish(koiId))
            {
                this.LoadDataInit();
                MessageBox.Show("Delete successfully");
            }
            else
            {
                MessageBox.Show("Error. Try it again");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadDataInit();
        }
    }
}
