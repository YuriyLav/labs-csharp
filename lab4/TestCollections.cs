using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    class TestCollections<TKey, TValue>
    {
        private List<TKey> listKey = new List<TKey>();
        private List<string> listStr = new List<string>();
        private Dictionary<TKey, TValue> dictKeyVal = new Dictionary<TKey, TValue>();
        private Dictionary<string, TValue> dictStrVal = new Dictionary<string, TValue>();
        GenerateElement<TKey, TValue> element;
        public TestCollections(int count, GenerateElement<TKey, TValue> el)
        {
            element = el;
            for(int i=0; i<count; i++)
            {
                var elem = element(i);
                listKey.Add(elem.Key);
                listStr.Add(elem.Key.ToString());
                dictKeyVal.Add(elem.Key, elem.Value);
                dictStrVal.Add(elem.Key.ToString(), elem.Value);
            }
        }
        public void timeListKey()
        {
            Console.WriteLine("\nВремя поиска элемента в коллекции List<TKey>\n");
            var first = listKey[0];
            var center = listKey[listKey.Count / 2];
            var last = listKey[listKey.Count - 1];
            var el = element(listKey.Count + 1).Key;

            var watch = Stopwatch.StartNew();
            listKey.Contains(first);
            watch.Stop();
            Console.WriteLine("Для певрого элемента: " + watch.Elapsed);

            watch.Restart();
            listKey.Contains(center);
            watch.Stop();
            Console.WriteLine("Для среднего элемента: " + watch.Elapsed);

            watch.Restart();
            listKey.Contains(last);
            watch.Stop();
            Console.WriteLine("Для последнего элемента: " + watch.Elapsed);

            watch.Restart();
            listKey.Contains(el);
            watch.Stop();
            Console.WriteLine("Для элемента не входящего в коллекцию: " + watch.Elapsed);
        }
        public void timeListStrKey()
        {
            Console.WriteLine("\nВремя поиска элемента в коллекции List<string>\n");
            var first = listStr[0];
            var center = listStr[listStr.Count / 2];
            var last = listStr[listStr.Count - 1];
            var el = element(listStr.Count + 1).Key;

            var watch = Stopwatch.StartNew();
            listStr.Contains(first);
            watch.Stop();
            Console.WriteLine("Для певрого элемента: " + watch.Elapsed);

            watch.Restart();
            listStr.Contains(center);
            watch.Stop();
            Console.WriteLine("Для среднего элемента: " + watch.Elapsed);

            watch.Restart();
            listStr.Contains(last);
            watch.Stop();
            Console.WriteLine("Для последнего элемента: " + watch.Elapsed);

            watch.Restart();
            listKey.Contains(el);
            watch.Stop();
            Console.WriteLine("Для элемента не входящего в коллекцию: " + watch.Elapsed);
        }
        public void timeDictKey()
        {
            Console.WriteLine("\nВремя поиска элемента в коллекции Dictionary<TKey, TValue>\n");
            var first = dictKeyVal.ElementAt(0).Key;
            var center = dictKeyVal.ElementAt(dictKeyVal.Count / 2).Key;
            var last = dictKeyVal.ElementAt(dictKeyVal.Count - 1).Key;
            var el = element(dictKeyVal.Count + 1).Key;

            var watch = Stopwatch.StartNew();
            dictKeyVal.ContainsKey(first);
            watch.Stop();
            Console.WriteLine("Для певрого элемента: " + watch.Elapsed);

            watch.Restart();
            dictKeyVal.ContainsKey(center);
            watch.Stop();
            Console.WriteLine("Для среднего элемента: " + watch.Elapsed);

            watch.Restart();
            dictKeyVal.ContainsKey(last);
            watch.Stop();
            Console.WriteLine("Для последнего элемента: " + watch.Elapsed);

            watch.Restart();
            listKey.Contains(el);
            watch.Stop();
            Console.WriteLine("Для элемента не входящего в коллекцию: " + watch.Elapsed);
        }
        public void timeDictStrKey()
        {
            Console.WriteLine("\nВремя поиска элемента в коллекции Dictionary<string, TValue>\n");
            var first = dictStrVal.ElementAt(0).Key;
            var center = dictStrVal.ElementAt(dictStrVal.Count/2).Key;
            var last = dictStrVal.ElementAt(dictStrVal.Count - 1).Key;
            var el = element(dictStrVal.Count + 1).Key.ToString();

            var watch = Stopwatch.StartNew();
            dictStrVal.ContainsKey(first);
            watch.Stop();
            Console.WriteLine("Для певрого элемента: " + watch.Elapsed);

            watch.Restart();
            dictStrVal.ContainsKey(center);
            watch.Stop();
            Console.WriteLine("Для среднего элемента: " + watch.Elapsed);

            watch.Restart();
            dictStrVal.ContainsKey(last);
            watch.Stop();
            Console.WriteLine("Для последнего элемента: " + watch.Elapsed);

            watch.Restart();
            dictStrVal.ContainsKey(el);
            watch.Stop();
            Console.WriteLine("Для элемента не входящего в коллекцию: " + watch.Elapsed);
        }
        public void timeDictValue()
        {
            Console.WriteLine("\nВремя поиска элемента в коллекции Dictionary<string, TValue>\n");
            var first = dictStrVal.ElementAt(0).Value;
            var center = dictStrVal.ElementAt(dictStrVal.Count/2).Value;
            var last = dictStrVal.ElementAt(dictStrVal.Count-1).Value;
            var el = element(dictStrVal.Count + 1).Value;

            var watch = Stopwatch.StartNew();
            dictStrVal.ContainsValue(first);
            watch.Stop();
            Console.WriteLine("Для певрого элемента: " + watch.Elapsed);

            watch.Restart();
            dictStrVal.ContainsValue(center);
            watch.Stop();
            Console.WriteLine("Для среднего элемента: " + watch.Elapsed);

            watch.Restart();
            dictStrVal.ContainsValue(last);
            watch.Stop();
            Console.WriteLine("Для последнего элемента: " + watch.Elapsed);

            watch.Restart();
            dictStrVal.ContainsValue(el);
            watch.Stop();
            Console.WriteLine("Для элемента не входящего в коллекцию: " + watch.Elapsed);
        }
    }
}
