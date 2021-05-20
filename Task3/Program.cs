using System;

/*
 * Реализовать сортировку вставками - без .OrderBy() 
 */

namespace Task3 {
    class Program {
        static int[] InsertionSort(int[] array) {
            for (int i = 1; i < array.Length; i++) {
                int key = array[i];
                int j = i;
                while (j > 0 && key < array[j - 1]) {
                    array[j] = array[j - 1];
                    j--;
                }

                array[j] = key;
            }

            return array;
        }

        static void Main(string[] args) {
            int[] array = { 13, 10, 44, 9, 55, 100, 17, 80 };
            Console.Write("Array: ");
            foreach (int el in array) {
                Console.Write(el + " ");
            }
            Console.WriteLine();

            int[] sortedArray = InsertionSort(array);
            Console.Write("Sorted array: ");
            foreach (int el in sortedArray) {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }
    }
}
