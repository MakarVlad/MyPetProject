using EngineerKA_1._0.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineerKA_1._0.ViewModel
{
     public class CreateGroupWindowVM:DataManageVM
     {
        private string _nameGroup;//
        private string _nameSPInGroupContains;//
        private string _codeSPInGroupContains;//
        private RelayCommand _createGrop;//

        public string NameGroup { get; set; }
        public string CodeSPInGroupContains { get; set; }
        public string NameSPInGroupContains { get; set; }
        public RelayCommand CreateGroup
        {
            get
            {
                return _createGrop ?? new RelayCommand(obj =>
                {

                    GroupManager.CreateGroup(NameGroup, NameSPInGroupContains, NameSPInGroupContains);
                  
                    
                });

            }
        }
     }
    
}
