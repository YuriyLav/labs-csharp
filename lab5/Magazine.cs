using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace lab5
{
    [Serializable]
    class Magazine : Edition, IRateAndCopy
    {
        private Frequency frequencyInfo;
        private List<Person> editors = new List<Person>();
        private List<Article> articles = new List<Article>();
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
            mag.articles = new List<Article>();
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
        public IEnumerator GetEnumerator()
        {
            foreach (object a in articles)
            {
                yield return a as Article;
            }
        }
        public Magazine MagDeepCopy()
        {
            MemoryStream mstream = new MemoryStream();
            try
            {
                BinaryFormatter format = new BinaryFormatter();
                format.Serialize(mstream, this);
                mstream.Position = 0;
                return (Magazine)format.Deserialize(mstream);
            }
            catch(Exception e)
            {
                Console.WriteLine("Что-то пошло не так! ");
                Console.WriteLine(e.Message);
                return new Magazine();
            }
            finally
            {
                mstream?.Close();
            }

        }
        public bool Save(string filename)
        {
            try
            {
                BinaryFormatter format = new BinaryFormatter();
                using (FileStream f = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    format.Serialize(f, this);
                }
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Что-то пошло не так! ");
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool Load(string filename)
        {
            try
            {
                BinaryFormatter format = new BinaryFormatter();
                using (FileStream f = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    Magazine mag = (Magazine)format.Deserialize(f);
                    nameEd = mag.nameEd;
                    frequencyInfo = mag.frequencyInfo;
                    dateEd = mag.dateEd;
                    countEd = mag.countEd;
                    articles.AddRange(mag.articles);
                    editors.AddRange(mag.editors);
                    return true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Что-то пошло не так! ");
                Console.WriteLine(e.Message);
                return false;
            }

        }
        public bool AddFromConsole()
        {
            try
            {
                Console.WriteLine("Введите информацию о статье в формате\n" + "AuthorName AuthorSurname BirthdayYear BirthdayMonth BirthdayDay ArticleName Rating");
                string[] line = Console.ReadLine().Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
                Person author = new Person(line[0], line[1], new DateTime(Convert.ToInt32(line[2]), Convert.ToInt32(line[3]), Convert.ToInt32(line[4])));
                articles.Add(new Article(author, line[5], Convert.ToDouble(line[6])));
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Неверный ввод! ");
                return false;
            }
        }
        public static bool Save(string filename, Magazine obj)
        {
            try
            {
                BinaryFormatter format = new BinaryFormatter();
                using (FileStream f = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    format.Serialize(f, obj);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка! ");
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static bool Load(string filename, Magazine obj)
        {
            try
            {
                BinaryFormatter format = new BinaryFormatter();
                using (FileStream f = new FileStream(filename, FileMode.Open))
                {
                    Magazine mag = (Magazine)format.Deserialize(f);
                    obj.nameEd = mag.nameEd;
                    obj.frequencyInfo = mag.frequencyInfo;
                    obj.dateEd = mag.dateEd;
                    obj.countEd = mag.countEd;
                    obj.articles.AddRange(mag.articles);
                    obj.editors.AddRange(mag.editors);
                    return true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Ошибка! ");
                Console.WriteLine(e.Message);
                return false;
            }
        }
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
