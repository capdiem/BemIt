using BemIt.Extensions;
#if NET6_0 || NET7_0
using ArgumentException = BemIt.Extensions.ArgumentExceptionExtensions.ArgumentException;
#endif

namespace BemIt;

/// <summary>
/// Represents a BEM (Block Element Modifier) modifier.
/// </summary>
public readonly struct Modifier
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Modifier"/> struct with the specified block or element and modifier names.
    /// The names are converted to lower case and combined with "--" in between.
    /// </summary>
    /// <param name="blockOrElement">The name of the block or element.</param>
    /// <param name="modifier">The name of the modifier.</param>
    public Modifier(string blockOrElement, string modifier)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(blockOrElement);
        ArgumentException.ThrowIfNullOrWhiteSpace(modifier);

        Name = $"{blockOrElement}--{modifier.ToKebab()}";
    }

    /// <summary>
    /// Gets the name of the modifier.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Returns a string that represents the current modifier.
    /// </summary>
    /// <returns>A string that represents the current modifier.</returns>
    public override string ToString() => Name;
}