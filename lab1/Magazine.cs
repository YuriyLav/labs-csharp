using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Magazine{  
        string nameMagazine;
        Frequency frequencyInfo;
        DateTime dateMagazine;  
        int countMagazine;
        Article[] listArticles;
        public Magazine(string nameValue, Frequency freqValue, DateTime dateValue, int countValue)
        {
            nameMagazine = nameValue;
            frequencyInfo = freqValue;
            dateMagazine = dateValue;
            countMagazine = countValue;
        }
        public Magazine()
        {
            nameMagazine = "Unknown Magazine";
            frequencyInfo = Frequency.Monthly;
            dateMagazine = new DateTime(2021, 1, 1);
            countMagazine = 1000;
            listArticles = new Article[0];
        }
        public string Name
        {
            get
            {
                return nameMagazine;
            }
            set
            {
                //какие-то проверки (буква заглавная или нет)
                nameMagazine = value;
            }
        }
        public Frequency Freq
        {
            get
            {
                return frequencyInfo;
            }
            set
            {
                frequencyInfo = value;
            }
        }
        public DateTime Date
        {
            get
            {
                return dateMagazine;
            }
            set
            {
                dateMagazine = value;
            }
        }
        public int Count
        {
            get
            {
                return countMagazine;
            }
            set
            {
                countMagazine = value;
            }
        }
        public Article[] Art
        {
            get
            {
                return listArticles;
            }
            set
            {
                listArticles = value;
            }
        }
        public double AverageRate
        {
            get
            {
                double rate = 0;
                if (listArticles == null) return 0;
                foreach (var art in listArticles)
                {
                    rate += art.RateArticle;
                }
                return rate / listArticles.Length;
            }
        }
        public bool this[Frequency f]
        {
            get
            {
                return frequencyInfo == f;
            }
        }

        public void AddArticles(params Article[] newArticles)
        {
            //if (listArticles == null)
            //{
            //    listArticles = newArticles;
            //    return;
            //}
            //Array.ConstrainedCopy(newArticles, 0, listArticles, listArticles.Length, newArticles.Length);
            //Array.Copy(newArticles, 0, listArticles, listArticles.Length, newArticles.Length);
                if (listArticles == null)
                {
                    listArticles = newArticles;
                }
                Array.Resize(ref listArticles, listArticles.Length + newArticles.Length);
                newArticles.CopyTo(listArticles, listArticles.Length - newArticles.Length);
        }
        public override string ToString()
        {
            string ans = "";
            foreach (var art in listArticles)
            {
                ans += art.ToString() + "\n";
            }
            return Name + " " + Freq + " " + Date.ToShortDateString() + " " +
                   Count + "\n" + ans;
        }

        public string ToShortString()
        {
            return Name + " " + Freq + " " + Date.ToShortDateString()+" "+Count+" "+AverageRate;
        }

    }
}
