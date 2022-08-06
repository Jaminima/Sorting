// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var a = Sorting.Rand.RandomArray(12800);

var b = new Sorting.Bubble(a);
var bs = b.BulkSort(Sorting.Rand.RandomArray, 1000, 1000);
var bb = b.OrderCheck((l, r) => l < r);

var m = new Sorting.Merge(a);
var ms = m.BulkSort(Sorting.Rand.RandomArray, 1000, 1000);
var mb = m.OrderCheck((l, r) => l < r);

Console.WriteLine($"| Algorithm | Reads  | Writes |   ms   |");
Console.WriteLine($"| Bubble    | {bs.reads:000000} | {bs.writes:000000} | {bs.ms} |");
Console.WriteLine($"| Merge     | {ms.reads:000000} | {ms.writes:000000} | {ms.ms} |");
Console.ReadLine();