using OrderSystem.src;
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

        private void RegisterAccountBtnClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(passwordText.Password);
            if ( accountText.Text == "" | passwordText.Password == "" | passwordConfirmText.Password == "" | emailText.Text == "" )
            {
                DialogShow.ShowOkDialog("warning", "Have item empty!");
                return;
            }
            else if ( passwordText.Password != passwordConfirmText.Password )
            {
                DialogShow.ShowOkDialog("warning", "Password and Confirm Password not same!");
                return;
            }

            AccountProcess account = new AccountProcess();
            bool result = account.Register(accountText.Text, passwordText.Password, emailText.Text);
            if ( result == false )
            {
                DialogShow.ShowOkDialog("warning", "Account has already exist!");
                return;
            }
        }
    }
}
