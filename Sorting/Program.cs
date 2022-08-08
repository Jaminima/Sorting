// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var arr = new int[10][];

for (int i = 0; i < arr.Length; i++)
{
    arr[i] = Sorting.Rand.RandomArray(5280);
}

Console.WriteLine($"| Algorithm  |   Reads   |   Writes    |    MS    |");

var b = new Sorting.Bubble(new int[] {} );
var bs = b.BulkSort(arr, 100);
var bb = b.OrderCheck((l, r) => l < r);
Console.WriteLine($"| Bubble     | {bs.reads} | {bs.writes} | {bs.ms}");

var m = new Sorting.Merge(new int[] { });
var ms = m.BulkSort(arr, 100);
var mb = m.OrderCheck((l, r) => l < r);
Console.WriteLine($"| Merge      | {ms.reads} | {ms.writes} | {ms.ms}");

var h = new Sorting.Heap<int>(new int[] { }, x=>x);
var hs = h.BulkSort(arr, 100);
var hb = h.OrderCheck((l, r) => l < r);
Console.WriteLine($"| Heap       | {hs.reads} | {hs.writes} | {hs.ms}");

Console.ReadLine();