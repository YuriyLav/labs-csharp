using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> editors1 = new List<Person>(2);
            editors1.Add(new Person("Alexey", "Lavrushkin", new DateTime(1974, 10, 24)));
            editors1.Add(new Person("Liliana", "Lubimova", new DateTime(1975, 1, 20)));
            List<Article> articles1 = new List<Article>(2);
            articles1.Add(new Article(editors1[0], "Some Article", 10));
            articles1.Add(new Article(editors1[1], "Interesting Article", 10));
            Magazine m1 = new Magazine("Magazine of articles 1", Frequency.Weekly, new DateTime(2021, 12, 2), 500);
            m1.Articles.AddRange(articles1);
            m1.Editors.AddRange(editors1);
            Magazine m2 = (Magazine)m1.MagDeepCopy();
            Console.WriteLine("Исходный объект: ");
            Console.WriteLine(m1.ToString());
            Console.WriteLine("Копия объекта: ");
            Console.WriteLine(m2.ToString());


            Magazine m3 = new Magazine();
            Console.WriteLine("Введите имя файла (file.bin): ");
            string filename = Console.ReadLine();
            m3.Load(filename);
            Console.WriteLine("Загруженно с файла:");
            Console.WriteLine(m3.ToString());


            m3.AddFromConsole();
            m3.Save(filename);
            Console.WriteLine("Сохранено в файл:");
            Console.WriteLine(m3.ToString());


            Magazine.Load(filename, m1);
            m1.AddFromConsole();
            Magazine.Save(filename, m1);


            Console.WriteLine(m1.ToString());
        }
    }
}
