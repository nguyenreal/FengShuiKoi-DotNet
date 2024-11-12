﻿using FSK_BusinessObjects;
using FSK_Services;
using Microsoft.Identity.Client.NativeInterop;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IUserService iUserService;
        public LoginWindow()
        {
            InitializeComponent();
            iUserService = new UserService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            User user = iUserService.GetUserByEmail(txtEmail.Text);
            if (user != null && user.Password.Equals(txtPassword.Password))
            {
                string? roleName = user.RoleName;
                this.Hide();
                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("You're not permitted !");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
