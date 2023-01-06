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
using EngineerKA_1._0.Model;
using EngineerKA_1._0.ViewModel;



namespace EngineerKA_1._0.View
{
    /// <summary>
    /// Логика взаимодействия для SpareParts.xaml
    /// </summary>
    public partial class SpareParts : Window
    {
        public static DataGrid CurrentSPView;
        public static ListView AdmissionSPView;
        public static ListView ReceivedSPView;
        public static ListView OutOfStockView;


        public SpareParts()
        {
           
          
            InitializeComponent();
            DataContext = new DataManageVM();
            CurrentSPView = ViewCurrentParts;
            AdmissionSPView = ViewAdmissionParts;
            ReceivedSPView = ViewReceivedParts;
            OutOfStockView = ViewOutOfStock;
          
        }

    }
}
