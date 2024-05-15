using System;
using System.Runtime.CompilerServices;
using BemIt.Extensions;

namespace BemIt;

public static class BlockOrElementExtensions
{
    public static Modifier Modifier(this IBlockOrElement blockOrElement, bool modifier,
        [CallerArgumentExpression("modifier")] string name = "")
    {
        if (modifier)
        {
            return new Modifier(blockOrElement.Name, FormatName(name));
        }

        return BemIt.Modifier.Empty;
    }

    public static Modifier Modifier(this IBlockOrElement blockOrElement, string modifier, bool condition)
    {
        return condition ? new Modifier(blockOrElement.Name, modifier) : BemIt.Modifier.Empty;
    }

    public static Modifier Modifier<TEnum>(this IBlockOrElement blockOrElement, TEnum modifier, TEnum exclude = default)
        where TEnum : Enum
    {
        if (exclude.Equals(modifier))
        {
            return BemIt.Modifier.Empty;
        }

        var name = modifier.GetType().Name;
        var value = modifier.ToString();

        return new Modifier(blockOrElement.Name, $"{name}-{value}");
    }

    private static string FormatName(string input)
    {
        var splits = input.Split('.');
        var last = splits[^1];
        return last.ToKebab();
    }
}