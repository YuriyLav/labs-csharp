using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    class ListEntry
    {
        public string Name { get; set; }
        public Update Type { get; set; }
        public string NameProp { get; set; }
        public string Key { get; set; }
        public ListEntry(string name, Update type, string nameProp, string key)
        {
            Name = name;
            Type = type;
            NameProp = nameProp;
            Key = key;
        }
        public override string ToString()
        {
            return "Изменение в коллекции: " + Name + "\nТип изменения: " + Type + "\nСвойство: " + NameProp + "\nКлюч: " + Key;

        }
    }
}