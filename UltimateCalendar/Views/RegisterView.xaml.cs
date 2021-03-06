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
using UltimateCalendar.Models;

namespace UltimateCalendar.Views
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        UserRegistration registration = new UserRegistration();
        private IDataHandler dataHandler;

        public RegisterView(IDataHandler dataHandler)
        {
            InitializeComponent();
            this.dataHandler = dataHandler;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (nameTB.Text != null && surnameTB.Text != null && dobTB.Text != null && emailTB.Text != null && passwordTB.Password != null)
            {
                if (emailTB.Text != email2TB.Text)
                {
                    MessageBox.Show("Ensure that email is typed correctly in both boxes.", "Email doesn't match !");
                }
                if (passwordTB.Password.ToString() != password2TB.Password.ToString())
                {
                    MessageBox.Show("Ensure that password is typed correctly in both boxes.", "Password doesn't match !");
                }
                if ((emailTB.Text == email2TB.Text) && (passwordTB.Password.ToString() == password2TB.Password.ToString()))
                {
                    if (MySqlRB.IsChecked.Value)
                    {
                        registration.RegisterUser(nameTB.Text, surnameTB.Text, dobTB.SelectedDate.Value, emailTB.Text, passwordTB.Password.ToString(),DBSelection.MySql);
                    }
                    else if (SqlServerRB.IsChecked.Value)
                    {
                        registration.RegisterUser(nameTB.Text, surnameTB.Text, dobTB.SelectedDate.Value, emailTB.Text, passwordTB.Password.ToString(),DBSelection.SqlServer);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill all boxes.", "Some boxes are empty !");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).DataContext = new LogInView(dataHandler);
        }
    }
}
