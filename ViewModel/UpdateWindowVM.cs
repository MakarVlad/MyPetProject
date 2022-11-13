using System;
using System.Collections.Generic;
using System.Text;
using EngineerKA_1._0.Model;
using EngineerKA_1._0.View;
using System.Windows;

namespace EngineerKA_1._0.ViewModel
{
    public class UpdateWindowVM:DataManageVM
    {

        public string LoadPath
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
            }
        }
        private string _path;

        private RelayCommand _updateОКButton;
        public RelayCommand UpdateOKButton
        {
            get
            {
                return _updateОКButton ?? new RelayCommand(obj =>
                {

                    try
                    {
                        string _log = "NewLog";
                        FileReader.ReadTxtFile(_path, _log, NewLog);
                        UpdateALLRecordsView();
                        // DataWorker.CompareCollections(AllCurrentSpareParts, NewLog);
                        AddInDb.CompareCollections(AllCurrentSpareParts, NewLog);
                        UpdateALLRecordsView();
                        OpenSuccessfulWindow();

                    }
                    catch(Exception e)
                    {
                        OpenErrorWindow(e);
                    }
                }
                );
            }
        }

        private void OpenErrorWindow(Exception e)
        {
            MessageBox.Show
                 (
                   "Ошибка загрузки данных из файла! " +
                   "\n Проверьте корректность указаного пути или содержимого файла! Подробнее: " + (e.Message),
                   "Ошибка!",
                   MessageBoxButton.OK, MessageBoxImage.Error

                 );
        }

        private void OpenSuccessfulWindow()
        {
            MessageBox.Show
                  (
                    "Загрузка данных из файла прошла успешно!",
                    "Сообщение",
                    MessageBoxButton.OK, MessageBoxImage.Information

                  );


        }



    }
}
