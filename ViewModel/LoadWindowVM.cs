using System;
using System.Collections.Generic;
using System.Text;
using EngineerKA_1._0.Model;
using EngineerKA_1._0.View;
using System.Windows;
using System.Linq;
using System.IO;

namespace EngineerKA_1._0.ViewModel
{
 
    public class LoadWindowVM:DataManageVM
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

        private RelayCommand _loadОКButton;
        public RelayCommand LoadOKButton
        {
            get
            {
                return _loadОКButton ?? new RelayCommand(obj =>
                {
                    Window LoadFromFile = obj as Window;

                    try
                    { 
                        string _log = "CurrentLog";
                        FileReader.ReadTxtFile(_path, _log, NewLog);
                        OpenSuccessfulWindow();
                        LoadFromFile.Close();
                        UpdateALLRecordsView();
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
                   "\n Проверьте корректность указаного пути или содержимого файла! Подробнее: " + ( e.Message),
                   "Ошибка!" , 
                   MessageBoxButton.OK, MessageBoxImage.Error

                 );
        }
      
        private void OpenSuccessfulWindow()
        {
          MessageBox.Show
                (
                  "Загрузка данных из файла прошла успешно!",
                  "Сообщение",
                  MessageBoxButton.OK,MessageBoxImage.Information
                  
                );
           

        }

    
    }
}
