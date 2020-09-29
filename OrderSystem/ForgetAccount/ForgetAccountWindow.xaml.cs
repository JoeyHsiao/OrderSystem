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

namespace OrderSystem.ForgetAccount
{
    /// <summary>
    /// ForgetAccountWindow.xaml 的互動邏輯
    /// </summary>
    public partial class ForgetAccountWindow : Window
    {
        public ForgetAccountWindow()
        {
            InitializeComponent();
        }

        private void ForgetBtnClick(object sender, RoutedEventArgs e)
        {
            if (account.Text == "" | email.Text == "")
            {
                DialogShow.ShowOkDialog("Warning", "Have item empty!");
                return;
            }

            AccountProcess a = new AccountProcess();
            (string password, string errorType) = a.SearchAccount(account.Text, email.Text);

            if ( password != "" )
            {
                DialogShow.ShowOkDialog("Your password", password);
            }
            else
            {
                switch (errorType)
                {
                    case "NOACCOUNT":
                        DialogShow.ShowOkDialog("Warning", "Your account not found, please register.");
                        break;
                    case "ERRORMATCH":
                        DialogShow.ShowOkDialog("Warning", "Your account is not registered by this email.");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
