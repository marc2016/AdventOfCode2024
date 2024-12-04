using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

public static class Day3 {
  public static int Start1() {
    string all = File.ReadAllText("./inputs/day3.txt");
    string pattern = @"mul\((\d{1,3}),(\d{1,3})\)"; // Matches words with exactly 4 letters

    var result = 0;
    var matches = Regex.Matches(all, pattern);
    foreach (Match match in matches)
    {
      var left = int.Parse(match.Groups[1].Value);
      var right = int.Parse(match.Groups[2].Value);
      result += (left * right);
    }

    return result;
  }
}