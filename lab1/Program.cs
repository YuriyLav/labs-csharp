using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1");
            Magazine mag1 = new Magazine();
            Article ar1 = new Article(new Person("Николаев", "Дмитрий", new DateTime(1968, 5, 25)),
                "Объектно-ориентированное программирование на C++", 8.6);
            Article ar2 = new Article(new Person("Смирнов", "Николай", new DateTime(1975, 5, 25)),
                "Программирование на Python", 7.7);
            mag1.AddArticles(ar1, ar2);
            Console.WriteLine(mag1.ToShortString()+"\n");
            Console.WriteLine("Part 2");
            Console.WriteLine(mag1[Frequency.Weekly]);
            Console.WriteLine(mag1[Frequency.Monthly]);
            Console.WriteLine(mag1[Frequency.Yearly]);
            Console.WriteLine("");
            Console.WriteLine("Part 3");
            Magazine mag2 = new Magazine();
            mag2.Name = "Interesting magazine";
            mag2.Freq = Frequency.Monthly;
            mag2.Date = new DateTime(2019, 4, 12);
            mag2.Count = 100;
            Article a2 = new Article(new Person("Петров", "Василий", new DateTime(1955, 5, 25)),
                "Программирование на C", 8.6);
            Article a3 = new Article(new Person("Михайлов", "Александр", new DateTime(1989, 6, 14)),
                "История языка Java", 6.8);
            mag2.AddArticles(a2, a3);
            Console.WriteLine(mag2.ToString());
            Console.WriteLine("Part 4");
            Console.WriteLine("Enter the number of rows and columns. Use '.', ',', ' '");
            string number = Console.ReadLine();
            string[] numberValue = number.Split('.', ',', ' ');
            int nrow = Convert.ToInt32(numberValue[0]), ncolumns= Convert.ToInt32(numberValue[1]);
            int n = nrow * ncolumns;

            //Одномерный
            Article[] arr1 = new Article[n];
            for (int i = 0; i < n; i++)
            {
                arr1[i] = new Article();
            }
            Console.WriteLine("Создано "+n+" элементов\n");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i=0; i<n; i++)
            {
                arr1[i].AuthorInfo.Name = "Test Name";
            }
            sw.Stop();
            Console.WriteLine("Одномерный: "+ sw.Elapsed);

            //Двумерный прямоуголный
            Article[,] arr2 = new Article[nrow, ncolumns];
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumns; j++)
                {
                    arr2[i, j] = new Article();
                }
            }
            sw.Restart();
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumns; j++)
                {
                    arr2[i, j].AuthorInfo.Name = "Test Name";
                }
            }
            sw.Stop();
            Console.WriteLine("Двумерный прямоугольный: "+ sw.Elapsed);

            // Двумерный ступенчатый
            Article[][] arr3 = new Article[nrow][];
            for (int i = 0; i < nrow; i++)
            {
                arr3[i] = new Article[ncolumns];
                for (int j = 0; j < ncolumns; j++)
                {
                    arr3[i][j] = new Article();
                }
            }
            sw.Restart();
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumns; j++)
                {
                    arr3[i][j].AuthorInfo.Name = "Test Name";
                }
            }
            sw.Stop();
            Console.WriteLine("Двумерный ступенчатый: "+ sw.Elapsed+"\n");
        }
    }
}