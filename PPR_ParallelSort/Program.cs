using PPR_ParallelSort;
using System.Diagnostics;


int Min = 0;
int Max = 10_000_000;

int[] dataSource = new int[10_000_000];

Random randNum = new(1);

for (int i = 0; i < dataSource.Length; i++)
{
    dataSource[i] = randNum.Next(Min, Max);
}

List<double> measurements = new List<double>();

// ------------------------------- Quick Sort  ---------------------------------- 
Console.WriteLine("----------------- Quick Sort -----------------");

for (int j = 0; j < 10; j++)
{
    int[] data = dataSource.Select(e => e).ToArray();

    Stopwatch sw = Stopwatch.StartNew();
    QuickSort.Sort(data, 0, data.Length - 1);
    sw.Stop();

    Console.WriteLine($"QuickSort Elapsed: {sw.Elapsed}");
    measurements.Add(sw.Elapsed.TotalMilliseconds);
}

double average = measurements.Average();
Console.WriteLine($"Quicksort Average: {average}");
measurements.Clear();

// ------------------------------- Merge Sort  ---------------------------------- 
Console.WriteLine("----------------- Merge Sort -----------------");

for (int j = 0; j < 10; j++)
{
    int[] data = dataSource.Select(e => e).ToArray();

    Stopwatch sw = Stopwatch.StartNew();
    MergeSort.Sort(data, 0, data.Length - 1);
    sw.Stop();

    Console.WriteLine($"MergeSort Elapsed: {sw.Elapsed}");
    measurements.Add(sw.Elapsed.TotalMilliseconds);

}

average = measurements.Average();
Console.WriteLine($"Quicksort Average: {average}");
measurements.Clear();

// ---------------------- Quick Sort Parallel Optimized ------------------------- 
Console.WriteLine("----------------- Quick Sort Parallel Optimized -----------------");

for (int j = 0; j < 10; j++)
{
    int[] data = dataSource.Select(e => e).ToArray();

    Stopwatch sw = Stopwatch.StartNew();
    QuickSort.SortParallel(data, 0, data.Length - 1, 100000);
    sw.Stop();

    Console.WriteLine($"QuickSort Parallel Elapsed: {sw.Elapsed}");
    measurements.Add(sw.Elapsed.TotalMilliseconds);
}

average = measurements.Average();
Console.WriteLine($"Quicksort Average: {average}");
measurements.Clear();

// ---------------------- Merge Sort Parallel Optimized -------------------------
Console.WriteLine("----------------- Merge Sort Parallel Optimized -----------------");

for (int j = 0; j < 10; j++)
{
    int[] data = dataSource.Select(e => e).ToArray();

    Stopwatch sw = Stopwatch.StartNew();
    MergeSort.SortParallel(data, 0, data.Length - 1, 100000);
    sw.Stop();

    Console.WriteLine($"MergeSort Parallel Elapsed: {sw.Elapsed}");
    measurements.Add(sw.Elapsed.TotalMilliseconds);
}

average = measurements.Average();
Console.WriteLine($"Quicksort Average: {average}");