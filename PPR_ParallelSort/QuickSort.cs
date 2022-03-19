using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPR_ParallelSort
{
    public class QuickSort
    {
        public static void Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Sort(arr, pivot + 1, right);
                }
            }
        }

        public static void SortParallel(int[] arr, int left, int right, int threshold)
        {
            if (left < right)
            {
                List<Task> tasks = new();

                int pivot = Partition(arr, left, right);

                Task task1 = Task.CompletedTask;
                Task task2 = Task.CompletedTask;

                if (pivot > 1)
                {
                    //task1 = Task.Factory.StartNew(() => SortParallel(arr, left, pivot - 1, threshold));
                    if (right - left > threshold)
                    {
                        task1 = Task.Factory.StartNew(() => SortParallel(arr, left, pivot - 1, threshold));
                    }
                    else
                    {
                        SortParallel(arr, left, pivot - 1, threshold);
                    }
                }
                if (pivot + 1 < right)
                {
                    //task2 = Task.Factory.StartNew(() => SortParallel(arr, pivot + 1, right, threshold));
                    if (right - left > threshold)
                    {
                        task2 = Task.Factory.StartNew(() => SortParallel(arr, pivot + 1, right, threshold));
                    }
                    else
                    {
                        SortParallel(arr, pivot + 1, right, threshold);
                    }
                }

                Task.WaitAll(task1, task2);
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {

                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
    }
}
