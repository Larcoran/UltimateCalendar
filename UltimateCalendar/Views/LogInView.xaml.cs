﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UltimateCalendar.ViewModels;
using UltimateCalendar.Models;

namespace UltimateCalendar.Views
{
    /// <summary>
    /// Interaction logic for LogInView.xaml
    /// </summary>
    public partial class LogInView : UserControl
    {
        LogIn logIn = new LogIn();
        public LogInView()
        {
            InitializeComponent();
        }

        private void TBSignUp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.DataContext = new RegisterView();
        }

        private void logInBTN_Click(object sender, RoutedEventArgs e)
        {
            if (logIn.CredentialsCorrect(emailTB.Text, passwordTB.Password.ToString()))
            {
                Application.Current.MainWindow.DataContext = new MainView();
            }
            else
            {
                MessageBox.Show("Incorrect login details.","Error !!!");
            }
        }
    }
}
