using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EngineerKA_1._0.ViewModel;
using EngineerKA_1._0.Model;

namespace EngineerKA_1._0.View
{
    /// <summary>
    /// Логика взаимодействия для LoadWindow.xaml
    /// </summary>
    public partial class LoadWindow : Window
    {
        public string LoadPath { get; set; }
        public LoadWindow()
        {
            InitializeComponent();
         
           // DataContext = LoadPath;
        }

        private void LoadOKButton_Click(object sender, RoutedEventArgs e)
        {
            LoadPath = LoadTextBox.Text;
            try
              {
                 DataWorker.CreateCurrentSparePartsFromTxtFileAsync(LoadPath);
              }
            catch
              {
                ErrorPathWindow error = new ErrorPathWindow();
                error.Show();
              }
        }
    }
}
