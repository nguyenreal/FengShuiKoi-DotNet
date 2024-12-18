﻿using FSK_BusinessObjects;
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
    /// Interaction logic for ConsultingResultWindow.xaml
    /// </summary>
    public partial class ConsultingResultWindow : Window
    {
        private readonly IAdvertisementServices advertisementServices;
        private readonly ITankService tankService;
        private readonly IKoiFishService koiFishService;
        private readonly Element? element;
        private readonly User? user;
        public ConsultingResultWindow(Element element, User user)
        {
            InitializeComponent();
            advertisementServices = new AdvertisementServices();
            tankService = new TankService();
            koiFishService = new KoiFishService();
            this.element = element;
            this.user = user;
        }

        public void LoadAdvertisementData()
        {
            try
            {
                var consultingAdList = advertisementServices.GetAdvertisementsByElement(element.ElementId);
                dgAd.ItemsSource = null; // Clear the current ItemsSource
                dgAd.ItemsSource = consultingAdList; // Set new ItemsSource
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of advertisements");
            }
        }

        public void LoadTankData()
        {
            try
            {
                var tankList = tankService.GetTankByElement(element.ElementId);
                dgTank.ItemsSource = null;
                dgTank.ItemsSource = tankList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of tanks");
            }
        }

        public void LoadFishData()
        {
            try
            {
                var fishList = koiFishService.GetKoiFishByElement(element.ElementId);
                dgKoiFish.ItemsSource = null;
                dgKoiFish.ItemsSource = fishList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of tanks");
            }
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtElement.Text = element.ElementName;
            LoadAdvertisementData();
            LoadTankData();
            LoadFishData();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ConsultingPage consultingPage = new ConsultingPage(user);
            consultingPage.Show();
        }
    }
}
