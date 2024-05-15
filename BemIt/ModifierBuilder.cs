using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace BemIt;

public class ModifierBuilder
{
    private readonly IBlockOrElement _blockOrElement;
    private readonly StringBuilder _stringBuilder;

    public ModifierBuilder(string blockOrElement)
    {
        ArgumentNullException.ThrowIfNull(blockOrElement);

        _blockOrElement = new Block(blockOrElement);
        _stringBuilder = new StringBuilder();
        _stringBuilder.Append(blockOrElement + " ");
    }

    public ModifierBuilder Modifier(string modifier, bool condition)
    {
        if (condition)
        {
            _stringBuilder.Append(_blockOrElement.Modifier(modifier, condition) + " ");
        }

        return this;
    }

    public ModifierBuilder Modifier<TEnum>(TEnum modifier, TEnum value = default) where TEnum : Enum
    {
        if (!modifier.Equals(value))
        {
            _stringBuilder.Append(_blockOrElement.Modifier(modifier, value) + " ");
        }

        return this;
    }

    public ModifierBuilder Modifier(bool modifier, [CallerArgumentExpression("modifier")] string name = "")
    {
        if (modifier)
        {
            _stringBuilder.Append(_blockOrElement.Modifier(modifier, name) + " ");
        }

        return this;
    }

    public string Build()
    {
        return _stringBuilder.ToString().Trim();
    }

    public override string ToString()
    {
        return Build();
    }
}