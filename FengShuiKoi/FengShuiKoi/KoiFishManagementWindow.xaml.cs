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
        private List<Element> _allElements;
        private readonly User? user;

        public KoiFishWindow()
        {
            InitializeComponent();
            _koiFishService = new KoiFishService();
            _elementService = new ElementService();
            LoadDataInit();
        }

        private void LoadDataInit()
        {
            LoadElements();
            LoadKoiFishList();
        }

        private void LoadElements()
        {
            _allElements = _elementService.GetElements().ToList();
            lbElements.ItemsSource = _allElements;
        }

        public void LoadKoiFishList()
        {
            try
            {
                var koiFishList = _koiFishService.GetKoiFish();
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

        private List<int> GetSelectedElementIds()
        {
            return lbElements.SelectedItems.Cast<Element>()
                           .Select(e => e.ElementId)
                           .ToList();
        }

        private KoiFish GetKoiFishFromInput()
        {
            return new KoiFish
            {
                KoiId = txtKoiID.Text,
                Name = txtKoiName.Text,
                Size = txtSize.Text,
                Weight = txtWeight.Text,
                Color = txtColor.Text,
                Description = txtDescription.Text
            };
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

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = txtSearch.Text;
            dgKoiData.ItemsSource = _koiFishService.GetKoiFishByFilter(search).ToList();

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var koiFish = GetKoiFishFromInput();
            var selectedElementIds = GetSelectedElementIds();

            if (_koiFishService.AddKoiFish(koiFish, selectedElementIds))
            {
                MessageBox.Show("Add successfully");
                LoadKoiFishList();
            }
            else
            {
                MessageBox.Show("ID Koi fish duplicate");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var koiFish = GetKoiFishFromInput();
            var selectedElementIds = GetSelectedElementIds();

            if (_koiFishService.UpdateKoiFish(koiFish, selectedElementIds))
            {
                MessageBox.Show("Update successful");
                LoadKoiFishList();
            }
            else
            {
                MessageBox.Show("Update failed. Please try again!");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string koiId = txtKoiID.Text;
            if (koiId.Length > 0 && _koiFishService.DeleteKoiFish(koiId))
            {
                LoadKoiFishList();
                MessageBox.Show("Delete successfully");
            }
            else
            {
                MessageBox.Show("Error. Try it again");
            }
        }

        private void dgKoiData_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

                // Select the elements in the ListBox
                lbElements.SelectedItems.Clear();
                foreach (var element in selectedItem.Elements)
                {
                    var elementItem = _allElements.FirstOrDefault(e => e.ElementId == element.ElementId);
                    if (elementItem != null)
                    {
                        lbElements.SelectedItems.Add(elementItem);
                    }
                }
            }
        }


    }
}
