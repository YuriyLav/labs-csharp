using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class Article
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
    }
}
