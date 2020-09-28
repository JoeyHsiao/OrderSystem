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
        public static void ShowOkDialog(string message)
        {
            MessageBox.Show(message, "warning", MessageBoxButton.OK);
            //MessageBox.Show(noAccountText, caption, button, icon);
        }

    }
}
