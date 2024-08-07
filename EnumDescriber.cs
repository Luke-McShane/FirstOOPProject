using System.Text.RegularExpressions;

public static class EnumDescriber
{
  public static string Wordify(string pascalCaseString)
  {
    Regex r = new Regex("(?<=[a-z])(?<x>[A-Z])|(?<=.)(?<x>[A-Z])(?=[a-z])");
    return r.Replace(pascalCaseString, " ${x}");
  }
}