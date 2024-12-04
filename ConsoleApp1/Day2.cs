using System.Runtime.CompilerServices;

public static class Day2 {
  public static int Start() {
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
}