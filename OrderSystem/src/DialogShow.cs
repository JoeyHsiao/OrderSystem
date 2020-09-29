using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OrderSystem.src
{
    class DialogShow
    {
        public static void ShowOkDialog(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK);
        }

    }
}
