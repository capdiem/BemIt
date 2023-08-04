using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BemIt;

/// <summary>
/// Presents a modifier in BEM
/// </summary>
public class Modifier : BemBase
{
    private readonly string _blockOrElement;
    private readonly IDictionary<string, bool> _modifiers = new Dictionary<string, bool>();

    /// <summary>
    /// Creates a modifier instance with a block or element
    /// </summary>
    /// <param name="blockOrElement"></param>
    public Modifier(string blockOrElement)
    {
        _blockOrElement = blockOrElement;
    }

    /// <summary>
    /// Creates a modifier instance with a block or element and modifier name
    /// </summary>
    /// <param name="blockOrElement"></param>
    /// <param name="m"></param>
    public Modifier(string blockOrElement, string m)
    {
        _blockOrElement = blockOrElement;

        _modifiers.Add(m, true);
    }

    /// <summary>
    /// Creates a modifier instance with a block or element, modifier name and condition
    /// </summary>
    /// <param name="blockOrElement"></param>
    /// <param name="m"></param>
    /// <param name="condition"></param>
    public Modifier(string blockOrElement, string m, bool condition)
    {
        _blockOrElement = blockOrElement;

        _modifiers.Add(m, condition);
    }

    /// <summary>
    /// Creates a modifier instance with a block or element and a set of modifiers of type dictionary
    /// </summary>
    /// <param name="blockOrElement"></param>
    /// <param name="modifiers"></param>
    public Modifier(string blockOrElement, IDictionary<string, bool> modifiers)
    {
        _blockOrElement = blockOrElement;

        _modifiers = modifiers;
    }

    /// <summary>
    /// Adds a conditional modifier
    /// </summary>
    /// <param name="modifier"></param>
    /// <param name="condition"></param>
    /// <returns></returns>
    public Modifier Add(string modifier, bool condition)
    {
        _modifiers.Add(modifier, condition);

        return this;
    }

    /// <summary>
    /// Adds a modifier
    /// </summary>
    /// <param name="modifier"></param>
    /// <returns></returns>
    public Modifier Add(string modifier)
    {
        return Add(modifier, true);
    }

    /// <summary>
    /// Adds a modifier of type enum
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public Modifier Add(Enum value)
    {
        var modifier = FormatEnum(value);

        return Add(modifier);
    }

    /// <summary>
    /// Adds a modifier of type enum with a specific name
    /// </summary>
    /// <param name="value"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public Modifier Add(Enum value, string name)
    {
        var modifier = FormatEnum(value, name);

        return Add(modifier);
    }

    /// <summary>
    /// Adds a set of modifiers of type dictionary
    /// </summary>
    /// <param name="modifiers"></param>
    /// <returns></returns>
    public Modifier Add(IDictionary<string, bool> modifiers)
    {
        foreach (var (key, value) in modifiers)
        {
            _modifiers.Add(key, value);
        }

        return this;
    }

    /// <summary>
    /// Adds a conditional modifier whose name defaults to the name of the condition variable
    /// </summary>
    /// <param name="modifier"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public Modifier Add(bool modifier, [CallerArgumentExpression("modifier")] string name = "")
    {
        return Add(name, modifier);
    }

    /// <summary>
    /// Adds a set of conditional modifiers whose names defaults to the names of the condition variables
    /// </summary>
    /// <param name="modifier1"></param>
    /// <param name="modifier2"></param>
    /// <param name="name1"></param>
    /// <param name="name2"></param>
    /// <returns></returns>
    public Modifier Add(bool modifier1, bool modifier2,
        [CallerArgumentExpression("modifier1")]
        string name1 = "",
        [CallerArgumentExpression("modifier2")]
        string name2 = "")
    {
        return Add(new Dictionary<string, bool>()
        {
            { name1, modifier1 },
            { name2, modifier2 }
        });
    }

    /// <summary>
    /// Adds a set of conditional modifiers whose names defaults to the names of the condition variables
    /// </summary>
    /// <param name="modifier1"></param>
    /// <param name="modifier2"></param>
    /// <param name="modifier3"></param>
    /// <param name="name1"></param>
    /// <param name="name2"></param>
    /// <param name="name3"></param>
    /// <returns></returns>
    public Modifier Add(bool modifier1, bool modifier2, bool modifier3,
        [CallerArgumentExpression("modifier1")]
        string name1 = "",
        [CallerArgumentExpression("modifier2")]
        string name2 = "",
        [CallerArgumentExpression("modifier3")]
        string name3 = "")
    {
        return Add(new Dictionary<string, bool>()
        {
            { name1, modifier1 },
            { name2, modifier2 },
            { name3, modifier3 },
        });
    }

    /// <summary>
    /// Formats an enum to a BEM modifier
    /// </summary>
    /// <param name="enum"></param>
    /// <param name="inputName"></param>
    /// <returns></returns>
    public static string FormatEnum(Enum @enum, string? inputName = null)
    {
        var name = inputName ?? @enum.GetType().Name;
        var value = Enum.GetName(@enum.GetType(), @enum);

        return $"{name}-{value}";
    }

    /// <summary>
    /// Builds the css class from a modifier
    /// </summary>
    /// <returns></returns>
    public override string Build()
    {
        var bemCss = _modifiers.Aggregate(_blockOrElement,
            (current, modifier) => current + Combine(_blockOrElement, modifier.Key.ToKebab(), modifier.Value));

        return (bemCss + " " + string.Join(" ", ClassNames)).Trim();
    }

    // inherit
    public override string ToString()
    {
        return Build();
    }

    private static string Combine(string be, string modifier, bool condition)
    {
        return condition ? $" {be}--{modifier}" : string.Empty;
    }
}