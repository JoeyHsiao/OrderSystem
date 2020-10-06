using OrderSystem.ForgetAccount;
using OrderSystem.Order;
using OrderSystem.RegisterAccount;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrderSystem
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginBtnClick(object sender, RoutedEventArgs e)
        {
            AccountProcess account = new AccountProcess();
            if ( accountText.Text == "" | passwordText.Password == "" )
            {
                DialogShow.ShowOkDialog("warning", "Have item empty!");
                return;
            }
            else if ( account.Login(accountText.Text, passwordText.Password) )
            {
                this.Hide();
                OrderWindow a = new OrderWindow();
                a.ShowDialog();
                this.Close();
            }
            else
            {
                DialogShow.ShowOkDialog("Error", "Not match account or password");
            }

            
        }

        private void ForgetBtnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ForgetAccountWindow a = new ForgetAccountWindow();
            a.ShowDialog();
            this.Show();
        }

        private void RegisterBtnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RegisterAccountWindow a = new RegisterAccountWindow();
            a.ShowDialog();
            this.Show();
        }
    }
}
