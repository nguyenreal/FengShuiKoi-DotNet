using FSK_BusinessObjects;
using FSK_DAOs;
using FSK_Services;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly IUserService userService;
        public RegisterWindow()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.UserId = txtUserID.Text;
            user.UserName = txtUsername.Text;
            user.RoleName = "USER";
            user.Email = txtEmail.Text;
            user.Password = txtPassword.Text;
            user.DateOfBirth = DateOnly.FromDateTime(dpBirthday.SelectedDate.Value);

            if (user.Password.Length < 6)
            {
                MessageBox.Show("Password must be over 6 characters");
            }
            else if (!IsValidEmail(user.Email))
            {
                MessageBox.Show("Email not valid");
            }
            else if (userService.AddUser(user))
            {
                MessageBox.Show("Register successfully");
                this.Hide();
                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();
            } 
            else
            {
                MessageBox.Show("User has been existed");
            }
        }
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
