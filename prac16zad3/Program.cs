using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac16zad3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите массив чисел с плавающей запятой");
                Console.WriteLine("Пример ввода массива = {1,2 3 4 2 1 3 1,3 3}");
                double[] array = Console.ReadLine().Split().Select(double.Parse).ToArray();

                var frq = array.GroupBy(x => x)
                    .Select(g => new { Number = g.Key, Frquncy = g.Count() });

                Console.WriteLine("Число\tЧастота");
                foreach (var item in frq)
                {
                    Console.WriteLine($"{item.Number}\t{item.Frquncy}");
                }
                double[] newarry = new double[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    double number = array[i];
                    int freq = frq.Single(x => x.Number == number).Frquncy;
                    newarry[i] = number * freq;
                }
                Console.WriteLine("Число  Частота (старого массива)");
                foreach (var item in frq)
                {
                    double numver = item.Number;
                    int freq = item.Frquncy;
                    double multi = numver * freq;
                    Console.WriteLine($"{multi}\t{freq}");
                }
            }
            catch { Console.WriteLine("Вы ввели неправильный массив"); }
            Console.ReadKey();
        }
    }
}
