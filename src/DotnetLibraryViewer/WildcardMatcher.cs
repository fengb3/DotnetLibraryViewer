using System.Text;
using System.Text.RegularExpressions;

namespace DotnetLibraryViewer;

public static class WildcardMatcher
{
    public static bool IsMatch(string input, string pattern)
    {
        var regex = ToRegex(pattern);
        return regex.IsMatch(input);
    }

    private static Regex ToRegex(string pattern)
    {
        var sb = new StringBuilder(pattern.Length);
        foreach (var c in pattern)
        {
            switch (c)
            {
                case '*': sb.Append(".*"); break;
                case '?': sb.Append('.'); break;
                default:
                    if (IsRegexSpecial(c))
                        sb.Append('\\');
                    sb.Append(c);
                    break;
            }
        }
        return new Regex(sb.ToString(), RegexOptions.IgnoreCase);
    }

    private static bool IsRegexSpecial(char c)
        => "\\.+^${}()|[]".Contains(c);
}
