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
    public partial class RegisterWindow : Window
    {
        private readonly IUserService userService;

        public RegisterWindow()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private string GenerateUserId()
        {
            // Generate a 6-digit random number
            Random random = new Random();
            int number = random.Next(100000, 999999);
            return $"SE{number}";
        }

        private bool ValidateInputs(out string errorMessage)
        {
            errorMessage = string.Empty;

            // Check for null or empty values
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorMessage = "Username cannot be empty.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                errorMessage = "Password cannot be empty.";
                return false;
            }

            // And the password length check:
            if (txtPassword.Password.Length < 6)
            {
                errorMessage = "Password must be at least 6 characters long.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorMessage = "Email cannot be empty.";
                return false;
            }

            if (dpBirthday.SelectedDate == null)
            {
                errorMessage = "Please select a birthday.";
                return false;
            }
            // Validate email format
            if (!IsValidEmail(txtEmail.Text))
            {
                errorMessage = "Please enter a valid email address.";
                return false;
            }

            // Validate age (must be at least 13 years old)
            if (dpBirthday.SelectedDate.HasValue)
            {
                var age = DateTime.Today.Year - dpBirthday.SelectedDate.Value.Year;
                if (dpBirthday.SelectedDate.Value > DateTime.Today.AddYears(-age))
                    age--;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string errorMessage;
                if (!ValidateInputs(out errorMessage))
                {
                    MessageBox.Show(errorMessage, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string userId;
                bool isUnique;
                userId = GenerateUserId();

                User user = new User
                {
                    UserId = userId,
                    UserName = txtUsername.Text.Trim(),
                    RoleName = "USER",
                    Email = txtEmail.Text.Trim(),
                    Password = txtPassword.Password,  // Change this line - use Password instead of Text
                    DateOfBirth = DateOnly.FromDateTime(dpBirthday.SelectedDate.Value)
                };

                if (userService.AddUser(user))
                {
                    MessageBox.Show($"Registration successful! Your User ID is: {userId}",
                                  "Success",
                                  MessageBoxButton.OK,
                                  MessageBoxImage.Information);
                    this.Hide();
                    MainWindow mainWindow = new MainWindow(user);
                    mainWindow.Show();
                }
                else
                {
                    MessageBox.Show("User already exists.", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during registration: {ex.Message}",
                              "Error",
                              MessageBoxButton.OK,
                              MessageBoxImage.Error);
            }
        }
    }
}
