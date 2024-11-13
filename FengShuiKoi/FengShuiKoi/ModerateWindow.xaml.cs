using FSK_BusinessObjects;
using FSK_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for ModerateWindow.xaml
    /// </summary>
    public partial class ModerateWindow : Window
    {
        private readonly IAdvertisementServices advertisementServices;
        private readonly User? user;
        public ModerateWindow(User user)
        {
            InitializeComponent();
            advertisementServices = new AdvertisementServices();
            this.user = user;
        }

        private void btnVerified_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Advertisement advertisement = advertisementServices.GetAdvertisement(txtAdID.Text);
                advertisement.Status = "Verified";

                if (advertisementServices.UpdateAdvertisement(advertisement))
                {
                    MessageBox.Show("Verify successfully");
                    LoadAdvertisementList();
                }
                else
                {
                    MessageBox.Show("Verify failed. Please try again!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating advertisement: {ex.Message}");
            }
        }

        private void LoadAdvertisementList()
        {
            try
            {
                var adList = advertisementServices.GetAdvertisements();
                dgModerate.ItemsSource = null; // Clear the current ItemsSource
                dgModerate.ItemsSource = adList; // Set new ItemsSource
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of advertisements");
            }
        }

        private void btnRejected_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Advertisement advertisement = advertisementServices.GetAdvertisement(txtAdID.Text);
                advertisement.Status = "Rejected";

                if (advertisementServices.UpdateAdvertisement(advertisement))
                {
                    MessageBox.Show("Reject successfully");
                    LoadAdvertisementList();
                }
                else
                {
                    MessageBox.Show("Reject failed. Please try again!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating advertisement: {ex.Message}");
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdvertisementPage advertisementPage = new AdvertisementPage(user);
            advertisementPage.Show();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.txtAdID.IsReadOnly = true;
            this.txtDescription.IsReadOnly = true;
            this.txtStatus.IsReadOnly = true;
            this.txtTitle.IsReadOnly = true;
            this.LoadAdvertisementList();
        }

        private void dgModerate_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                    txtTitle.Text = selectedItem.Title;
                    txtStatus.Text = selectedItem.Status;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in selection changed: {ex.Message}");
            }
        }
    }
}
