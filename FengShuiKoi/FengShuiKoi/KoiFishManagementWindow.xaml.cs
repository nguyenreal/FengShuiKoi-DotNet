using FSK_BusinessObjects;
using FSK_Services;
using System.Globalization;
using System.Text.RegularExpressions;
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
            if (!Validate())
            {
                return;
            }
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
            if (!Validate())
            {
                return;
            }
            var selectedElementIds = GetSelectedElementIds();

            if (_koiFishService.UpdateKoiFish(koiFish, selectedElementIds))
            {
                MessageBox.Show("Update successful");
                LoadKoiFishList();
            }
            else
            {
                MessageBox.Show("Update failed. Please try again and no change koi ID");
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

        public bool Validate()
        {
            string idRegex = @"^KF\d{3}";
            string strRegex = @"^[a-zA-Z0-9\s]*$";
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            if (string.IsNullOrWhiteSpace(txtKoiID.Text))
            {
                MessageBox.Show("Koi ID is require", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!Regex.IsMatch(txtKoiID.Text, idRegex))
            {
                MessageBox.Show("Koi ID must be in format KFxxx", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            string koiId = txtKoiID.Text.Trim();
            txtKoiID.Text = koiId;

            if (string.IsNullOrWhiteSpace(txtKoiName.Text))
            {
                MessageBox.Show("Koi name is require", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!Regex.IsMatch(txtKoiName.Text, strRegex))
            {
                MessageBox.Show("Koi name: No special character", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            string koiName = txtKoiName.Text.Trim();
            koiName = textInfo.ToTitleCase(koiName.ToLower());
            txtKoiName.Text = koiName;

            if (string.IsNullOrWhiteSpace(txtSize.Text))
            {
                MessageBox.Show("Size is require", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            string koiSize = txtSize.Text.Trim();
            txtSize.Text = koiSize;

            if (string.IsNullOrWhiteSpace(txtWeight.Text))
            {
                MessageBox.Show("Weight is require", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            string koiWeight = txtWeight.Text.Trim();
            txtWeight.Text = koiWeight;

            if (string.IsNullOrWhiteSpace(txtColor.Text))
            {
                MessageBox.Show("Color is require", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            string koiColor = txtColor.Text.Trim();
            txtColor.Text = koiColor;

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Description is require", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
