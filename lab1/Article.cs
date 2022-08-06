using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
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
            AuthorInfo=new Person("Дмитрий", "Павлов", new DateTime(1975, 1, 1));
            NameArticle = "Unknown article";
            RateArticle = 7.5;
        }
        public override string ToString()
        {
            return AuthorInfo.ToString()+" "+NameArticle+" "+RateArticle;
        }
    }
}

