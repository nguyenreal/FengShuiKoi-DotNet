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
    /// Interaction logic for ConsultingPage.xaml
    /// </summary>
    public partial class ConsultingPage : Window
    {
        private readonly IElementService elementService;
        private readonly User? user;
        public ConsultingPage(User user)
        {
            InitializeComponent();
            elementService = new ElementService();
            this.user = user;
        }

        private void btnConsult_Click(object sender, RoutedEventArgs e)
        {
            DateTime birthDate = dpBirthdate.SelectedDate.Value;
            Element element = elementService.GetElement(birthDate);      
            if(element != null)
            {
                this.Hide();
                ConsultingResultWindow consultingResultWindow = new ConsultingResultWindow(element);
                consultingResultWindow.Show();
            }
        }
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow(user);
            mainWindow.Show();
        }
    }
}
