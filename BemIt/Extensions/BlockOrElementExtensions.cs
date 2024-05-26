using System.Text;
using BemIt.Abstracts;
using BemIt.Extensions;

namespace BemIt;

public static class BlockOrElementExtensions
{
    public static string Modifier(this IBlockOrElement blockOrElement, bool modifier,
        [CallerArgumentExpression("modifier")] string name = "")
    {
        return modifier ? new Modifier(blockOrElement.Name, FormatName(name)).ToString() : string.Empty;
    }

    public static string Modifier(this IBlockOrElement blockOrElement, string modifier, bool condition = true)
    {
        return condition ? new Modifier(blockOrElement.Name, modifier).ToString() : string.Empty;
    }

    public static string Modifier<TEnum>(this IBlockOrElement blockOrElement, TEnum modifier,
        [CallerArgumentExpression("modifier")] string name = "")
        where TEnum : Enum
    {
        var value = modifier.ToString();

        var modifierName = string.IsNullOrWhiteSpace(name) ? value : $"{name}-{value}";

        return new Modifier(blockOrElement.Name, modifierName).ToString();
    }

    public static string Modifier<TEnum>(this IBlockOrElement blockOrElement, TEnum modifier, TEnum exclude,
        [CallerArgumentExpression("modifier")] string name = "")
        where TEnum : Enum
    {
        if (exclude.Equals(modifier))
        {
            return string.Empty;
        }

        return Modifier(blockOrElement, modifier, name);
    }

    private static string FormatName(string input)
    {
        var splits = input.Split('.');
        var last = splits[^1];
        return last.ToKebab();
    }
}