using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BemIt;

public static class BlockOrElementExtensions
{
    public static Modifier Modifier(this IBlockOrElement blockOrElement)
    {
        return new Modifier(blockOrElement.Name);
    }
    
    public static Modifier Modifier(this IBlockOrElement blockOrElement, string modifier)
    {
        return new Modifier(blockOrElement.Name, modifier);
    }

    public static Modifier Modifier(this IBlockOrElement blockOrElement, string modifier, bool condition)
    {
        return new Modifier(blockOrElement.Name, modifier, condition);
    }

    public static Modifier Modifier(this IBlockOrElement blockOrElement, IDictionary<string, bool> modifiers)
    {
        return new Modifier(blockOrElement.Name, modifiers);
    }

    public static Modifier Modifier(this IBlockOrElement blockOrElement, Enum value, string? name = null)
    {
        var modifier = BemIt.Modifier.FormatEnum(value, name);

        return new Modifier(blockOrElement.Name, modifier);
    }

    public static Modifier Modifier(this IBlockOrElement blockOrElement, bool modifier, [CallerArgumentExpression("modifier")] string name = "")
    {
        return new Modifier(blockOrElement.Name, name, modifier);
    }

    public static Modifier Modifier(this IBlockOrElement blockOrElement, bool modifier1, bool modifier2,
        [CallerArgumentExpression("modifier1")]
        string name1 = "",
        [CallerArgumentExpression("modifier2")]
        string name2 = "")
    {
        return new Modifier(blockOrElement.Name, new Dictionary<string, bool>()
        {
            { name1, modifier1 },
            { name2, modifier2 }
        });
    }

    public static Modifier Modifier(this IBlockOrElement blockOrElement, bool modifier1, bool modifier2, bool modifier3,
        [CallerArgumentExpression("modifier1")]
        string name1 = "",
        [CallerArgumentExpression("modifier2")]
        string name2 = "",
        [CallerArgumentExpression("modifier3")]
        string name3 = "")
    {
        return new Modifier(blockOrElement.Name, new Dictionary<string, bool>()
        {
            { name1, modifier1 },
            { name2, modifier2 },
            { name3, modifier3 },
        });
    }
}
