using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Article : IRateAndCopy, IComparable, IComparer<Article>
    {
        public Person AuthorInfo
        {
            get;
            set;
        }
        public string NameArticle
        {
            get;
            set;
        }
        public double RateArticle
        {
            get;
            set;
        }

        public double Rating { get; }

        public Article(Person personValue, string nameValue, double rateValue)
        {
            AuthorInfo = personValue;
            NameArticle = nameValue;
            RateArticle = rateValue;
        }
        public Article()
        {
            AuthorInfo = new Person("Дмитрий", "Павлов", new DateTime(1975, 1, 1));
            NameArticle = "Unknown article";
            RateArticle = 7.5;
        }
        public override string ToString()
        {
            return AuthorInfo.ToString() + " " + NameArticle + " " + RateArticle;
        }
        public object DeepCopy()
        {
            Article a = new Article { AuthorInfo = this.AuthorInfo, RateArticle = this.RateArticle, NameArticle = this.NameArticle };
            return a;
        }
        public int CompareTo(object obj)
        {
            var art = obj as Article;
            if (art.NameArticle != null) return NameArticle.CompareTo(art.NameArticle);
            throw new Exception("Имя статьи пустое");
        }
        public int Compare(Article art1, Article art2)
        {
            return art1.AuthorInfo.Surname.CompareTo(art2.AuthorInfo.Surname);
        }
    }
    class ArticleRate : IComparer<Article>
    {
        public int Compare(Article art1, Article art2)
        {
            return art1.RateArticle.CompareTo(art2.RateArticle);
        }
    }

}
