using BemIt.Abstracts;
#if NET6_0 || NET7_0
using ArgumentException = BemIt.Extensions.ArgumentExceptionExtensions.ArgumentException;
#endif

namespace BemIt;

/// <summary>
/// Represents a BEM (Block Element Modifier) block.
/// </summary>
public readonly struct Block : IBlockOrElement
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Block"/> struct with the specified name.
    /// The name is converted to lower case.
    /// </summary>
    /// <param name="block">The name of the block.</param>
    public Block(string block)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(block);

        Name = block.ToLowerInvariant();
    }

    /// <summary>
    /// Gets the name of the block.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Creates a new BEM element with the specified name, associated with this block.
    /// </summary>
    /// <param name="element">The name of the element.</param>
    /// <returns>A new <see cref="Element"/> instance.</returns>
    public Element Element(string element)
    {
        return new Element(Name, element);
    }

    /// <summary>
    /// Extends the current block with the specified name.
    /// </summary>
    /// <param name="name">The name appended to the current block name.</param>
    /// <returns></returns>
    public Block Extend(string name)
    {
        return new Block($"{Name}-{name}");
    }

    /// <summary>
    /// Creates a new modifier builder for this block.
    /// </summary>
    /// <returns>A new <see cref="ModifierBuilder"/> instance.</returns>
    public ModifierBuilder CreateModifierBuilder()
    {
        return new ModifierBuilder(Name);
    }

    /// <summary>
    /// Returns a string that represents the current block.
    /// </summary>
    /// <returns>A string that represents the current block.</returns>
    public override string ToString() => Name;
}