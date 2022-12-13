using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace EngineerKA_1._0.Model
{
   public class MessageBoxHandler
    {
        public static void ShowMessageBox(string message,string caption,MessageBoxButton button,MessageBoxImage icon )
        {
            MessageBox.Show
                ( message,caption,button, icon);
        }
    }
}
