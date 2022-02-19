using System;
using System.Linq;

namespace CodeTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество массивов: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            int[][] arr = new int[n][];//объявляем массивы в массиве.
            RandomSize(ref arr, n); // с помощью этой функции, задаем размер каждого массива рандомно, и чтобы они не повторялись.
            FillingArray(ref arr, n); // заполняем массивы.
            for (int i = 0; i < n; i++)
            {
                if (i%2==0) EvenSort(ref arr[i]); //проверка порядкового номера на четность. В случае четности сорируем по возрастанию.
                else OddSort(ref arr[i]); // вызов метода сортировки по убыванию в случае нечетности.
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++) // вывод отсортированных массивов.
            {
                Console.Write($"Отсортированный массив {i}: ");
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void EvenSort(ref int[] arr) //сортировка вставками для четных массивов.
        {
            int n  = arr.Length;  
            int min = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (arr[j] < arr[i]) //нахождение минимумального элемента.
                    {
                        min = arr[j];
                        arr[j] = arr[i];
                        arr[i] = min;
                    }
                }
            }
        }

        static void OddSort (ref int[] arr) // сортирвока вставками для нечетных.
        {
            int n = arr.Length;
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (arr[j] > arr[i]) // нахождением максимального элемента.
                    {
                        max = arr[j];
                        arr[j] = arr[i];
                        arr[i] = max;
                    }
                }

            }
        }

        static void FillingArray(ref int[][] arr, int n)
        {
            Random rnd = new Random(); 
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Массив {i}: ");
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = rnd.Next(-10, 51); // заполняем рандомными числами от -10 до 50 каждый элемент массива последовательно.
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void RandomSize(ref int[][] arr, int n)
        {
            Random rnd = new Random();
            int[] mas = Enumerable.Range(1, 20).ToArray(); //заводим массив размерностей, в котором будут хранится значения возможных размеров массивов массива.
            int N = mas.Length;
            int m; // переменная для того,чтобы задать размерность массивам.
            for (int i = 1; i < N; i++)
            {
                mas[i] = i; //присваиваем каждому элементу значение.
            }

            int ind = 0; // индекс для массива массивов.
            while (ind < n)
            {
                for (int i = 0; i < N; i++)
                {
                    m = rnd.Next(mas.Length); // присваимваем размерности рандомно число из массива размерностей.
                    if ((mas[i] == m) && (mas[i] != 0)) //если элемент из массива размерностей не равен 0, значит его можно использовать, чтобы задать размер массиву массива. Иначе снова присвиваем размерности новый размер.
                    {
                        mas[i] = 0; //обнуляем размер в массиве размерностей, чтобы юольше не использовать данный размер для массивов.
                        arr[ind] = new int[m]; // присваиваем размер массиву.
                        ind++;
                        if (ind == n) break; // проверка, что ииндекс не вышел за границу. В случае выхода за границу, прерываем цикл.
                    }
                }
            }
        }
    }
}
