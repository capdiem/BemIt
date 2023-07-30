using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BemIt;

public class Modifier : BemBase
{
    private readonly string _blockOrElement;
    private readonly IDictionary<string, bool> _modifiers = new Dictionary<string, bool>();

    public Modifier(string blockOrElement)
    {
        _blockOrElement = blockOrElement;
    }

    public Modifier(string blockOrElement, string m)
    {
        _blockOrElement = blockOrElement;

        _modifiers.Add(m, true);
    }

    public Modifier(string blockOrElement, string m, bool condition)
    {
        _blockOrElement = blockOrElement;

        _modifiers.Add(m, condition);
    }

    public Modifier(string blockOrElement, IDictionary<string, bool> modifiers)
    {
        _blockOrElement = blockOrElement;

        _modifiers = modifiers;
    }

    public Modifier With(string modifier, bool condition)
    {
        _modifiers.Add(modifier, condition);

        return this;
    }

    public Modifier With(string modifier)
    {
        return With(modifier, true);
    }

    public Modifier With(Enum value)
    {
        var modifier = FormatEnum(value);

        return With(modifier);
    }

    public Modifier With(IDictionary<string, bool> modifiers)
    {
        foreach (var (key, value) in modifiers)
        {
            _modifiers.Add(key, value);
        }

        return this;
    }

    public Modifier With(bool modifier, [CallerArgumentExpression("modifier")] string name = "")
    {
        return With(name, modifier);
    }

    public Modifier With(bool modifier1, bool modifier2,
        [CallerArgumentExpression("modifier1")]
        string name1 = "",
        [CallerArgumentExpression("modifier2")]
        string name2 = "")
    {
        return With(new Dictionary<string, bool>()
        {
            { name1, modifier1 },
            { name2, modifier2 }
        });
    }

    public Modifier With(bool modifier1, bool modifier2, bool modifier3,
        [CallerArgumentExpression("modifier1")]
        string name1 = "",
        [CallerArgumentExpression("modifier2")]
        string name2 = "",
        [CallerArgumentExpression("modifier3")]
        string name3 = "")
    {
        return With(new Dictionary<string, bool>()
        {
            { name1, modifier1 },
            { name2, modifier2 },
            { name3, modifier3 },
        });
    }

    public static string FormatEnum(Enum @enum)
    {
        var name = @enum.GetType().Name;
        var value = Enum.GetName(@enum.GetType(), @enum);

        return $"{name}-{value}".ToLower();
    }

    public override string Build()
    {
        var bemCss = _modifiers.Aggregate(_blockOrElement,
            (current, modifier) => current + Combine(_blockOrElement, modifier.Key.ToLower(), modifier.Value));

        return (bemCss + " " + string.Join(" ", ClassNames)).Trim();
    }

    public override string ToString()
    {
        return Build();
    }

    private static string Combine(string be, string modifier, bool condition)
    {
        return condition ? $" {be}--{modifier}" : string.Empty;
    }
}
