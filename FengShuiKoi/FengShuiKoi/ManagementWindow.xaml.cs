using FSK_BusinessObjects;
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
    /// Interaction logic for ManagementWindow.xaml
    /// </summary>
    public partial class ManagementWindow : Window
    {
        private readonly User? _user;
        public ManagementWindow(User user)
        {
            InitializeComponent();
            _user = user;
        }
        
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow(_user);
            mainWindow.Show();
        }

        private void btnKoiFish_Click(object sender, RoutedEventArgs e)
        {
            KoiFishWindow koiFishWindow = new KoiFishWindow();
            koiFishWindow.ShowDialog();
        }

        private void btnTank_Click(object sender, RoutedEventArgs e)
        {
            TankManageWindow tankManageWindow = new TankManageWindow();
            tankManageWindow.ShowDialog();
        }
    }
}
