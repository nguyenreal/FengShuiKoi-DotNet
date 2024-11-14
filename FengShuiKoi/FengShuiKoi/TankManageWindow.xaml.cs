using FSK_BusinessObjects;
using FSK_Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// <summary>
    /// Interaction logic for TankManageWindow.xaml
    /// </summary>
    public partial class TankManageWindow : Window
    {
        private readonly ITankService _tankService;
        private readonly IElementService _elementService;
        public TankManageWindow()
        {
            InitializeComponent();
            _tankService = new TankService();
            _elementService = new ElementService();
            LoadDataInit();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadDataInit();
        }

        private void LoadDataInit()
        {
            LoadElementList();
            LoadTankList();
        }

        public void LoadElementList()
        {
            try
            {
                var elementList = _elementService.GetElements();

                cboSearchElement.ItemsSource = elementList;
                this.cboSearchElement.DisplayMemberPath = "ElementName";
                this.cboSearchElement.SelectedValuePath = "ElementId";

                cboElement.ItemsSource = elementList;
                this.cboElement.DisplayMemberPath = "ElementName";
                this.cboElement.SelectedValuePath = "ElementId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of elements");
            }
        }

        public void LoadTankList()
        {
            try
            {
                var tankList = _tankService.GetTank();
                dgTankData.ItemsSource = null;
                dgTankData.ItemsSource = tankList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of tanks");
            }
            finally
            {
                resetInput();
            }
        }

        private void resetInput()
        {
            txtTankID.Text = "";
            txtShape.Text = "";
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgAdData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dataGrid = sender as DataGrid;
                if (dataGrid == null || dataGrid.SelectedIndex < 0) return;

                var selectedItem = dataGrid.SelectedItem as Tank;
                if (selectedItem != null)
                {
                    txtTankID.Text = selectedItem.TankId;
                    txtShape.Text = selectedItem.Shape;
                    cboElement.SelectedValue = selectedItem.ElementId;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in selection changed: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Tank tank = new Tank();
            tank.TankId = txtTankID.Text;
            tank.Shape = txtShape.Text;
            tank.ElementId = int.Parse(cboElement.SelectedValue.ToString());

            if (_tankService.AddTank(tank))
            {
                MessageBox.Show("Add successfully");
                this.LoadDataInit();
            }
            else
            {
                MessageBox.Show("ID Tank duplicate");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Tank tank = new Tank();
                tank.TankId = txtTankID.Text;
                tank.Shape = txtShape.Text;
                tank.ElementId = int.Parse(cboElement.SelectedValue.ToString());

                if (_tankService.UpdateTank(tank))
                {
                    MessageBox.Show("Update successful");
                    LoadTankList();
                }
                else
                {
                    MessageBox.Show("Update failed. Please try again and no change tank id");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating tank: {ex.Message}");
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string tankID = txtTankID.Text;
            if (tankID.Length > 0 && _tankService.DeleteTank(tankID))
            {
                this.LoadDataInit();
                MessageBox.Show("Delete successfully");
            }
            else
            {
                MessageBox.Show("Error. Try it again");
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = txtSearch.Text;

            int elementID = cboSearchElement.SelectedValue != null
                ? int.Parse(cboSearchElement.SelectedValue.ToString())
                : -1;

            dgTankData.ItemsSource = _tankService.GetTanksByFilter(search, elementID)
                .ToList();

        }

        private bool Validate()
        {
            string idRegex = @"^TA\d{3}";
            string strRegex = @"^[a-zA-Z0-9\s]*$";
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            if (string.IsNullOrWhiteSpace(txtTankID.Text))
            {
                MessageBox.Show("Tank ID is require", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!Regex.IsMatch(txtTankID.Text, idRegex))
            {
                MessageBox.Show("Tank ID must be in format TAxxx", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            string koiId = txtTankID.Text.Trim();
            txtTankID.Text = koiId;


            if (string.IsNullOrWhiteSpace(txtShape.Text))
            {
                MessageBox.Show("Shape is require", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!Regex.IsMatch(txtShape.Text, strRegex))
            {
                MessageBox.Show("Shape: No special character", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            string koiName = txtShape.Text.Trim();
            koiName = textInfo.ToTitleCase(koiName.ToLower());
            txtShape.Text = koiName;

            return true;
        }
    }
}
