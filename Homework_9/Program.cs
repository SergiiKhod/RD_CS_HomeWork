using System.Diagnostics;
using System.IO;

namespace HomeWork_9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Сonsole application for comparing different sorting methods");
            Console.WriteLine();

            int length = 0;

            {
                Console.Write("Please, enter an integer array length greater than 0: ");
                var tmp = Console.ReadLine();
                try { length = int.Parse(tmp); } catch { }
            } while (length == 0)


            Console.WriteLine("Generate array...");
            int[] array1 = GenerateRandomArray(length);

            object[] array2=new object[array1.Length];
            array1.CopyTo(array2, 0);

            int[] array3 = (int[])array1.Clone();

            object[] array4 = new object[array1.Length];
            array1.CopyTo(array4, 0);

            Console.WriteLine($"An integer array of length {length} is generated");

            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine();
            Console.WriteLine("Bubble sort");
            Console.WriteLine("___________________________________________________________________________");

            Console.Write($"Start sort with generics...\t\t");
            stopwatch.Start();
            BubbleSortWithGenerics(array2);
            stopwatch.Stop();
            Console.WriteLine($"Run time: {stopwatch.Elapsed}");

            stopwatch.Reset();
            Console.Write($"Start sort without generics...\t\t");
            stopwatch.Start();
            BubbleSortWithoutGenerics(array1);
            stopwatch.Stop();
            Console.WriteLine($"Run time: {stopwatch.Elapsed}");

            Console.WriteLine();
            Console.WriteLine("Heap sort");
            Console.WriteLine("___________________________________________________________________________");

            Console.Write($"Start sort with generics...\t\t");
            stopwatch.Start();
            HeapSortWithGenerics.Sort(array4);
            stopwatch.Stop();
            Console.WriteLine($"Run time: {stopwatch.Elapsed}");

            stopwatch.Reset();
            Console.Write($"Start sort without generics...\t\t");
            stopwatch.Start();
            HeapSortWithoutGenerics.Sort(array3);
            stopwatch.Stop();
            Console.WriteLine($"Run time: {stopwatch.Elapsed}");
        }

        public static int[] GenerateRandomArray(int size)
        {
            Random rand = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(1000);
            }

            return array;
        }

        public static void BubbleSortWithoutGenerics(int[] array)
        {
            int length = array.Length;

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        public static void BubbleSortWithGenerics(object[] array)
        {
            int length = array.Length;

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - i - 1; j++)
                {
                    if ((int)array[j]>(int)array[j + 1])
                    {
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        class HeapSortWithGenerics
        {
            public static void Sort(object[] array)
            {
                int length = array.Length;

                for (int i = length / 2 - 1; i >= 0; i--)
                {
                    Heapify(array, length, i);
                }

                for (int i = length - 1; i >= 0; i--)
                {
                    var temp = array[0];
                    array[0] = array[i];
                    array[i] = temp;

                    Heapify(array, i, 0);
                }
            }

            private static void Heapify(object[] array, int heapSize, int rootIndex)
            {
                int maxIndex = rootIndex;
                int leftChildIndex = 2 * rootIndex + 1;
                int rightChildIndex = 2 * rootIndex + 2;

                if (leftChildIndex < heapSize && (int)array[leftChildIndex]>(int)array[maxIndex])
                {
                    maxIndex = leftChildIndex;
                }

                if (rightChildIndex < heapSize && (int)array[rightChildIndex]>(int)array[maxIndex])
                {
                    maxIndex = rightChildIndex;
                }

                if (maxIndex != rootIndex)
                {
                    var temp = array[rootIndex];
                    array[rootIndex] = array[maxIndex];
                    array[maxIndex] = temp;

                    Heapify(array, heapSize, maxIndex);
                }
            }
        }

        class HeapSortWithoutGenerics
        {
            public static void Sort(int[] array)
            {
                int length = array.Length;

                for (int i = length / 2 - 1; i >= 0; i--)
                {
                    Heapify(array, length, i);
                }

                for (int i = length - 1; i >= 0; i--)
                {
                    int temp = array[0];
                    array[0] = array[i];
                    array[i] = temp;

                    Heapify(array, i, 0);
                }
            }

            private static void Heapify(int[] array, int heapSize, int rootIndex)
            {
                int maxIndex = rootIndex;
                int leftChildIndex = 2 * rootIndex + 1;
                int rightChildIndex = 2 * rootIndex + 2;

                if (leftChildIndex < heapSize && array[leftChildIndex] > array[maxIndex])
                {
                    maxIndex = leftChildIndex;
                }

                if (rightChildIndex < heapSize && array[rightChildIndex] > array[maxIndex])
                {
                    maxIndex = rightChildIndex;
                }

                if (maxIndex != rootIndex)
                {
                    int temp = array[rootIndex];
                    array[rootIndex] = array[maxIndex];
                    array[maxIndex] = temp;

                    Heapify(array, heapSize, maxIndex);
                }
            }
        }
    }
}