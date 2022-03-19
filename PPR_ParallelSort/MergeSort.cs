using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPR_ParallelSort
{
    public class MergeSort
    {
        private static void Merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            i = 0;
            j = 0;

            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        public static void SortParallel(int[] arr, int l, int r, int threshold)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;

                if(r - l > threshold)
                {
                    Task task1 = Task.Factory.StartNew(() => SortParallel(arr, l, m, threshold));
                    Task task2 = Task.Factory.StartNew(() => SortParallel(arr, m + 1, r, threshold));

                    Task task3 = Task.Factory.StartNew(() => Merge(arr, l, m, r));

                    Task.WaitAll(task1, task2, task3);
                }
                else
                {
                    SortParallel(arr, l, m, threshold);
                    SortParallel(arr, m + 1, r, threshold);

                    Merge(arr, l, m, r);
                }
            }
        }

        public static void Sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;

                Sort(arr, l, m);
                Sort(arr, m + 1, r);

                Merge(arr, l, m, r);
            }
        }
    }
}
