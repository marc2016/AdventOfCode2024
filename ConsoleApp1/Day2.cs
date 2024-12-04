using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

public static class Day2 {
  public static int Start1() {
    var inputs = new List<int[]> ();
    try
    {
        string[] lines = File.ReadAllLines("./inputs/day2.txt");
        foreach (string line in lines)
        {
            var splittedLine = line.Split(" ");
            inputs.Add(splittedLine.Select(s => int.Parse(s)).ToArray());
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }

    var safeInputCount = 0;
    foreach (var input in inputs)
    {
      var safe = true;
      if(input[0] > input[1])
      {
        for (int i = 1; i < input.Length; i++)
        {
          var diff = input[i-1] - input[i];
          if(!(diff >= 1 && diff <=3))
          {
            safe = false;
            break;
          }
        }
      }
      else
      {
        for (int i = 1; i < input.Length; i++)
        {
          var diff = input[i] - input[i-1];
          if(!(diff >= 1 && diff <=3))
          {
            safe = false;
            break;
          }
        }
        
      }
      if(safe)
        safeInputCount++;
    }

    return safeInputCount;
  }

  public static int Start2() {
    var inputs = new List<int[]> ();
    try
    {
        string[] lines = File.ReadAllLines("./inputs/day2.txt");
        foreach (string line in lines)
        {
            var splittedLine = line.Split(" ");
            inputs.Add(splittedLine.Select(s => int.Parse(s)).ToArray());
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }

    var safeInputCount = 0;
    foreach (var input in inputs)
    {
      if(input.IsSafe()) 
        safeInputCount++;
      else {
        for (int i = 0; i < input.Length; i++)
        {
          if(input.WithoutIndex(i).IsSafe())
          {
            safeInputCount++;
            break;
          }
        }
      }
    }

    return safeInputCount;
  }

  private static bool IsSafe(this int[] input) {
    for (int i = 0; i < input.Length-1; i++)
    {
      var diff = 0;
      if(input[0] > input[1])
      {
        diff = input[i] - input[i+1];
      }
      else
      {
        diff = input[i+1] - input[i];
      }
      if(!(diff >= 1 && diff <=3))
      {
        return false;
      }
    }
    return true;
  }

  private static int[] WithoutIndex(this int[] input, int indexToExclude) {
    return input.Select((number, index) => new { number, index }) // Create an anonymous type with number and index
            .Where(x => x.index != indexToExclude) // Filter out the unwanted index
            .Select(x => x.number).ToArray();
  }
}