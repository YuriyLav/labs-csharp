using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace lab4
{
    class Listener
    {
        private List<ListEntry> changeObj = new List<ListEntry>();
        public void Changes(object subject, EventArgs args)
        {
            var temp = args as MagazinesChangedEventArgs<string>;
            changeObj.Add(new ListEntry(temp.Name, temp.Type, temp.NameProp, temp.Key));
        }
        public override string ToString()
        {
            string result = "";
            foreach (var obj in changeObj)
            {
                result += "\nИзменения в коллекции: " + obj.Name + " Тип изменения: " + obj.Type + " Свойство: " + obj.NameProp + " Ключ: " + obj.Key.ToString();
            }
            return result;
        }
    }
}
