using System.Linq;
using System.Text.RegularExpressions;

namespace BemIt;

public static class StringExtensions
{
    public static string ToKebab(this string name)
    {
        var split = new Regex("(?<!^)(?=[A-Z])").Split(name).Select(s => s.Trim('-'));
        return string.Join("-", split).ToLowerInvariant();
    }
}
