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
    private readonly IDictionary<string, bool> _modifiers = new Dictionary<string, bool>();

    /// <summary>
    /// Creates a modifier instance with a block or element
    /// </summary>
    /// <param name="blockOrElement"></param>
    public Modifier(string blockOrElement) : base(blockOrElement)
    {
    }

    /// <summary>
    /// Creates a modifier instance with a block or element and modifier name
    /// </summary>
    /// <param name="blockOrElement"></param>
    /// <param name="m"></param>
    public Modifier(string blockOrElement, string m) : this(blockOrElement)
    {
        _modifiers.Add(m, true);
    }

    /// <summary>
    /// Creates a modifier instance with a block or element, modifier name and condition
    /// </summary>
    /// <param name="blockOrElement"></param>
    /// <param name="m"></param>
    /// <param name="condition"></param>
    public Modifier(string blockOrElement, string m, bool condition) : this(blockOrElement)
    {
        _modifiers.Add(m, condition);
    }

    /// <summary>
    /// Creates a modifier instance with a block or element and a set of modifiers of type dictionary
    /// </summary>
    /// <param name="blockOrElement"></param>
    /// <param name="modifiers"></param>
    public Modifier(string blockOrElement, IDictionary<string, bool> modifiers) : this(blockOrElement)
    {
        _modifiers = modifiers;
    }

    /// <summary>
    /// Adds a conditional modifier
    /// </summary>
    /// <param name="modifier"></param>
    /// <param name="condition"></param>
    /// <returns></returns>
    public Modifier And(string modifier, bool condition)
    {
        _modifiers.Add(modifier, condition);

        return this;
    }

    /// <summary>
    /// Adds a modifier
    /// </summary>
    /// <param name="modifier"></param>
    /// <returns></returns>
    public Modifier And(string modifier)
    {
        return And(modifier, true);
    }

    /// <summary>
    /// Adds a modifier of type enum
    /// </summary>
    /// <param name="value">The value of enum</param>
    /// <param name="apply">Applies the modifier if <see keywork="true"/></param>
    /// <returns></returns>
    public Modifier And(Enum value, bool apply = true)
    {
        if (!apply) return this;

        var modifier = FormatEnum(value);
        return And(modifier);
    }

    /// <summary>
    /// Adds a modifier of type enum with a specific name
    /// </summary>
    /// <param name="value"></param>
    /// <param name="name"></param>
    /// <param name="apply">Applies the modifier if <see keywork="true"/></param>
    /// <returns></returns>
    public Modifier And(Enum value, string name, bool apply = true)
    {
        if (!apply) return this;

        var modifier = FormatEnum(value, name);
        return And(modifier);
    }

    /// <summary>
    /// Adds a set of modifiers of type dictionary
    /// </summary>
    /// <param name="modifiers"></param>
    /// <returns></returns>
    public Modifier And(IDictionary<string, bool> modifiers)
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
    public Modifier And(bool modifier, [CallerArgumentExpression("modifier")] string name = "")
    {
        return And(name, modifier);
    }

    /// <summary>
    /// Adds a set of conditional modifiers whose names defaults to the names of the condition variables
    /// </summary>
    /// <param name="modifier1"></param>
    /// <param name="modifier2"></param>
    /// <param name="name1"></param>
    /// <param name="name2"></param>
    /// <returns></returns>
    public Modifier And(bool modifier1, bool modifier2,
        [CallerArgumentExpression("modifier1")]
        string name1 = "",
        [CallerArgumentExpression("modifier2")]
        string name2 = "")
    {
        return And(new Dictionary<string, bool>()
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
    public Modifier And(bool modifier1, bool modifier2, bool modifier3,
        [CallerArgumentExpression("modifier1")]
        string name1 = "",
        [CallerArgumentExpression("modifier2")]
        string name2 = "",
        [CallerArgumentExpression("modifier3")]
        string name3 = "")
    {
        return And(new Dictionary<string, bool>()
        {
            { name1, modifier1 },
            { name2, modifier2 },
            { name3, modifier3 },
        });
    }

    /// <summary>
    /// Adds a modifier based on the specified parameters.
    /// Only one of the parameters that's value is true will be added.
    /// </summary>
    /// <param name="modifier1"></param>
    /// <param name="modifier2"></param>
    /// <param name="name1"></param>
    /// <param name="name2"></param>
    /// <returns></returns>
    public Modifier AddOneOf(bool modifier1, bool modifier2,
        [CallerArgumentExpression("modifier1")]
        string name1 = "",
        [CallerArgumentExpression("modifier2")]
        string name2 = "")
    {
        if (modifier1)
        {
            And(name1);
        }
        else if (modifier2)
        {
            And(name2);
        }

        return this;
    }

    /// <summary>
    /// Adds a modifier based on the specified parameters.
    /// Only one of the parameters that's value is true will be added.
    /// </summary>
    /// <param name="modifier1"></param>
    /// <param name="modifier2"></param>
    /// <param name="modifier3"></param>
    /// <param name="name1"></param>
    /// <param name="name2"></param>
    /// <param name="name3"></param>
    /// <returns></returns>
    public Modifier AddOneOf(bool modifier1, bool modifier2, bool modifier3,
        [CallerArgumentExpression("modifier1")]
        string name1 = "",
        [CallerArgumentExpression("modifier2")]
        string name2 = "",
        [CallerArgumentExpression("modifier2")]
        string name3 = ""
    )
    {
        if (modifier1)
        {
            And(name1);
        }
        else if (modifier2)
        {
            And(name2);
        }
        else if (modifier3)
        {
            And(name3);
        }

        return this;
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

    // inherits
    public override IEnumerable<string> GenerateCssClasses()
    {
        yield return Name;

        foreach (var item in _modifiers)
        {
            var className = Combine(Name, item.Key.ToKebab(), item.Value);
            if (string.IsNullOrWhiteSpace(className))
            {
                continue;
            }

            yield return className;
        }

        foreach (var className in ClassNames.Where(c => !string.IsNullOrWhiteSpace(c)))
        {
            yield return className!;
        }
    }

    /// <summary>
    /// Builds the css class from a modifier
    /// </summary>
    /// <returns></returns>
    public override string Build()
    {
        return string.Join(" ", GenerateCssClasses());
    }

    // inherit
    public override string ToString()
    {
        return Build();
    }

    private static string Combine(string be, string modifier, bool condition)
    {
        return condition ? $"{be}--{modifier}" : string.Empty;
    }
}