using System.Linq;
using System.Text.RegularExpressions;

namespace BemIt;

public static partial class StringExtensions
{
    public static string ToKebab(this string name)
    {
#if NET7_0_OR_GREATER
        var split = MyRegex().Split(name).Select(s => s.Trim('-'));
#else
        var split = Regex.Split(name, "(?<!^)(?=[A-Z])").Select(s => s.Trim('-'));
#endif
        return string.Join("-", split).ToLowerInvariant();
    }

    public static Block ToBlock(this string name)
    {
        return new Block(name);
    }

#if NET7_0_OR_GREATER
    [GeneratedRegex("(?<!^)(?=[A-Z])")]
    private static partial Regex MyRegex();
#endif
}
