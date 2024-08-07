using System.Text.RegularExpressions;

namespace StringRepository;
public static class EnumDescriber
{
  public static string Wordify(string pascalCaseString)
  {
    Regex r = new Regex("(?<=[a-z])(?<x>[A-Z])|(?<=.)(?<x>[A-Z])(?=[a-z])");
    return r.Replace(pascalCaseString, " ${x}");
  }
}