using FSK_BusinessObjects;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FengShuiKoi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly User? user;
        private readonly string? roleName;
        private readonly string? userId;
        public MainWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            this.roleName = user.RoleName;
            this.userId = user.UserId;
        }


        private void btnManaging_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ManagementWindow managementWindow = new ManagementWindow(user);
            managementWindow.Show();
        }

        private void btnConsulting_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ConsultingPage consultingPage = new ConsultingPage(user);
            consultingPage.Show();
        }

        private void btnBlog_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BlogWindow blogWindow = new BlogWindow(user);
            blogWindow.Show();
        }

        private void btnAdvertise_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdvertisementPage advertisementPage = new AdvertisementPage(user);
            advertisementPage.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (roleName?.ToUpper())  
                {
                    case "ADMIN":
                        break;
                    case "USER":
                        this.btnManaging.IsEnabled = false;
                        break;
                case "GUEST":
                    this.btnManaging.IsEnabled = false;
                    this.btnConsulting.IsEnabled = false;
                    break;
                default:
                        this.Close();
                        break;
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to logout?",
                                            "Logout Confirmation",
                                            MessageBoxButton.YesNo,
                                            MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
        }
    }
}