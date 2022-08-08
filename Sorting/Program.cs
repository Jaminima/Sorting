// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var arr = new int[100][];

for (int i = 0; i < arr.Length; i++)
{
    arr[i] = Sorting.Rand.RandomArray(1280);
}

var b = new Sorting.Bubble(new int[] {} );
var bs = b.BulkSort(arr, 100);
var bb = b.OrderCheck((l, r) => l < r);

var m = new Sorting.Merge(new int[] { });
var ms = m.BulkSort(arr, 100);
var mb = m.OrderCheck((l, r) => l < r);

Console.WriteLine($"| Algorithm | Reads  | Writes |   ms   |");
Console.WriteLine($"| Bubble    | {bs.reads:000000} | {bs.writes:000000} | {bs.ms} |");
Console.WriteLine($"| Merge| {ms.reads:000000} | {ms.writes:000000} | {ms.ms} |");
Console.ReadLine();