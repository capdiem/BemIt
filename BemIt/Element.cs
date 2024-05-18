using BemIt.Abstracts;
#if NET6_0 || NET7_0
using ArgumentException = BemIt.Extensions.ArgumentExceptionExtensions.ArgumentException;
#endif

namespace BemIt;

/// <summary>
/// Represents a BEM (Block Element Modifier) element.
/// </summary>
public readonly struct Element : IBlockOrElement
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Element"/> struct with the specified block and element names.
    /// The names are converted to lower case and combined with "__" in between.
    /// </summary>
    /// <param name="block">The name of the block.</param>
    /// <param name="element">The name of the element.</param>
    public Element(string block, string element)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(block);
        ArgumentException.ThrowIfNullOrWhiteSpace(element);

        Name = $"{block}__{element}".ToLowerInvariant();
    }

    /// <summary>
    /// Gets the name of the element.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Creates a new modifier builder for this element.
    /// </summary>
    /// <returns>A new <see cref="ModifierBuilder"/> instance.</returns>
    public ModifierBuilder CreateModifierBuilder()
    {
        return new ModifierBuilder(Name);
    }

    /// <summary>
    /// Returns a string that represents the current element.
    /// </summary>
    /// <returns>A string that represents the current element.</returns>
    public override string ToString() => Name;
}