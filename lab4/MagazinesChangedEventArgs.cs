using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    class MagazinesChangedEventArgs<TKey> : EventArgs
    {
        public string Name { get; set; }
        public Update Type { get; set; }
        public string NameProp { get; set; }

        public TKey Key { get; set; }

        public MagazinesChangedEventArgs(string name, Update type, string nameProp, TKey key)
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