﻿using System.Linq;
using System.Text.RegularExpressions;

namespace BemIt.Extensions;

public static partial class StringExtensions
{
    public static string ToKebab(this string name)
    {
#if NET7_0_OR_GREATER
        var split = MyRegex().Split(name).Select(s => s.Trim('-'));
#else
        var split = Regex.Split(name, "(?<!^)(?=[A-Z])").Select(s => s.Trim('-'));
#endif
        return string.Join("-", split).ToLowerInvariant()
            .TrimStart('_'); // for private fields like _myField
    }
#if NET7_0_OR_GREATER

    [GeneratedRegex("(?<!^)(?=[A-Z])")]
    private static partial Regex MyRegex();
#endif
}