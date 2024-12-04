using System;

namespace ConsoleApp1;

public static class Day1
{
  public static void Start() {
    var list1 = new List<int>();
    var list2 = new List<int>();
    try
    {
        string[] lines = File.ReadAllLines("./inputs/day1.txt");
        foreach (string line in lines)
        {
            var splittedLine = line.Split("   ");
            list1.Add(int.Parse(splittedLine[0]));
            list2.Add(int.Parse(splittedLine[1]));
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }

    var list1Ordered = list1.OrderBy(x => x).ToList();
    var list2Ordered = list2.OrderBy(x => x).ToList();

    var result1 = list1Ordered.Zip(list2Ordered, (first, second) => { return Math.Abs(first - second); });
    Console.WriteLine($"Result Day 1 {result1.Sum(x => x)}");

    var result2 = 0;
    foreach (var item in list1) {
      var count = list2.Count((n) => { return item == n; });
      result2 += count * item;
    }

    Console.WriteLine($"Result Day 1.2 {result2}");
  }
}
