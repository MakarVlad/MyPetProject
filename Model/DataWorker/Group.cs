using System;
using System.Collections.Generic;
using System.Text;

namespace EngineerKA_1._0.Model
{
    public class Group
    {
        public string Name { get; set; }
        public string NameSPContains { get; set; }
        public string CodeSPContains { get; set; }
        public Group(string _name,string _nameContains,string _codeContains)
        {
            Name = _name;
            NameSPContains = _nameContains;
            CodeSPContains = _codeContains;
        }
    }
}
