﻿using OrderSystem.src;
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

namespace OrderSystem.RegisterAccount
{
    /// <summary>
    /// RegisterAccountWindow.xaml 的互動邏輯
    /// </summary>
    public partial class RegisterAccountWindow : Window
    {
        public RegisterAccountWindow()
        {
            InitializeComponent();
        }

        private void registerAccountBtnClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(registerPassword.Password);
            if (registerAccount.Text == "" | registerPassword.Password == "" | registerPasswordConfirm.Password == "" | registerEmail.Text == "" )
            {
                DialogShow.ShowOkDialog("Have item empty!");
                return;
            }
            else if (registerPassword.Password != registerPasswordConfirm.Password )
            {
                DialogShow.ShowOkDialog("Password and Confirm Password not same!");
                return;
            }

            AccountProcess account = new AccountProcess();
            bool result = account.Register(registerAccount.Text, registerPassword.Password, registerEmail.Text);
            if ( result == false )
            {
                DialogShow.ShowOkDialog("Account has already exist!");
                return;
            }
        }
    }
}
