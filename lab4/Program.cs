using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            //ex 1
            Console.WriteLine("\nExercise 1\n");

            List<Person> editors1 = new List<Person>(2);
            editors1.Add(new Person("Alexey", "Lavrushkin", new DateTime(1974, 10, 24)));
            editors1.Add(new Person("Liliana", "Lubimova", new DateTime(1975, 1, 20)));
            List<Article> articles1 = new List<Article>(2);
            articles1.Add(new Article(editors1[0], "Some Article", 10));
            articles1.Add(new Article(editors1[1], "Interesting Article", 10));
            Magazine m1 = new Magazine("Magazine of articles 1", Frequency.Weekly, new DateTime(2021, 12, 2), 500);
            m1.Articles.AddRange(articles1);
            m1.Editors.AddRange(editors1);

            List<Person> editors2 = new List<Person>(2);
            editors2.Add(new Person("Yurii", "Lavrushkin", new DateTime(2002, 11, 19)));
            editors2.Add(new Person("Marina", "Lavrushkina", new DateTime(2007, 4, 17)));
            List<Article> articles2 = new List<Article>(2);
            articles2.Add(new Article(editors2[0], "Article 3", 9));
            articles2.Add(new Article(editors2[1], "Article 4", 8));
            Magazine m2 = new Magazine("Magazine of articles 2", Frequency.Weekly, new DateTime(2019, 10, 2), 100);
            m2.Articles.AddRange(articles1);
            m2.Editors.AddRange(editors1);

            List<Person> editors3 = new List<Person>(2);
            editors3.Add(new Person("Igor", "Kolesov", new DateTime(2002, 10, 24)));
            editors3.Add(new Person("Anton", "Maryanskiy", new DateTime(2002, 1, 20)));
            List<Article> articles3 = new List<Article>(2);
            articles3.Add(new Article(editors3[0], "Programming on c++", 8));
            articles3.Add(new Article(editors3[1], "Programming on c#", 7.5));
            Magazine m3 = new Magazine("Magazine about programming", Frequency.Monthly, new DateTime(2021, 6, 2), 1100);
            m3.Articles.AddRange(articles1);
            m3.Editors.AddRange(editors1);

            List<Person> editors4 = new List<Person>(2);
            editors4.Add(new Person("Daniil", "Birukov", new DateTime(2002, 6, 19)));
            editors4.Add(new Person("Egor", "Vilisov", new DateTime(2002, 4, 8)));
            List<Article> articles4 = new List<Article>(2);
            articles4.Add(new Article(editors4[0], "Physical culture", 7));
            articles4.Add(new Article(editors4[1], "Fashion", 6));
            Magazine m4 = new Magazine("Magazine of articles 4", Frequency.Yearly, new DateTime(2019, 10, 2), 150);
            m4.Articles.AddRange(articles4);
            m4.Editors.AddRange(editors4);

            KeySelector<String> selector = magazine => magazine.GetHashCode().ToString();
            MagazineCollection<string> coll1 = new MagazineCollection<string>(selector);
            MagazineCollection<string> coll2 = new MagazineCollection<string>(selector);
            coll1.AddMagazines(m1);
            coll1.AddMagazines(m2);
            coll2.AddMagazines(m3);
            coll2.AddMagazines(m4);
            Console.WriteLine(coll1.ToString());
            Console.WriteLine(coll2.ToString());

            //ex 2
            Listener listener = new Listener();
            coll1.MagazinesChanged += listener.Changes;
            coll2.MagazinesChanged += listener.Changes;

            //ex3
            // new magazine
            List<Person> editors5 = new List<Person>(2);
            editors5.Add(new Person("Vladimir", "Komarevtsev", new DateTime(2002, 8, 11)));
            editors5.Add(new Person("Ilya", "Antipov", new DateTime(2002, 6, 9)));
            List<Article> articles5 = new List<Article>(2);
            articles5.Add(new Article(editors5[0], "Kuban", 7));
            articles5.Add(new Article(editors5[1], "Etherium", 10));
            Magazine m5 = new Magazine("Magazine of articles 5", Frequency.Monthly, new DateTime(2020, 2, 17), 250);
            m5.Articles.AddRange(articles5);
            m5.Editors.AddRange(editors5);
            // Add new elements
            coll1.AddMagazines(m5);
            coll2.AddMagazines(m5);

            // Change elements properties
            m1.Date = new DateTime(1950, 10, 10);
            m1.Count = 1000;

            // Replace element
            coll1.Replace(m2, m3);

            // Change properties
            m2.Count = 0;

            Console.WriteLine("\nExercise 4\n");
            Console.WriteLine(listener.ToString());
        }
    }
}
