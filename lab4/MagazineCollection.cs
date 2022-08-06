using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    delegate TKey KeySelector<TKey>(Magazine mg);
    delegate void MagazinesChangedHandler<TKey>(object source, MagazinesChangedEventArgs<TKey> args);
    class MagazineCollection<TKey>
    {
        private Dictionary<TKey, Magazine> dict;
        private KeySelector<TKey> key;
        public string Name { get; set; }
        public bool Replace(Magazine mold, Magazine mnew)
        {
            if (dict.ContainsValue(mold))
            {
                foreach (KeyValuePair<TKey, Magazine> mag in dict)
                {
                    if (mag.Value == mold)
                    {
                        dict[mag.Key] = mnew;
                        MagazinePropertyChanged(Update.Replace, "None", mag.Key);
                        mold.PropertyChanged -= PropChange;
                        mnew.PropertyChanged += PropChange;
                        break;
                    }
                }
                return true;
            }
            else return false;
        }
        public event MagazinesChangedHandler<TKey> MagazinesChanged;
        private void MagazinePropertyChanged(Update update, string name, TKey key)
        {
            MagazinesChanged?.Invoke(this, new MagazinesChangedEventArgs<TKey>(Name, update, name, key));
        }

        private void PropChange(object source, EventArgs args)
        {
            MagazinePropertyChanged(Update.Property, (args as MagazinesChangedEventArgs<string>).NameProp, key((Magazine)source));
        }

        public MagazineCollection(KeySelector<TKey> keySelector)
        {
            key = keySelector;
            dict = new Dictionary<TKey, Magazine>();
        }
        public void AddDefaults()
        {
            if (dict.Count == 0)
            {
                Magazine mg = new Magazine();
                dict.Add(key(mg), mg);
            }
        }
        public void AddMagazines(params Magazine[] mags)
        {
            foreach (Magazine mag in mags)
            {
                dict.Add(key(mag), mag);
            }
        }
        public override string ToString()
        {
            string str = "Журналы: ";
            foreach (Magazine mag in dict.Values)
            {
                str += mag.ToString();
            }

            return str;
        }
        public virtual string ToShortString()
        {
            string str = "Журналы: ";
            foreach (Magazine mag in dict.Values)
            {
                str += mag.ToShortString();
            }

            return str;
        }
        public double MaxAverageRate
        {
            get
            {

                if (dict.Count > 0) return dict.Values.Max(m => m.AverageRate);
                return 0;
            }
        }
        public IEnumerable<IGrouping<Frequency, KeyValuePair<TKey, Magazine>>> GroupCollection
        {
            get
            {
                return dict.GroupBy(mag => mag.Value.Freq);
            }
        }
        public IEnumerable<KeyValuePair<TKey, Magazine>> FrequencyGroup(Frequency value)
        {
            return dict.Where(el => el.Value.Freq == value);
        }
    }
}
