using System.Text;
using BemIt.Abstracts;

namespace BemIt;

/// <summary>
/// A class that builds a string with modifiers.
/// </summary>
public class ModifierBuilder
{
    private readonly IBlockOrElement _blockOrElement;
    private readonly StringBuilder _stringBuilder;

    /// <summary>
    /// Initializes a new instance of the ModifierBuilder class.
    /// </summary>
    /// <param name="blockOrElement">The block or element to be modified.</param>
    public ModifierBuilder(string blockOrElement)
    {
        ArgumentNullException.ThrowIfNull(blockOrElement);

        _blockOrElement = new Block(blockOrElement);
        _stringBuilder = new StringBuilder();
        _stringBuilder.Append(blockOrElement);
    }

    /// <summary>
    /// Adds a modifier to the builder based on a boolean condition.
    /// </summary>
    /// <param name="modifier">The modifier to add.</param>
    /// <param name="condition">The condition to check. If true, the modifier is added.</param>
    /// <returns>The builder with the added modifier if the condition is true.</returns>
    /// <remarks>
    /// This method appends the modifier to the builder if the condition is true.
    /// The modifier is appended as a string.
    /// </remarks>
    public ModifierBuilder Add(string modifier, bool condition = true)
    {
        if (condition)
        {
            _stringBuilder.Append(' ');
            _stringBuilder.Append(_blockOrElement.Modifier(modifier, condition));
        }

        return this;
    }

    /// <summary>
    /// Adds a modifier to the builder.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum modifier.</typeparam>
    /// <param name="modifier">The enum modifier to add.</param>
    /// <param name="name">The name of the argument that provides the modifier. This is optional, and the default value is the name of the modifier.</param>
    /// <returns>The builder with the added modifier.</returns>
    /// <remarks>
    /// This method appends the modifier to the builder if it is an enum type.
    /// The modifier is appended as a string representation of the enum value.
    /// </remarks>
    /// <example>
    /// <code>
    /// var builder = new ModifierBuilder("block");
    /// var result = builder.Add(A.B).Build();
    /// </code>
    /// Result: "block block--a-b"
    /// </example>
    public ModifierBuilder Add<TEnum>(TEnum modifier, [CallerArgumentExpression("modifier")] string name = "")
        where TEnum : Enum
    {
        _stringBuilder.Append(' ');
        _stringBuilder.Append(_blockOrElement.Modifier(modifier, name));

        return this;
    }

    /// <summary>
    /// Adds a list of origin classes to the builder.
    /// </summary>
    /// <param name="classes">The classes to add.</param>
    /// <returns>The builder with the added classes.</returns>
    /// <remarks>
    /// This method appends each class in the provided list to the builder.
    /// Each class is appended as a string, with leading and trailing whitespace removed.
    /// </remarks>
    public ModifierBuilder AddClass(params string?[] classes)
    {
        foreach (var item in classes)
        {
            if (string.IsNullOrWhiteSpace(item))
            {
                continue;
            }

            _stringBuilder.Append(' ');
            _stringBuilder.Append(item);
        }

        return this;
    }

    public ModifierBuilder AddClass(string? @class, bool condition = true)
    {
        if (condition && !string.IsNullOrWhiteSpace(@class))
        {
            _stringBuilder.Append(' ');
            _stringBuilder.Append(@class);
        }

        return this;
    }

    /// <summary>
    /// Builds the string with the added modifiers and classes and resets the builder.
    /// </summary>
    /// <returns>The built string.</returns>
    public string Build(bool reset = true)
    {
        var result = _stringBuilder.ToString();

        if (reset)
        {
            Reset();
        }

        return result;
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return Build();
    }

    /// <summary>
    /// Resets the builder to its initial state.
    /// </summary>
    private void Reset()
    {
        _stringBuilder.Clear();
        _stringBuilder.Append(_blockOrElement.Name);
    }
}