using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            TestQuickSort();
            TestQuickSort2();
            TestQuickSort3();
            TestEmptyArray();
            //При попытке создать массив с 1500000000 элементов получаем OutOfMemoryException
            //TestVeryBigSort();

            Console.ReadKey();
        }

        private static int partition(int[] array, int start, int end)
        {
            int temp;//swap helper
            int marker = start;//divides left and right subarrays
            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end]) //array[end] is pivot
                {
                    temp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            //put pivot(array[end]) between left and right subarrays
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

        //рекурсивная реализация сортировки, принимает массив и индексы начала и конца
        private static void QuickSort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = partition(array, start, end);
            QuickSort(array, start, pivot - 1);
            QuickSort(array, pivot + 1, end);
        }

        private static void TestQuickSort()
        {
            var rand = new Random();
            var arr = new int[3];

            for (var i = 0; i < arr.Length; i++)
                arr[i] = rand.Next(0, 100);

            QuickSort(arr, 0, arr.Length - 1);

            Console.WriteLine("Сортировка 3 элементов");
            if (arr[0] < arr[1] && arr[1] < arr[2])
            {
                Console.WriteLine("Сортировка работает корректно");

                foreach (var n in arr)
                    Console.Write(n + " ");
            }
            else
                Console.WriteLine("Сортировка работает не корректно");

            Console.WriteLine(Environment.NewLine);
        }

        private static void TestQuickSort2()
        {
            var rand = new Random();
            var arr = new int[100];

            for (var i = 0; i < arr.Length; i++)
                arr[i] = rand.Next(0, 1000);

            QuickSort(arr, 0, arr.Length - 1);

            Console.WriteLine("Сортировка 100 элементов");
            Console.WriteLine("Результаты сортировки");
            foreach (var n in arr)
                Console.Write(n + " ");

            Console.WriteLine(Environment.NewLine);
        }

        private static void TestQuickSort3()
        {
            var rand = new Random();
            var arr = new int[1000];

            for (var i = 0; i < arr.Length; i++)
                arr[i] = rand.Next(0, 5000);

            QuickSort(arr, 0, arr.Length - 1);
            Console.WriteLine("Сортировка 1000 элементов");
            var res = true;
            for(var i = 0; i <= 10; i++)
            {
                var firstIndex = rand.Next(0, 1000);
                var secondIndex = rand.Next(0, 1000);
                var a = arr[firstIndex];
                var b = arr[secondIndex];

                if (firstIndex > secondIndex)
                    res = a > b;
                else
                    res = a < b;
            }

            if(res)
                Console.WriteLine("Сортировка работает корректно");
            else
                Console.WriteLine("Сортировка работает не корректно");

            Console.WriteLine(Environment.NewLine);
        }

        private static void TestEmptyArray()
        {
            var arr = new int[0];
            QuickSort(arr, 0, arr.Length - 1);
            Console.WriteLine("Сортировка пустого массива");
            Console.WriteLine("Сортировка работает корректно");
        }

        private static void TestVeryBigSort()
        {
            var rand = new Random();
            var arr = new int[1500000000];

            for (var i = 0; i < arr.Length; i++)
                arr[i] = rand.Next(0, 2000000000);

            QuickSort(arr, 0, arr.Length - 1);

            Console.WriteLine("Сортировка 1500000000 элементов");
            var res = true;
            for (var i = 0; i <= 10; i++)
            {
                var firstIndex = rand.Next(0, 1500000000);
                var secondIndex = rand.Next(0, 1500000000);
                var a = arr[firstIndex];
                var b = arr[secondIndex];

                if (firstIndex > secondIndex)
                    res = a > b;
                else
                    res = a < b;
            }

            if (res)
                Console.WriteLine("Сортировка работает корректно");
            else
                Console.WriteLine("Сортировка работает не корректно");

            Console.WriteLine(Environment.NewLine);
        }
    }
}
