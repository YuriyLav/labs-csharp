using System;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ex 1
            Console.WriteLine("Exercise 1");
            Edition ed1 = new Edition();
            Edition ed2 = new Edition();
            if (ed1 == ed2) Console.WriteLine("Значения равны");
            Console.WriteLine(ed1.GetHashCode()+" "+ed2.GetHashCode());
            Console.WriteLine(ReferenceEquals(ed1, ed2)+"\n");

            //Ex2
            Console.WriteLine("Exercise 2");
            try
            {
                ed1.Count = -100;
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            //Ex3
            Console.WriteLine("Exercise 3");
            Magazine mag = new Magazine();
            Person p1 = new Person("Антон", "Марьянский", new DateTime(2002, 1, 8));
            Person p2 = new Person("Игорь", "Колесов", new DateTime(2002, 2, 2));
            Article a1 = new Article(p1, "Article1", 7);
            Article a2 = new Article(p2, "Article2", 8);
            mag.AddArticles(a1, a2);
            mag.AddEditors(p1, p2);
            Console.WriteLine(mag.ToString());

            //Ex4
            Console.WriteLine("Exercise 4");
            Console.WriteLine(mag.Edit.ToString()+"\n");

            //Ex5
            Console.WriteLine("Exercise 5");
            Magazine magCopy = (Magazine)mag.DeepCopy();
            mag.Name = "New Name";
            mag.Count = 500;
            mag.Date = new DateTime(1995, 11, 11);
            mag.Freq = Frequency.Weekly;
            Person p3= new Person("Владимир", "Комаревцев", new DateTime(2003, 5, 8));
            Article a3 = new Article(p3, "Article3", 6);
            mag.AddArticles(a3);
            mag.AddEditors(p3);
            Console.WriteLine("Source object: "+mag.ToString());
            Console.WriteLine("Deep copy: "+magCopy.ToString());

            //Ex6
            Console.WriteLine("Exercise 6");
            Magazine m = new Magazine();
            Article[] masArt = new Article[2];
            Person[] masPers = new Person[2];
            masPers[0] = new Person("Николай", "Петров", new DateTime(2003, 7, 9));
            masPers[1] = new Person("Егор", "Вилисов", new DateTime(2002, 4, 7));
            masArt[0] = new Article(masPers[0], "Interesting Article", 4);
            masArt[1] = new Article(masPers[1], "Cool Article", 8);
            m.AddEditors(masPers);
            m.AddArticles(masArt);
            Console.WriteLine("Список всех статей с рейтингом больше 5: ");
            foreach (var art in m.ArticlesRating(5))
            {
                Console.WriteLine(art.ToString());
            }

            //Ex7
            Console.WriteLine("\n"+"Exercise 7");
            Console.WriteLine("Cписок статей, в названии которых есть заданная строка: ");
            foreach (var art in m.ArticlesString("Interesting")) 
            {
                Console.WriteLine(art.ToString());
            }
        }
    }
}

