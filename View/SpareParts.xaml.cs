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

namespace EngineerKA_1._0.View
{
    /// <summary>
    /// Логика взаимодействия для SpareParts.xaml
    /// </summary>
    public partial class SpareParts : Window
    {
        public SpareParts()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow();
            searchWindow.Show();

        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadWindow loadWindow = new LoadWindow();
            loadWindow.Show();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateWindow updateWindow = new UpdateWindow();
            updateWindow.Show(); 
        } 
    }
}
