using System;
using System.Collections.Generic;
using System.Text;
using EngineerKA_1._0.Model;
using EngineerKA_1._0.View;
using System.Windows;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace EngineerKA_1._0.ViewModel
{
 
    public class LoadWindowVM:DataManageVM
    {
        private RelayCommand _loadОКButton;
        public  RelayCommand LoadOKButton
        {
            get
            {
                return _loadОКButton ?? new RelayCommand(obj =>
                {
                   
                    string _log = "SparePartsLog";
                    if (LoadPath != null && LoadPath.Contains(".txt"))
                    {
                        try
                        {
                            FileReader.ReadTxtFile(LoadPath, _log, SparePartsLog, NewLog);
                        }
                        catch (FileNotFoundException)
                        {
                            MessageBoxHandler.ShowMessageBox("Ошибка загрузки данных из файла!" +
                                              "\nПроверьте корректность указаного пути или содержимого файла! ",
                                               "Ошибка!",
                                               MessageBoxButton.OK , MessageBoxImage.Error);
                            return;
                        }
                        AddInDb.CompareCollections(AllCurrentSpareParts, NewLog, SparePartsLog, _log);
                        MessageBoxHandler.ShowMessageBox("Загрузка данных из файла прошла успешно!",
                                                         "Сообщение",
                                                          MessageBoxButton.OK, MessageBoxImage.Information);
                        UpdateALLRecordsView();
                    }
                    else MessageBoxHandler.ShowMessageBox("Ошибка загрузки данных из файла!" +
                                             "\nПроверьте корректность указаного пути или содержимого файла! ",
                                              "Ошибка!",
                                              MessageBoxButton.OK, MessageBoxImage.Error);
                });
                
            }
        }
    }
}
