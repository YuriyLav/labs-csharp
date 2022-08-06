using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ex1
            Console.WriteLine("Exercise 1");
            var mg = new Magazine("Interesting magazine", Frequency.Monthly, new DateTime(2016, 2, 1), 1000);
            var a1 = new Article(new Person("Антон", "Марьянский", new DateTime(2002, 1, 1)), "Программирование на C++", 6);
            var a2 = new Article(new Person("Игорь", "Колесов", new DateTime(2002, 1, 1)), "Программирование на C#", 8);
            var a3 = new Article(new Person("Марина", "Лаврушкина", new DateTime(2007, 1, 1)), "Английский для ЕГЭ", 7);
            mg.AddArticles(a1, a2, a3);
            Console.WriteLine("До сортировки:");
            foreach (Article a in mg.Articles)
            {
                Console.WriteLine(a.ToString());
            }
            Console.WriteLine("\n"+"Сортировка по названию статьи:");
            mg.SortArticleName();
            foreach (Article a in mg.Articles)
            {
                Console.WriteLine(a.ToString());
            }
            Console.WriteLine("\n" + "Сортировка по фамилии автора:");
            mg.SortAuthorSurname();
            foreach (Article a in mg.Articles)
            {
                Console.WriteLine(a.ToString());
            }
            Console.WriteLine("\n" + "Сортировка по рейтингу статьи:");
            mg.SortArticleRate();
            foreach (Article a in mg.Articles)
            {
                Console.WriteLine(a.ToString());
            }

            //Ex2
            Console.WriteLine("\n\nExercise 2");
            KeySelector<String> key = delegate (Magazine mag) { return mag.GetHashCode().ToString(); };
            MagazineCollection<String> magCollection = new MagazineCollection<string>(key);
            magCollection.AddMagazines(mg);
            Console.WriteLine(magCollection.ToString());

            //Ex3
            Console.WriteLine("\n\nExercise 3");
            Console.WriteLine(magCollection.MaxAverageRate);
            var group = magCollection.FrequencyGroup(Frequency.Monthly);
            Console.WriteLine("Журналы с месячной периодичностью выхода: ");
            foreach (var val in group)
            {
                Console.WriteLine(val.Value);
            }


            foreach (var el in magCollection.GroupCollection)
            {
                Console.WriteLine(el.Key);
                foreach (var name in el)
                {
                    Console.WriteLine(name);
                }
            }

            //Ex4
            Console.WriteLine("\n\nExercise 4");
            int n;
            Console.WriteLine("Введите количество элементов");
            n = int.Parse(Console.ReadLine());
            GenerateElement<Edition, Magazine> d = delegate (int j)
            {
                var k = new Edition("Some Edition", new DateTime(1980, 1, 1), 500 + j);
                var value = new Magazine("Some Magazine", Frequency.Weekly, new DateTime(1990,12, 30), 700 + j);
                return new KeyValuePair<Edition, Magazine>(k, value);
            };

            var searchTest = new TestCollections<Edition, Magazine>(n, d);
            searchTest.timeListKey();
            searchTest.timeListStrKey();
            searchTest.timeDictKey();
            searchTest.timeDictStrKey();
            searchTest.timeDictValue();
        }
    }
}
