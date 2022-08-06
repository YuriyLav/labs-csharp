using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class Magazine:Edition
    {
        Frequency frequencyInfo;
        ArrayList editors;
        ArrayList articles;
        public Magazine(string nameValue, Frequency freqValue, DateTime dateValue, int countValue)
        {
            nameEd = nameValue;
            frequencyInfo = freqValue;
            dateEd = dateValue;
            countEd = countValue;
        }
        public Magazine()
        {
            nameEd = "Unknown Magazine";
            frequencyInfo = Frequency.Monthly;
            dateEd = new DateTime(2021, 1, 1);
            countEd = 1000;
        }
        public Frequency Freq
        {
            set
            {
                frequencyInfo = value;
            }
        }
        public double AverageRate
        {
            get
            {
                double rate = 0;
                if (articles == null) return 0;
                foreach (Article art in articles)
                {
                    rate += art.RateArticle;
                }
                return rate /articles.Count;
            }
        }
        public ArrayList Articles
        {
            get
            {
                return articles;
            }
        }
        public ArrayList Editors
        {
            get
            {
                return editors;
            }
        }
        public Edition Edit
        {
            get
            {
                Edition ed = new Edition(nameEd, dateEd, countEd);
                return ed;
            }
            set
            {
                nameEd = value.Name;
                dateEd = value.Date;
                countEd = value.Count;
            }
        }

        public void AddArticles(params Article[] newArticles)
        {
            if (articles == null)
            {
                articles = new ArrayList();
            }
            articles.AddRange(newArticles);
        }
        public void AddEditors(params Person[] newEditors)
        {
            if (editors == null)
            {
                editors = new ArrayList();
            }
            editors.AddRange(newEditors);
        }
        public override string ToString()
        {
            string ans = "";
            foreach (var art in articles)
            {
                ans += art.ToString() + "\n";
            }
            return Name + " " + frequencyInfo + " " + Date.ToShortDateString() + " " +
                   Count + "\n" + ans;
        }
        public virtual string ToShortString()
        {
            return Name + " " + frequencyInfo + " " + Date.ToShortDateString() + " " + Count + " " + AverageRate;
        }
        public override object DeepCopy()
        {
            Magazine m = new Magazine();

            m.frequencyInfo =frequencyInfo;
            m.countEd = countEd;
            m.nameEd = nameEd;
            m.dateEd = dateEd;
            m.articles = new ArrayList();
            foreach (Article art in articles)
            {
                m.articles.Add(art.DeepCopy());
            }
            m.editors = new ArrayList();
            foreach (Person person in editors)
            {
                m.editors.Add(person.DeepCopy());
            }
            return m;
        }
        //public IEnumerator GetEnumerator()
        //{
        //    foreach(object a in articles)
        //    {
        //        yield return a as Article;
        //    }
        //}
        public IEnumerable ArticlesRating(double rate)
        {
            foreach (Article a in articles)
            {
                if (a.RateArticle > rate) yield return a;
            }
        }

        public IEnumerable ArticlesString(string substr)
        {
            foreach (Article a in articles)
            {
                if (a.NameArticle.Contains(substr)) yield return a;
            }
        }
    }
}