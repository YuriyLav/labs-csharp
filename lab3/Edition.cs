using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Edition
    {
        protected string nameEd;
        protected DateTime dateEd;
        protected int countEd;
        public Edition(string nameValue, DateTime dateValue, int countValue)
        {
            nameEd = nameValue;
            dateEd = dateValue;
            countEd = countValue;
        }
        public Edition()
        {
            nameEd = "Просвещение";
            dateEd = new DateTime(2021, 1, 1);
            countEd = 1000;
        }
        public string Name
        {
            get
            {
                return nameEd;
            }
            set
            {
                nameEd = value;
            }
        }
        public DateTime Date
        {
            get
            {
                return dateEd;
            }
            set
            {
                dateEd = value;
            }
        }
        public int Count
        {
            get
            {
                return countEd;
            }
            set
            {
                if (value < 0) throw new ArgumentException("Тираж не может быть отрицательным\n");
                else
                    countEd = value;
            }
        }
        public override bool Equals(object ed)
        {
            Edition obj = ed as Edition;
            if (obj.nameEd == nameEd && obj.dateEd == dateEd && obj.countEd == countEd) return true;
            else
                return false;
        }
        public static bool operator ==(Edition e1, Edition e2)
        {
            if (e1.Equals(e2)) return true;
            else
                return false;
        }
        public static bool operator !=(Edition e1, Edition e2)
        {
            if (!e1.Equals(e2)) return true;
            else
                return false;
        }
        public virtual object DeepCopy()
        {
            Edition e = new Edition(Name = this.Name, Date = this.Date, Count = this.Count);
            return e;
        }
        public override int GetHashCode()
        {
            return nameEd.GetHashCode() + dateEd.GetHashCode() + countEd.GetHashCode();
        }
        public override string ToString()
        {
            return Name + " " + Date.ToShortDateString() + " " + Count;
        }
    }
}
