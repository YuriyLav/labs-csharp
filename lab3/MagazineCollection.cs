using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    delegate Tkey KeySelector<Tkey>(Magazine mg);
    class MagazineCollection<Tkey>
    {
        private Dictionary<Tkey, Magazine> dict;
        private KeySelector<Tkey> key;
        public MagazineCollection(KeySelector<Tkey> keySelector)
        {
            key = keySelector;
            dict = new Dictionary<Tkey, Magazine>();
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
        public IEnumerable<IGrouping<Frequency, KeyValuePair<Tkey, Magazine>>> GroupCollection
        {
            get
            {
                return dict.GroupBy(mag => mag.Value.Freq);
            }
        }
        public IEnumerable<KeyValuePair<Tkey, Magazine>> FrequencyGroup(Frequency value)
        {
            return dict.Where(el => el.Value.Freq == value);
        }
    }
}
