using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Magazine : Edition, IRateAndCopy
    {
        private Frequency frequencyInfo;
        private List<Person> editors = new List<Person>();
        private List<Article> articles=new List<Article>();
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
            get
            {
                return frequencyInfo;
            }
        }
        public double Rating { get; }
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
                return rate / articles.Count;
            }
        }
        public List<Article> Articles
        {
            get
            {
                return articles;
            }
        }
        public List<Person> Editors
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
            //if (articles == null)
            //{
            //    articles = new List<Article>();
            //}
            articles.AddRange(newArticles);
        }
        public void AddEditors(params Person[] newEditors)
        {
            //if (editors == null)
            //{
            //    editors = new List<Person>();
            //}
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
            Magazine mag = new Magazine();

            mag.frequencyInfo = frequencyInfo;
            mag.countEd = countEd;
            mag.nameEd = nameEd;
            mag.dateEd = dateEd;
            mag.articles = new List<Article> ();
            foreach (Article art in articles)
            {
                mag.articles.Add((Article)art.DeepCopy());
            }
            mag.editors = new List<Person>();
            foreach (Person person in editors)
            {
                mag.editors.Add((Person)person.DeepCopy());
            }
            return mag;
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

        public IEnumerable ArticlesString(string str)
        {
            foreach (Article a in articles)
            {
                if (a.NameArticle.Contains(str)) yield return a;
            }
        }
        public void SortArticleName()
        {
            articles.Sort(); 
        }

        public void SortAuthorSurname()
        {
            articles.Sort(new Article());
        }

        public void SortArticleRate()
        {
            articles.Sort(new ArticleRate());
        }
    }
}
