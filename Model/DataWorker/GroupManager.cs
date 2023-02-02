using System;
using System.Collections.Generic;
using System.Text;

namespace EngineerKA_1._0.Model
{
    public class GroupManager
    {
        private bool _available = false;//
        public static void CreateGroup(string Name,string NameSPContains,string CodeSPContains)
        {
            Group UserGroup = new Group(Name, NameSPContains, CodeSPContains);
            
        }

    }
}
