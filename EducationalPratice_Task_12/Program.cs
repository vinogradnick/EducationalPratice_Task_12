using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPratice_Task_12
{
    class Program
    {
        /*
         * 7.	Блочная сортировка.
            9.	Сортировка простым выбором.

         */
        static void Print(int[] mas)
        {
            foreach (int item in mas)
                Console.Write($" {item} ");
            Console.WriteLine();
        }
        static Random random = new Random();
        static void Fill(ref int[] mas)
        {

            for (int i = 0; i < mas.Length; i++)
                mas[i] = random.Next(1000);
        }
        public static int[] bucketSort(int[] mas)
        {
            int count_eq = 0;
            int count_choises = 0;
            //поиск максимального элемента массива
            int maxValue = mas[0];
            for (int k = 1; k < mas.Length; k++)
                if (mas[k] > maxValue)
                {
                    count_eq++;
                    maxValue = mas[k];
                }

            int i, j;
            //создадим вспомогательный массив
            int[] bucket = new int[maxValue + 1];
            //распределим числа по карманам
            for (i = 0; i < mas.Length; i++)
            {
                count_choises++;
                bucket[mas[i]]++;
            }

            //отсортируем числа в карманах используя сортировку подсчетом
            for (i = 0, j = 0; i < bucket.Length; i++)
                for (; bucket[i] > 0; (bucket[i])--)
                {
                    count_eq++;
                    mas[j++] = i;
                }
            Console.WriteLine();

            Console.WriteLine("Количество сравнений " + count_eq);
            Console.WriteLine("Количество перестановок " + count_choises);
            Console.WriteLine();


            return mas;
        }
        static int[] ViborSort(int[] mas)
        {
            int count_eq = 0;
            int count_choises = 0;
            for (int i = 0; i < mas.Length - 1; i++)
            {
                //поиск минимального числа
                int min = i;
                for (int j = i + 1; j < mas.Length; j++)
                    if (mas[j] < mas[min])
                    {
                        min = j;
                        count_eq++;
                    }
                //обмен элементов
                int temp = mas[min];
                mas[min] = mas[i];
                mas[i] = temp;
                count_choises++;
            }
            Console.WriteLine();

            Console.WriteLine("Количество сравнений " + count_eq);
            Console.WriteLine("Количество перестановок " + count_choises);
            Console.WriteLine();

            return mas;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Сортировка массива");
            int[] sorted_inc = new int[10];
            int[] sorted_dec = new int[10];
            int[] unsorted = new int[10];
            Fill(ref sorted_inc);
            Fill(ref sorted_dec);
            Fill(ref unsorted);
            Array.Sort(sorted_inc);
            Array.Sort(sorted_dec);
            Array.Reverse(sorted_dec);

            Print(sorted_inc);
            Print(sorted_dec);
            Print(unsorted);

            Console.WriteLine();
            Console.WriteLine("Сложность сортировки простым выбором => O(n2)");
            Console.WriteLine("Сложность алгоритма блочной сортировки => O(N)");
            Console.WriteLine("Сортировка простым выбором,массива в котором элементы расположены по возрастанию ==>");
            Print(ViborSort(sorted_inc));
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("Сортировка простым выбором,массива в котором элементы расположены по убыванию ==>");
            Print(ViborSort(sorted_dec));
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("Сортировка простым выбором,массива в котором элементы беспорядочны ==>");
            Print(ViborSort(unsorted));
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("Блочная сортировка массива в котором элементы расположены по возрастанию ==>");
            Print(bucketSort(sorted_inc));
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("Блочная сортировка массива в котором элементы расположены по убыванию ==>");
            Print(bucketSort(sorted_dec));
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("Блочная сортировка массива в котором элементы беспорядочны ==>");
            Print(bucketSort(unsorted));
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            Console.ReadKey();

        }

    }
}
