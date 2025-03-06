using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace CombinationGenerator;
public class Logic
{

  public static string GenerateCombination(string filePath)
  {
    var sets = LoadSets(filePath);
    return GenerateCombination(sets);
  }

  private static List<Set> LoadSets(string filePath)
  {
    if (string.IsNullOrEmpty(filePath))
    {
      return new List<Set>();
    }

    var sets = new Dictionary<string, List<string>>();

    using (var parser = new TextFieldParser(filePath, Encoding.UTF8))
    {
      parser.TextFieldType = FieldType.Delimited;
      parser.SetDelimiters(",");
      parser.HasFieldsEnclosedInQuotes = true;
      parser.TrimWhiteSpace = false;

      while (!parser.EndOfData)
      {
        var line = parser.ReadFields() ?? [];
        if (line.Length != 2)
        {
          continue;
        }

        if (sets.TryGetValue(line[0], out List<string>? value))
        {
          value.Add(line[1]);
        }
        else
        {
          sets[line[0]] = [line[1]];
        }
      }
    }

    var r = sets.Select(s => new Set() { SetName = s.Key, ElementNames = s.Value }).ToList();
    return r;
  }

  public static string GenerateCombination(List<Set> sets)
  {
    var r = "";
    r = string.Join(",", sets.Select(s => s.SetName)) + Environment.NewLine;
    r += GetCombination("", sets);
    return r;
  }

  private static string GetCombination(string baseStr, List<Set> baseSet)
  {
    if (baseSet.Count == 0)
    {
      return baseStr + Environment.NewLine;
    }
    else
    {
      var str = "";
      var set = baseSet[0];
      var sets = baseSet.Skip(1).ToList();
      foreach (var element in set.ElementNames)
      {
        var bstr = string.IsNullOrEmpty(baseStr) ? element : baseStr + "," + element;
        str += GetCombination(bstr, sets);
      }
      return str;
    }
  }
}
